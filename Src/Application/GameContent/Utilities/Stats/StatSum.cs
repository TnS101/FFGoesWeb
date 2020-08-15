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
            await context.ArmorsEquipments.Where(ae => ae.EquipmentId == hero.Id).Select(a => a.Armor).ForEachAsync(a =>
            {
                this.MainStatSum(hero, a, "+");
                hero.ArmorValue += a.ArmorValue;
                hero.ResistanceValue += a.ResistanceValue;
            });

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

            if (heroEquipment.RelicSlot)
            {
                var relicEquipment = await context.RelicsEquipments.FirstOrDefaultAsync(r => r.EquipmentId == heroEquipment.Id);

                var relic = await context.Relics.FindAsync(relicEquipment.RelicId);

                this.MainStatSum(hero, relic, "+");
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
            else if (itemSlot == "Relic")
            {
                var relic = await context.Relics.FindAsync(itemId);

                this.MainStatSum(hero, relic, "-");
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
