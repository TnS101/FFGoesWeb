using Application.GameContent.Utilities.EquipmentOptions;
using Application.GameContent.Utilities.FightingClassUtilites;
using Application.Tests.Infrastructure;
using Common;
using Domain.Contracts.Items;
using Domain.Entities.Game.Items;
using Domain.Entities.Game.Units;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameContent
{
    public class EquipOptionTests : CommandTestBase
    {
        private readonly EquipOption equipOption;
        private readonly StatSum statSum;

        public EquipOptionTests()
        {
            CommandArrangeHelper.GetHeroId(context);
            CommandArrangeHelper.GetEquipementId(context);
            CommandArrangeHelper.GetInventoryId(context);
            CommandArrangeHelper.GetWeaponId(context);
            CommandArrangeHelper.GetArmorId(context);
            CommandArrangeHelper.GetTrinketId(context);

            this.equipOption = new EquipOption();
            this.statSum = new StatSum();
        }

        [Fact]
        public async Task ShouldEquipItem()
        {
            var hero = this.context.Heroes.FirstOrDefault();
            var weapon = this.context.Weapons.FirstOrDefault();
            var chestPlate = this.context.Armors.FirstOrDefault();
            var trinket = this.context.Trinkets.FirstOrDefault();

            await this.Result(hero, weapon, chestPlate, trinket);

            this.UpdateItem(weapon, "Weapon");
            this.UpdateItem(chestPlate, "Chestplate");
            this.UpdateItem(trinket, "Trinket");

            await this.Result(hero, weapon, chestPlate, trinket);
        }

        private async Task Result(Hero hero, Weapon weapon, Armor armor, Trinket trinket)
        {
            await this.EquipResult(hero, weapon);
            await this.EquipResult(hero, armor);
            await this.EquipResult(hero, trinket);
        }

        private async Task EquipResult(Hero hero, IEquipableItem item)
        {
            var result = await this.equipOption.Equip(hero, item, this.statSum, context);

            if (item.ClassType != "Any" && hero.ClassType != item.ClassType)
            {
                result.ShouldBe(GConst.ErrorRedirect);
            }
            else
            {
                if (item.Slot != "Trinket" && item.Slot != "Weapon")
                {
                    result.ShouldBe(string.Format(GConst.EquipmentCommandRedirect, hero.Id, "Armor"));
                }
                else
                {
                    result.ShouldBe(string.Format(GConst.EquipmentCommandRedirect, hero.Id, item.Slot));
                }
            }
        }

        private void UpdateItem(IEquipableItem item, string slot)
        {
            item.ClassType = "Warrior";
            var heroEquipment = this.context.Equipments.FirstOrDefault();

            if (slot == "Weapon")
            {
                heroEquipment.WeaponSlot = false;
                context.Equipments.Update(heroEquipment);
                context.Weapons.Update((Weapon)item);

                heroEquipment.WeaponSlot.ShouldBeFalse();
            }
            else if (slot == "Trinket")
            {
                heroEquipment.TrinketSlot = false;
                context.Equipments.Update(heroEquipment);
                context.Trinkets.Update((Trinket)item);

                heroEquipment.TrinketSlot.ShouldBeFalse();
            }
            else
            {
                heroEquipment.ChestplateSlot = false;
                context.Equipments.Update(heroEquipment);

                context.Armors.Update((Armor)item);
                heroEquipment.ChestplateSlot.ShouldBeFalse();
            }

            this.UpdateEquipment(slot);

            context.SaveChanges();
        }

        private void UpdateEquipment(string slot)
        {
            if (slot == "Weapon")
            {
                CommandArrangeHelper.GetWeaponInventoryIds(context);
                var weaponInventory = this.context.WeaponsInventories.FirstOrDefault();
                weaponInventory.Count.ShouldBe(2);
            }
            else if (slot == "Trinket")
            {
                CommandArrangeHelper.GetTrinketInventoryIds(context);
                var trinketInventory = this.context.TrinketsInventories.FirstOrDefault();

                trinketInventory.Count.ShouldBe(2);
            }
            else
            {
                CommandArrangeHelper.GetArmorInventoryIds(context);
                var armorInventory = this.context.ArmorsInventories.FirstOrDefault();

                armorInventory.Count.ShouldBe(2);
            }
        }
    }
}
