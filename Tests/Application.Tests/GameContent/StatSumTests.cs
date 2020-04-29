using Application.GameContent.Utilities.FightingClassUtilites;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameContent
{
    public class StatSumTests : CommandTestBase
    {
        private readonly StatSum statSum;

        public StatSumTests()
        {
            CommandArrangeHelper.GetHeroId(context);
            CommandArrangeHelper.GetEquipementId(context);
            CommandArrangeHelper.GetArmorId(context);
            CommandArrangeHelper.GetWeaponId(context);
            CommandArrangeHelper.GetTrinketId(context);

            CommandArrangeHelper.GetArmorEquipmentIds(context);
            CommandArrangeHelper.GetWeaponEquipmentIds(context);
            CommandArrangeHelper.GetTrinketEquipmentIds(context);
            this.statSum = new StatSum();
        }

        [Fact]
        public async Task ShouldSum()
        {
            var hero = context.Heroes.FirstOrDefault();
            var equipment = context.Equipments.FirstOrDefault();
            var armor = context.Armors.FirstOrDefault();
            var weapon = context.Weapons.FirstOrDefault();
            var trinket = context.Trinkets.FirstOrDefault();

            await this.statSum.Sum(hero, context, equipment);

            hero.MaxHP.ShouldBe(hero.MaxHP);
            hero.AttackPower.ShouldBe(hero.AttackPower);
            hero.MagicPower.ShouldBe(hero.MagicPower );
            hero.ManaRegen.ShouldBe(hero.ManaRegen);
            hero.ArmorValue.ShouldBe(hero.ArmorValue);
            hero.ResistanceValue.ShouldBe(hero.ResistanceValue);
        }
    }
}
