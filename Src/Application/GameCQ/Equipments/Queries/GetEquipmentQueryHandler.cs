namespace Application.GameCQ.Equipments.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using AutoMapper;
    using Domain.Entities.Game.Units;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetEquipmentQueryHandler : MapperHandler, IRequestHandler<GetEquipmentQuery, EquipmentViewModel>
    {
        public GetEquipmentQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<EquipmentViewModel> Handle(GetEquipmentQuery request, CancellationToken cancellationToken)
        {
            var hero = await this.Context.Heroes.FirstOrDefaultAsync(h => h.Id == request.HeroId && h.UserId == request.UserId);

            return await this.GetEquipement(hero);
        }

        private async Task<EquipmentViewModel> GetEquipement(Hero hero)
        {
            var equipment = new HashSet<ItemMinViewModel>();

            var trinketEquipment = await this.Context.TrinketEquipments.FirstOrDefaultAsync(te => te.HeroId == hero.Id);

            if (trinketEquipment != null)
            {
                var trinket = await this.Context.Trinkets.FindAsync(trinketEquipment.TrinketId);

                equipment.Add(this.Mapper.Map<ItemMinViewModel>(trinket));
            }

            var weaponEquipment = await this.Context.WeaponsEquipments.FirstOrDefaultAsync(we => we.HeroId == hero.Id);

            if (weaponEquipment != null)
            {
                var weapon = await this.Context.Weapons.FindAsync(weaponEquipment.WeaponId);

                equipment.Add(this.Mapper.Map<ItemMinViewModel>(weapon));
            }

            var armorEquipments = this.Context.ArmorsEquipments.Where(we => we.HeroId == hero.Id).AsNoTracking().Select(ae => new ItemMinViewModel
            {
                Id = ae.ArmorId,
                Name = ae.Armor.Name,
                ClassType = ae.Armor.ClassType,
                Level = ae.Armor.Level,
                ImagePath = ae.Armor.ImagePath,
                Slot = ae.Armor.Slot,
                SellPrice = ae.Armor.SellPrice,
                Count = 1,
            });

            equipment.ToList().AddRange(armorEquipments);

            if (equipment.Count == 0)
            {
                return new EquipmentViewModel
                {
                    Items = null,
                };
            }

            return new EquipmentViewModel
            {
                Items = equipment,
            };
        }
    }
}
