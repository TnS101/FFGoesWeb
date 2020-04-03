namespace Application.GameCQ.Equipments.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetEquipmentQueryHandler : IRequestHandler<GetEquipmentQuery, EquipmentViewModel>
    {
        private readonly IFFDbContext context;

        public GetEquipmentQueryHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<EquipmentViewModel> Handle(GetEquipmentQuery request, CancellationToken cancellationToken)
        {
            var hero = await this.context.Heroes.FindAsync(request.HeroId);

            if (request.Slot == "Weapon")
            {
                return await this.GetWeapon(hero);
            }
            else if (request.Slot == "Trinket")
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
            if (!this.context.TrinketEquipments.ToList().Any(te => te.EquipmentId == hero.EquipmentId))
            {
                return new EquipmentViewModel
                {
                    Items = null,
                };
            }

            var equipment = await this.context.TrinketEquipments.FirstOrDefaultAsync(te => te.EquipmentId == hero.EquipmentId);

            var trinket = await this.context.Trinkets.FindAsync(equipment.TrinketId);

            var trinkets = new List<Trinket>();

            return new EquipmentViewModel
            {
                Items = (List<ItemMinViewModel>)trinkets.Select(w => new ItemMinViewModel
                {
                    Id = w.Id,
                    ImageURL = w.ImageURL,
                    Name = w.Name,
                }),
            };
        }

        private EquipmentViewModel ArmorList(Hero hero)
        {
            if (!this.context.ArmorsEquipments.ToList().Any(te => te.EquipmentId == hero.EquipmentId))
            {
                return new EquipmentViewModel
                {
                    Items = null,
                };
            }

            var equipments = this.context.ArmorsEquipments.Where(we => we.EquipmentId == hero.EquipmentId);

            var armors = new List<Armor>();

            foreach (var armor in this.context.Armors)
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
                    ImageURL = w.ImageURL,
                    Name = w.Name,
                }),
            };
        }

        private async Task<EquipmentViewModel> GetWeapon(Hero hero)
        {
            if (!this.context.WeaponsEquipments.ToList().Any(te => te.EquipmentId == hero.EquipmentId))
            {
                return new EquipmentViewModel
                {
                    Items = null,
                };
            }

            var equipment = await this.context.WeaponsEquipments.FirstOrDefaultAsync(we => we.EquipmentId == hero.EquipmentId);

            var weapon = await this.context.Weapons.FindAsync(equipment.WeaponId);

            var weapons = new List<Weapon>
            {
                weapon,
            };

            return new EquipmentViewModel
            {
                Items = (List<ItemMinViewModel>)weapons.Select(w => new ItemMinViewModel
                {
                    Id = w.Id,
                    ImageURL = w.ImageURL,
                    Name = w.Name,
                }),
            };
        }
    }
}
