namespace Application.GameContent.Utilities.FightingClassUtilites
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Contracts.Items;
    using Domain.Entities.Game.Items;
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
                var items = new Queue<Armor>();

                foreach (var armor in context.Armors)
                {
                    foreach (var armorEquipment in await context.ArmorsEquipments.Where(ai => ai.EquipmentId == hero.EquipmentId).ToListAsync())
                    {
                        if (armor.Id == armorEquipment.ArmorId)
                        {
                            items.Enqueue(armor);
                        }
                    }
                }

                foreach (var item in items)
                {
                    hero.AttackPower += item.Agility;
                    hero.MagicPower += item.Intellect;
                    hero.ManaRegen += item.Spirit;
                    hero.MaxHP += item.Stamina * 5;
                    hero.AttackPower += item.Strength;
                    hero.ArmorValue += item.ArmorValue;
                    hero.ResistanceValue += item.ResistanceValue;
                }
            }

            if (!hero.Equipment.WeaponSlot)
            {
                var weaponEquipment = await context.WeaponsEquipments.FirstOrDefaultAsync(w => w.EquipmentId == hero.EquipmentId);

                var weapon = await context.Weapons.FindAsync(weaponEquipment.WeaponId);

                hero.AttackPower += weapon.AttackPower;
                hero.AttackPower += weapon.Agility;
                hero.MagicPower += weapon.Intellect;
                hero.ManaRegen += weapon.Spirit;
                hero.MaxHP += weapon.Stamina * 5;
                hero.AttackPower += weapon.Strength;
            }

            if (!hero.Equipment.TrinketSlot)
            {
                var trinketEquipment = await context.TrinketEquipments.FirstOrDefaultAsync(t => t.EquipmentId == hero.EquipmentId);

                var trinket = await context.Trinkets.FindAsync(trinketEquipment.TrinketId);

                hero.AttackPower += trinket.Agility;
                hero.MagicPower += trinket.Intellect;
                hero.ManaRegen += trinket.Spirit;
                hero.MaxHP += trinket.Stamina * 5;
                hero.AttackPower += trinket.Strength;
            }
        }
    }
}
