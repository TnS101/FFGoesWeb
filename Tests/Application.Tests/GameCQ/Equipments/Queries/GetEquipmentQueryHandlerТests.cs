using Application.GameCQ.Equipments.Queries;
using Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Application.Tests.GameCQ.Equipments.Queries
{
    public class GetEquipmentQueryHandlerТests : QueryTestFixture
    {
        private readonly string heroId;
        private readonly GetEquipmentQueryHandler sut;

        public GetEquipmentQueryHandlerТests()
        {
            this.sut = new GetEquipmentQueryHandler(context, mapper);
            this.heroId = CommandArrangeHelper.GetHeroId(context);
            CommandArrangeHelper.GetWeaponId(context);
            CommandArrangeHelper.GetTrinketId(context);
            QueryArrangeHelper.AddArmors(context);
            QueryArrangeHelper.AddArmorEquipments(context);
            CommandArrangeHelper.GetWeaponEquipmentIds(context);
            CommandArrangeHelper.GetTrinketEquipmentIds(context);
        }

        [Fact]
        public async Task ShouldGetEquipment()
        {
            await this.Result();
        }

        private async Task Result()
        {
            var result = await this.sut.Handle(new GetEquipmentQuery { HeroId = this.heroId }, CancellationToken.None);

            result.ShouldNotBeNull();
            result.ShouldBeOfType<EquipmentViewModel>();

            result.Items.Count.ShouldBe(7);
        }
    }
}
