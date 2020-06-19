namespace Application.CQ.Admin.GameContent.Items.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DeleteItemCommandHandler : BaseHandler, IRequestHandler<DeleteItemCommand, string>
    {
        public DeleteItemCommandHandler(IFFDbContext context)
            : base(context)
        {
        }

        public async Task<string> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            if (request.Slot == "Weapon")
            {
                var weapon = await this.Context.Weapons.FindAsync(request.ItemId);
                var equipments = this.Context.WeaponsEquipments.Where(e => e.WeaponId == weapon.Id);
                var inventories = this.Context.WeaponsInventories.Where(i => i.WeaponId == weapon.Id);
                this.Context.WeaponsEquipments.RemoveRange(equipments);
                this.Context.WeaponsInventories.RemoveRange(inventories);
                this.Context.Weapons.Remove(weapon);
            }

            if (request.Slot == "Armor")
            {
                var armor = await this.Context.Armors.FindAsync(request.ItemId);
                var equipments = this.Context.ArmorsEquipments.Where(e => e.ArmorId == armor.Id);
                var inventories = this.Context.ArmorsInventories.Where(i => i.ArmorId == armor.Id);
                this.Context.ArmorsEquipments.RemoveRange(equipments);
                this.Context.ArmorsInventories.RemoveRange(inventories);
                this.Context.Armors.Remove(armor);
            }

            if (request.Slot == "Trinket")
            {
                var trinket = await this.Context.Trinkets.FindAsync(request.ItemId);
                var equipments = this.Context.TrinketEquipments.Where(e => e.TrinketId == trinket.Id);
                var inventories = this.Context.TrinketsInventories.Where(i => i.TrinketId == trinket.Id);
                this.Context.TrinketEquipments.RemoveRange(equipments);
                this.Context.TrinketsInventories.RemoveRange(inventories);
                this.Context.Trinkets.Remove(trinket);
            }

            if (request.Slot == "Material")
            {
                var material = await this.Context.Materials.FindAsync(int.Parse(request.ItemId));
                var inventories = this.Context.MaterialsInventories.Where(e => e.MaterialId == material.Id);
                this.Context.MaterialsInventories.RemoveRange(inventories);
                this.Context.Materials.Remove(material);
            }

            if (request.Slot == "Treasure")
            {
                var treasure = await this.Context.LootBoxes.FindAsync(int.Parse(request.ItemId));
                var inventories = this.Context.LootBoxesInventories.Where(e => e.LootBoxId == treasure.Id);
                this.Context.LootBoxesInventories.RemoveRange(inventories);
                this.Context.LootBoxes.Remove(treasure);
            }

            if (request.Slot == "Treasure Key")
            {
                var treasureKey = await this.Context.LootKeys.FindAsync(int.Parse(request.ItemId));
                var inventories = this.Context.LootKeysInventories.Where(e => e.LootKeyId == treasureKey.Id);
                this.Context.LootKeysInventories.RemoveRange(inventories);
                this.Context.LootKeys.Remove(treasureKey);
            }

            if (request.Slot == "Tool")
            {
                var tool = await this.Context.Tools.FindAsync(int.Parse(request.ItemId));
                var inventories = this.Context.ToolsInventories.Where(e => e.ToolId == tool.Id);
                this.Context.ToolsInventories.RemoveRange(inventories);
                this.Context.Tools.Remove(tool);
            }

            await this.Context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.AdminItemCommandRedirect, request.Slot);
        }
    }
}
