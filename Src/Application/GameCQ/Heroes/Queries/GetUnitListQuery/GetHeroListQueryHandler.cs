﻿namespace Application.GameCQ.Heroes.Queries.GetUnitListQuery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameContent.Utilities.Stats;
    using AutoMapper;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetHeroListQueryHandler : MapperHandler, IRequestHandler<GetHeroListQuery, HeroListViewModel>
    {
        private readonly StatReset statsReset;

        public GetHeroListQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
            this.statsReset = new StatReset();
        }

        public async Task<HeroListViewModel> Handle(GetHeroListQuery request, CancellationToken cancellationToken)
        {
            var heroes = this.Context.Heroes.Where(h => h.UserId == request.UserId);

            await this.EnergyManagement(heroes);

            var result = new HeroListViewModel { Heroes = new List<HeroMinViewModel>() };

            foreach (var hero in heroes)
            {
                // Stat reset
                var mappedHero = this.Mapper.Map<HeroMinViewModel>(hero);
                var fightingClass = await this.Context.FightingClasses.FindAsync(hero.FightingClassId);

                mappedHero.ClassType = fightingClass.Type;
                mappedHero.IconURL = fightingClass.IconPath;

                result.Heroes.Add(mappedHero);

                this.statsReset.Reset(hero);
            }

            await this.Context.SaveChangesAsync(cancellationToken);

            return result;
        }

        private async Task EnergyManagement(IQueryable<Hero> heroes)
        {
            foreach (var hero in heroes)
            {
                this.MainStatsRegen(hero);
                var energyChanges = await this.Context.EnergyChanges.Where(ec => ec.HeroId == hero.Id).OrderBy(l => l.LastChangedOn).ToListAsync();

                foreach (var energyChange in energyChanges)
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

                            if (hero.CurrentHP > hero.MaxHP)
                            {
                                hero.CurrentHP = hero.MaxHP;
                            }
                        }
                        else if (energyChange.Type == "Mana")
                        {
                            hero.CurrentMana += 0.1 * hero.MaxMana * recoveryTimes;

                            if (hero.CurrentMana > hero.MaxMana)
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
                                Type = energyChange.Type,
                            };

                            if (this.Context.EnergyChanges.Any(ec => ec.Id == regeneration.Id))
                            {
                                continue;
                            }

                            this.Context.EnergyChanges.Add(regeneration);
                            this.Context.EnergyChanges.Remove(energyChange);

                            break;
                        }
                    }
                    else if (energy >= energyCap)
                    {
                        var energyChangesToRemove = this.Context.EnergyChanges.Where(e => e.Type == energyChange.Type);

                        this.Context.EnergyChanges.RemoveRange(energyChangesToRemove);
                    }
                }

                this.Context.Heroes.Update(hero);
            }
        }

        private void MainStatsRegen(Hero hero)
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

            if (this.Context.EnergyChanges.Where(ec => ec.Type == "Health" && ec.HeroId == hero.Id).Count() == 0)
            {
                if (hero.CurrentHP > hero.MaxHP)
                {
                    hero.CurrentHP = hero.MaxHP;
                }

                if (hero.CurrentHP < hero.MaxHP)
                {
                    this.Context.EnergyChanges.Add(new EnergyChange
                    {
                        HeroId = hero.Id,
                        Type = "Health",
                        LastChangedOn = DateTime.UtcNow,
                    });
                }
            }

            if (this.Context.EnergyChanges.Where(ec => ec.Type == "Mana" && ec.HeroId == hero.Id).Count() == 0)
            {
                if (hero.CurrentMana < hero.MaxMana)
                {
                    this.Context.EnergyChanges.Add(new EnergyChange
                    {
                        HeroId = hero.Id,
                        Type = "Mana",
                        LastChangedOn = DateTime.UtcNow,
                    });
                }
            }
        }
    }
}
