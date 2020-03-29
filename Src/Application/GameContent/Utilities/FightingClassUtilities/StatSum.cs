namespace Application.GameContent.Utilities.FightingClassUtilites
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;

    public class StatSum
    {
        public StatSum()
        {
        }

        public async Task Sum(Hero hero, IFFDbContext context)
        {
            if (hero.Equipment.ArmorEquipments.Count > 0)
            {
                foreach (var item in await context.Armors.Where(a => a.ArmorEquipments.Any(ae => ae.EquipmentId == hero.EquipmentId)).ToListAsync())
                {
                    hero.AttackPower += item.Agility;
                    hero.MagicPower += item.Intellect;
                    hero.ManaRegen += item.Spirit;
                    hero.MaxHP += item.Stamina * 5;
                    hero.AttackPower += item.Strength;
                    hero.ArmorValue += item.ArmorValue;
                    hero.RessistanceValue += item.RessistanceValue;
                }
            }

            if (!hero.Equipment.WeaponSlot)
            {
                var weapon = await context.Weapons.FirstOrDefaultAsync(w => w.WeaponEquipments.FirstOrDefault().EquipmentId == hero.EquipmentId);

                hero.AttackPower += weapon.AttackPower;
                hero.AttackPower += weapon.Agility;
                hero.MagicPower += weapon.Intellect;
                hero.ManaRegen += weapon.Spirit;
                hero.MaxHP += weapon.Stamina * 5;
                hero.AttackPower += weapon.Strength;
            }

            if (!hero.Equipment.TrinketSlot)
            {
                var trinket = await context.Trinkets.FirstOrDefaultAsync(t => t.TrinketEquipments.FirstOrDefault().EquipmentId == hero.EquipmentId);

                hero.AttackPower += trinket.Agility;
                hero.MagicPower += trinket.Intellect;
                hero.ManaRegen += trinket.Spirit;
                hero.MaxHP += trinket.Stamina * 5;
                hero.AttackPower += trinket.Strength;
            }
        }
    }
}
