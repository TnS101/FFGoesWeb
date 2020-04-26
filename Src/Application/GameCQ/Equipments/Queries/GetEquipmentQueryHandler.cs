namespace Application.GameCQ.Equipments.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using AutoMapper.QueryableExtensions;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetEquipmentQueryHandler : BaseHandler, IRequestHandler<GetEquipmentQuery, EquipmentViewModel>
    {
        public GetEquipmentQueryHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<EquipmentViewModel> Handle(GetEquipmentQuery request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FindAsync(request.HeroId);

            if (request.Slot == "Weapon")
            {
                return await this.GetWeapon(hero);
            }
            else if (request.Slot != "Trinket")
            {
                return this.ArmorList(hero);
            }
            else
            {
                return await this.GetTrinket(hero);
            }
        }

        private async Task<EquipmentViewModel> GetTrinket(Hero hero)
        {
            if (!this.Context.TrinketEquipments.Any(te => te.EquipmentId == hero.EquipmentId))
            {
                return new EquipmentViewModel
                {
                    Items = null,
                };
            }

            var equipment = await this.Context.TrinketEquipments.FindAsync(hero.EquipmentId);

            var trinket = await this.Context.Trinkets.FindAsync(equipment.TrinketId);

            var trinkets = new List<Trinket>
            {
                trinket,
            };

            return new EquipmentViewModel
            {
                Items = trinkets.Select(w => new ItemMinViewModel
                {
                    Id = w.Id,
                    ImagePath = w.ImagePath,
                    Name = w.Name,
                    Slot = w.Slot,
                    Level = w.Level,
                }).ToList(),
            };
        }

        private EquipmentViewModel ArmorList(Hero hero)
        {
            if (!this.Context.ArmorsEquipments.ToList().Any(te => te.EquipmentId == hero.EquipmentId))
            {
                return new EquipmentViewModel
                {
                    Items = null,
                };
            }

            var equipments = this.Context.ArmorsEquipments.Where(we => we.EquipmentId == hero.EquipmentId);

            var armors = new List<Armor>();

            foreach (var armor in this.Context.Armors)
            {
                foreach (var equip in equipments)
                {
                    if (equip.ArmorId == armor.Id)
                    {
                        armors.Add(armor);
                    }
                }
            }

            return new EquipmentViewModel
            {
                Items = (List<ItemMinViewModel>)armors.Select(w => new ItemMinViewModel
                {
                    ImagePath = w.ImagePath,
                    Name = w.Name,
                }),
            };
        }

        private async Task<EquipmentViewModel> GetWeapon(Hero hero)
        {
            if (!this.Context.WeaponsEquipments.ToList().Any(te => te.EquipmentId == hero.EquipmentId))
            {
                return new EquipmentViewModel
                {
                    Items = null,
                };
            }

            var equipment = await this.Context.WeaponsEquipments.FirstOrDefaultAsync(we => we.EquipmentId == hero.EquipmentId);

            var weapon = await this.Context.Weapons.FindAsync(equipment.WeaponId);

            var weapons = new List<Weapon>
            {
                weapon,
            };

            return new EquipmentViewModel
            {
                Items = (List<ItemMinViewModel>)weapons.Select(w => new ItemMinViewModel
                {
                    Id = w.Id,
                    ImagePath = w.ImagePath,
                    Name = w.Name,
                }),
            };
        }
    }
}
