﻿namespace Application.GameCQ.Heroes.Queries.GetUnitListQuery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Common;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    public class GetHeroListQueryHandler : IRequestHandler<GetHeroListQuery, HeroListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;

        public GetHeroListQueryHandler(IFFDbContext context, UserManager<AppUser> userManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<HeroListViewModel> Handle(GetHeroListQuery request, CancellationToken cancellationToken)
        {
            var user = await this.userManager.GetUserAsync(request.User);

            var heroes = this.context.Heroes.Where(h => h.UserId == user.Id);

            await this.EnergyManagement(heroes.ToList());

            await this.context.SaveChangesAsync(cancellationToken);

            return new HeroListViewModel
            {
                Heroes = await heroes.ProjectTo<HeroMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
            };
        }

        private async Task EnergyManagement(List<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                await this.MainStatsRegen(hero);

                foreach (var energyChange in this.context.EnergyChanges.Where(ec => ec.HeroId == hero.Id).OrderBy(l => l.LastChangedOn).ToList())
                {
                    int energyCap = 0;
                    int rechargeTime = 4;
                    int energy = 0;

                    string type = string.Empty;

                    if (energyChange.Type == "Walk")
                    {
                        energyCap = 30;
                        energy = hero.Energy;
                        type = "Walk";
                    }
                    else if (energyChange.Type == "Profession")
                    {
                        energyCap = 10;
                        energy = hero.ProfessionEnergy;
                        type = "Profession";
                    }
                    else if (energyChange.Type == "PvP")
                    {
                        energyCap = 15;
                        rechargeTime = 8;
                        energy = hero.PvPEnergy;
                        type = "PvP";
                    }
                    else if (energyChange.Type == "Health")
                    {
                        energyCap = (int)hero.MaxHP;
                        energy = (int)hero.CurrentHP;
                        rechargeTime = 4;
                        type = "Health";
                    }
                    else if (energyChange.Type == "Mana")
                    {
                        energyCap = (int)hero.MaxMana;
                        rechargeTime = 4;
                        energy = (int)hero.CurrentMana;
                        type = "Mana";
                    }

                    if (energy < energyCap && DateTime.UtcNow.Minute - energyChange.LastChangedOn.Minute >= rechargeTime)
                    {
                        if (energyChange.Type == "Walk")
                        {
                            hero.Energy++;
                        }
                        else if (energyChange.Type == "Profession")
                        {
                            hero.ProfessionEnergy++;
                        }
                        else if (energyChange.Type == "PvP")
                        {
                            hero.PvPEnergy++;
                        }
                        else if (energyChange.Type == "Health")
                        {
                            hero.CurrentHP += 0.1 * hero.MaxHP;

                            if (hero.MaxHP < hero.CurrentHP)
                            {
                                hero.CurrentHP = hero.MaxHP;
                            }
                        }
                        else if (energyChange.Type == "Mana")
                        {
                            hero.CurrentMana += 0.1 * hero.MaxMana;

                            if (hero.MaxMana < hero.CurrentMana)
                            {
                                hero.CurrentMana = hero.MaxMana;
                            }
                        }

                        while (true)
                        {
                            var regeneration = new EnergyChange
                            {
                                HeroId = hero.Id,
                                LastChangedOn = DateTime.UtcNow,
                                Type = type,
                            };

                            if (this.context.EnergyChanges.Any(ec => ec.Id == regeneration.Id))
                            {
                                continue;
                            }
                            await this.context.EnergyChanges.AddAsync(regeneration);

                            break;
                        }

                        this.context.EnergyChanges.Remove(energyChange);
                    }

                    if (energy == energyCap)
                    {
                        var personalEnergyChanges = this.context.EnergyChanges.Where(ec => ec.HeroId == hero.Id && ec.Type == type);

                        this.context.EnergyChanges.RemoveRange(personalEnergyChanges);
                    }
                }

                this.context.Heroes.Update(hero);
            }
        }

        private async Task MainStatsRegen(Hero hero)
        {
            if (this.context.EnergyChanges.Where(ec => ec.Type == "Health").Count() == 0)
            {
                if (hero.CurrentHP < hero.MaxHP)
                {
                    hero.CurrentHP += 0.1 * hero.MaxHP;

                    await this.context.EnergyChanges.AddAsync(new EnergyChange
                    {
                        HeroId = hero.Id,
                        Type = "Health",
                        LastChangedOn = DateTime.UtcNow,
                    });
                }

                if (hero.CurrentHP > hero.MaxHP)
                {
                    hero.CurrentHP = hero.MaxHP;
                }
            }

            if (this.context.EnergyChanges.Where(ec => ec.Type == "Mana").Count() == 0)
            {
                if (hero.CurrentMana < hero.MaxMana)
                {
                    hero.CurrentMana += 0.1 * hero.MaxMana;

                    await this.context.EnergyChanges.AddAsync(new EnergyChange
                    {
                        HeroId = hero.Id,
                        Type = "Mana",
                        LastChangedOn = DateTime.UtcNow,
                    });
                }

                if (hero.CurrentMana > hero.MaxMana)
                {
                    hero.CurrentMana = hero.MaxMana;
                }
            }
        }
    }
}
