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

            foreach (var hero in heroes)
            {
                // Stat reset
                hero.CurrentAttackPower = hero.AttackPower;
                hero.CurrentMagicPower = hero.MagicPower;
                hero.CurrentArmorValue = hero.ArmorValue;
                hero.CurrentResistanceValue = hero.ResistanceValue;
                hero.CurrentHealthRegen = hero.HealthRegen;
                hero.CurrentManaRegen = hero.ManaRegen;
                hero.CurrentCritChance = hero.CritChance;
            }

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
                    double energyCap = 0;
                    int rechargeTime = 4;
                    double energy = 0;

                    if (energyChange.Type == "Walk")
                    {
                        energyCap = 30;
                        energy = hero.Energy;
                    }
                    else if (energyChange.Type == "Profession")
                    {
                        energyCap = 10;
                        energy = hero.ProfessionEnergy;
                    }
                    else if (energyChange.Type == "PvP")
                    {
                        energyCap = 15;
                        rechargeTime = 8;
                        energy = hero.PvPEnergy;
                    }
                    else if (energyChange.Type == "Health")
                    {
                        energyCap = hero.MaxHP;
                        energy = hero.CurrentHP;
                        rechargeTime = 4;
                    }
                    else if (energyChange.Type == "Mana")
                    {
                        energyCap = hero.MaxMana;
                        rechargeTime = 4;
                        energy = hero.CurrentMana;
                    }

                    var timeSpan = DateTime.UtcNow - energyChange.LastChangedOn;

                    if (energy < energyCap && timeSpan.Minutes >= rechargeTime)
                    {
                        int recoveryTimes = timeSpan.Minutes / rechargeTime;

                        if (energyChange.Type == "Walk")
                        {
                            hero.Energy += recoveryTimes;

                            if (hero.Energy > 30)
                            {
                                hero.Energy = 30;
                            }
                        }
                        else if (energyChange.Type == "Profession")
                        {
                            hero.ProfessionEnergy += recoveryTimes;

                            if (hero.ProfessionEnergy > 10)
                            {
                                hero.ProfessionEnergy = 10;
                            }
                        }
                        else if (energyChange.Type == "PvP")
                        {
                            hero.PvPEnergy += recoveryTimes;

                            if (hero.PvPEnergy > 15)
                            {
                                hero.PvPEnergy = 15;
                            }
                        }
                        else if (energyChange.Type == "Health")
                        {
                            hero.CurrentHP += (0.1 * hero.MaxHP) * recoveryTimes;
                        }
                        else if (energyChange.Type == "Mana")
                        {
                            hero.CurrentMana += 0.1 * hero.MaxMana;
                        }

                        if (energy > energyCap)
                        {
                            energy = energyCap;
                        }

                        while (true)
                        {
                            var regeneration = new EnergyChange
                            {
                                HeroId = hero.Id,
                                LastChangedOn = DateTime.UtcNow,
                                Type = energyChange.Type,
                            };

                            if (this.context.EnergyChanges.Any(ec => ec.Id == regeneration.Id))
                            {
                                continue;
                            }

                            await this.context.EnergyChanges.AddAsync(regeneration);
                            this.context.EnergyChanges.Remove(energyChange);

                            break;
                        }
                    }
                }

                this.context.Heroes.Update(hero);
            }
        }

        private async Task MainStatsRegen(Hero hero)
        {
            if (hero.CurrentHP <= 0)
            {
                hero.CurrentHP = 0;
            }
            else if (hero.CurrentHP > hero.MaxHP)
            {
                hero.CurrentHP = hero.MaxHP;
            }

            if (hero.CurrentMana > hero.MaxMana)
            {
                hero.CurrentMana = hero.MaxMana;
            }

            if (this.context.EnergyChanges.Where(ec => ec.Type == "Health" && ec.HeroId == hero.Id).Count() == 0)
            {
                if (hero.CurrentHP < hero.MaxHP)
                {
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

            if (this.context.EnergyChanges.Where(ec => ec.Type == "Mana" && ec.HeroId == hero.Id).Count() == 0)
            {
                if (hero.CurrentMana < hero.MaxMana)
                {
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
