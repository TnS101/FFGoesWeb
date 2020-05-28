namespace Application.GameContent.Utilities.FightingClassUtilites
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Units;
    using Microsoft.EntityFrameworkCore;

    public class StatSum
    {
        public StatSum()
        {
        }

        public async Task Sum(Hero hero, IFFDbContext context, Equipment heroEquipment)
        {
            var armorEquipment = await context.ArmorsEquipments.Where(ae => ae.EquipmentId == hero.EquipmentId).ToListAsync();

            if (armorEquipment.Count() > 0)
            {
                var items = new HashSet<Armor>();

                foreach (var armor in context.Armors)
                {
                    foreach (var equipment in armorEquipment)
                    {
                        if (armor.Id == equipment.ArmorId)
                        {
                            items.Add(armor);
                        }
                    }
                }

                foreach (var item in items)
                {
                    hero.AttackPower += item.Agility * 1.3;
                    hero.MagicPower += item.Intellect * 1.8;
                    hero.ManaRegen += item.Spirit * 1.2;
                    hero.MaxHP += item.Stamina * 5;
                    hero.AttackPower += item.Strength * 1.5;
                    hero.ArmorValue += item.ArmorValue;
                    hero.ResistanceValue += item.ResistanceValue;
                }
            }

            if (heroEquipment.WeaponSlot)
            {
                var weaponEquipment = await context.WeaponsEquipments.FirstOrDefaultAsync(w => w.EquipmentId == heroEquipment.Id);

                var weapon = await context.Weapons.FindAsync(weaponEquipment.WeaponId);

                hero.AttackPower += weapon.AttackPower;
                hero.AttackPower += weapon.Agility * 1.3;
                hero.MagicPower += weapon.Intellect * 1.8;
                hero.ManaRegen += weapon.Spirit * 1.2;
                hero.MaxHP += weapon.Stamina * 5;
                hero.AttackPower += weapon.Strength * 1.5;
            }

            if (heroEquipment.TrinketSlot)
            {
                var trinketEquipment = await context.TrinketEquipments.FirstOrDefaultAsync(t => t.EquipmentId == heroEquipment.Id);

                var trinket = await context.Trinkets.FindAsync(trinketEquipment.TrinketId);

                hero.AttackPower += trinket.Agility * 1.3;
                hero.MagicPower += trinket.Intellect * 1.8;
                hero.ManaRegen += trinket.Spirit * 1.2;
                hero.MaxHP += trinket.Stamina * 5;
                hero.AttackPower += trinket.Strength * 1.5;
            }
        }

        public async Task ReverseSum(Hero hero, IFFDbContext context, ulong itemId, string itemSlot)
        {
            if (itemSlot == "Weapon")
            {
                var weapon = await context.Weapons.FindAsync(itemId);

                hero.AttackPower -= weapon.AttackPower;
                hero.AttackPower -= weapon.Agility * 1.3;
                hero.MagicPower -= weapon.Intellect * 1.8;
                hero.ManaRegen -= weapon.Spirit * 1.2;
                hero.MaxHP -= weapon.Stamina * 5;
                hero.AttackPower -= weapon.Strength * 1.5;
            }
            else if (itemSlot == "Trinket")
            {
                var trinket = await context.Trinkets.FindAsync(itemId);

                hero.AttackPower -= trinket.Agility * 1.3;
                hero.MagicPower -= trinket.Intellect * 1.8;
                hero.ManaRegen -= trinket.Spirit * 1.2;
                hero.MaxHP -= trinket.Stamina * 5;
                hero.AttackPower -= trinket.Strength * 1.5;
            }
            else
            {
                var armor = await context.Armors.FindAsync(itemId);

                hero.AttackPower -= armor.Agility * 1.3;
                hero.MagicPower -= armor.Intellect * 1.8;
                hero.ManaRegen -= armor.Spirit * 1.2;
                hero.MaxHP -= armor.Stamina * 5;
                hero.AttackPower -= armor.Strength * 1.5;
                hero.ArmorValue -= armor.ArmorValue;
                hero.ResistanceValue -= armor.ResistanceValue;
            }
        }
    }
}
