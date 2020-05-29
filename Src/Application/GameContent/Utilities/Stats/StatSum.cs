namespace Application.GameContent.Utilities.Stats
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
                    this.MainStatSum(hero, item, "+");

                    hero.ArmorValue += item.ArmorValue;
                    hero.ResistanceValue += item.ResistanceValue;
                }
            }

            if (heroEquipment.WeaponSlot)
            {
                var weaponEquipment = await context.WeaponsEquipments.FirstOrDefaultAsync(w => w.EquipmentId == heroEquipment.Id);

                var weapon = await context.Weapons.FindAsync(weaponEquipment.WeaponId);

                this.MainStatSum(hero, weapon, "+");

                hero.AttackPower += weapon.AttackPower;
            }

            if (heroEquipment.TrinketSlot)
            {
                var trinketEquipment = await context.TrinketEquipments.FirstOrDefaultAsync(t => t.EquipmentId == heroEquipment.Id);

                var trinket = await context.Trinkets.FindAsync(trinketEquipment.TrinketId);

                this.MainStatSum(hero, trinket, "+");
            }
        }

        public async Task ReverseSum(Hero hero, IFFDbContext context, long itemId, string itemSlot)
        {
            if (itemSlot == "Weapon")
            {
                var weapon = await context.Weapons.FindAsync(itemId);

                this.MainStatSum(hero, weapon, "-");

                hero.AttackPower -= weapon.AttackPower;
            }
            else if (itemSlot == "Trinket")
            {
                var trinket = await context.Trinkets.FindAsync(itemId);

                this.MainStatSum(hero, trinket, "-");
            }
            else
            {
                var armor = await context.Armors.FindAsync(itemId);

                this.MainStatSum(hero, armor, "-");

                hero.ArmorValue -= armor.ArmorValue;
                hero.ResistanceValue -= armor.ResistanceValue;
            }
        }

        private void MainStatSum(Hero hero, IEquipableItem item, string operation)
        {
            if (operation == "-")
            {
                hero.AttackPower -= item.Agility * 1.3;
                hero.MagicPower -= item.Intellect * 1.8;
                hero.ManaRegen -= item.Spirit * 1.2;
                hero.MaxHP -= item.Stamina * 5;
                hero.AttackPower -= item.Strength * 1.5;
            }
            else
            {
                hero.AttackPower += item.Agility * 1.3;
                hero.MagicPower += item.Intellect * 1.8;
                hero.ManaRegen += item.Spirit * 1.2;
                hero.MaxHP += item.Stamina * 5;
                hero.AttackPower += item.Strength * 1.5;
            }
        }
    }
}
