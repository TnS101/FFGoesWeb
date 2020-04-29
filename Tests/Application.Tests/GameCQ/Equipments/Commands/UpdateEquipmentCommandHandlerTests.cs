using Application.GameCQ.Equipments.Commands.Update;
using Application.Tests.Infrastructure;
using Common;
using Domain.Contracts.Items;
using Domain.Entities.Game.Items;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameCQ.Equipments.Commands
{
    public class UpdateEquipmentCommandHandlerTests : CommandTestBase
    {
        private UpdateEquipmentCommandHandler sut;

        public UpdateEquipmentCommandHandlerTests()
        {
            this.sut = new UpdateEquipmentCommandHandler(context);
            QueryArrangeHelper.AddFightingClasses(context);
            CommandArrangeHelper.GetHeroId(context);
            QueryArrangeHelper.AddWeapons(context);
            QueryArrangeHelper.AddTrinkets(context);
            QueryArrangeHelper.AddArmors(context);
            QueryArrangeHelper.AddEquipments(context);
            QueryArrangeHelper.AddInventory(context);
            QueryArrangeHelper.AddWeaponInventory(context);
            QueryArrangeHelper.AddArmorInventory(context);
            QueryArrangeHelper.AddTrinketInventory(context);
        }

        [Fact]
        public async Task ShouldUpdateEquipment()
        {
            await this.Result("1", "1", "Weapon", "Equip");
            await this.Result("1", "1", "Armor", "Equip");
            await this.Result("1", "1", "Trinket", "Equip");

            await this.EquipResult("1", "2", "Weapon", "Equip");
            await this.EquipResult("1", "2", "Armor", "Equip");
            await this.EquipResult("1", "2", "Trinket", "Equip");

            QueryArrangeHelper.AddWeaponEquipment(context);
            QueryArrangeHelper.AddArmorEquipments(context);
            QueryArrangeHelper.AddTrinketEquipment(context);

            await this.EquipResult("1", "4", "Weapon", "UnEquip");
            await this.EquipResult("1", "4", "Armor", "UnEquip");
            await this.EquipResult("1", "4", "Trinket", "UnEquip");

            await this.Result("1", "3", "Weapon", "UnEquip");
            await this.Result("1", "3", "Armor", "UnEquip");
            await this.Result("1", "3", "Trinket", "UnEquip");
        }

        private async Task Result(string heroId, string itemId, string slot, string command)
        {
            string result = await this.sut.Handle(new UpdateEquipmentCommand { HeroId = heroId, ItemId = itemId, Slot = slot, Command = command }, CancellationToken.None);

            result.ShouldBe(string.Format(GConst.EquipmentCommandRedirect, heroId, slot));
        }

        private async Task EquipResult(string heroId, string itemId, string slot, string command)
        {
            var result = await this.sut.EquipableItem(new UpdateEquipmentCommand { HeroId = heroId, ItemId = itemId, Slot = slot, Command = command });

            if (slot == "Weapon")
            {
                result.ShouldBeOfType<Weapon>();
            }
            else if (slot == "Trinket")
            {
                result.ShouldBeOfType<Trinket>();
            }
            else
            {
                result.ShouldBeOfType<Armor>();
            }
        }
    }
}
