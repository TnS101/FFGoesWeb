namespace Application.CQ.Admin.GameContent.Items.Commands.Delete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using global::Common;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, string>
    {
        private readonly IFFDbContext context;

        public DeleteItemCommandHandler(IFFDbContext context)
        {
            this.context = context;
        }

        public async Task<string> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            if (request.Slot == "Weapon")
            {
                var weapon = await this.context.Weapons.FindAsync(request.ItemId);
                var equipments = await this.context.WeaponsEquipments.Where(e => e.WeaponId == weapon.Id).ToListAsync();
                var inventories = await this.context.WeaponsInventories.Where(i => i.WeaponId == weapon.Id).ToListAsync();
                this.context.WeaponsEquipments.RemoveRange(equipments);
                this.context.WeaponsInventories.RemoveRange(inventories);
                this.context.Weapons.Remove(weapon);
            }

            if (request.Slot == "Armor")
            {
                var armor = await this.context.Armors.FindAsync(request.ItemId);
                var equipments = await this.context.ArmorsEquipments.Where(e => e.ArmorId == armor.Id).ToListAsync();
                var inventories = await this.context.ArmorsInventories.Where(i => i.ArmorId == armor.Id).ToListAsync();
                this.context.ArmorsEquipments.RemoveRange(equipments);
                this.context.ArmorsInventories.RemoveRange(inventories);
                this.context.Armors.Remove(armor);
            }

            if (request.Slot == "Trinket")
            {
                var trinket = await this.context.Trinkets.FindAsync(request.ItemId);
                var equipments = await this.context.TrinketEquipments.Where(e => e.TrinketId == trinket.Id).ToListAsync();
                var inventories = await this.context.TrinketsInventories.Where(i => i.TrinketId == trinket.Id).ToListAsync();
                this.context.TrinketEquipments.RemoveRange(equipments);
                this.context.TrinketsInventories.RemoveRange(inventories);
                this.context.Trinkets.Remove(trinket);
            }

            if (request.Slot == "Material")
            {
                var material = await this.context.Materials.FindAsync(int.Parse(request.ItemId));
                var inventories = await this.context.MaterialsInventories.Where(e => e.MaterialId == material.Id).ToListAsync();
                this.context.MaterialsInventories.RemoveRange(inventories);
                this.context.Materials.Remove(material);
            }

            if (request.Slot == "Treasure")
            {
                var treasure = await this.context.Treasures.FindAsync(int.Parse(request.ItemId));
                var inventories = await this.context.TreasuresInventories.Where(e => e.TreasureId == treasure.Id).ToListAsync();
                this.context.TreasuresInventories.RemoveRange(inventories);
                this.context.Treasures.Remove(treasure);
            }

            if (request.Slot == "Treasure Key")
            {
                var treasureKey = await this.context.TreasureKeys.FindAsync(int.Parse(request.ItemId));
                var inventories = await this.context.TreasureKeysInventories.Where(e => e.TreasureKeyId == treasureKey.Id).ToListAsync();
                this.context.TreasureKeysInventories.RemoveRange(inventories);
                this.context.TreasureKeys.Remove(treasureKey);
            }

            if (request.Slot == "Tool")
            {
                var tool = await this.context.Tools.FindAsync(int.Parse(request.ItemId));
                var inventories = await this.context.ToolsInventories.Where(e => e.ToolId == tool.Id).ToListAsync();
                this.context.ToolsInventories.RemoveRange(inventories);
                this.context.Tools.Remove(tool);
            }

            await this.context.SaveChangesAsync(cancellationToken);

            return string.Format(GConst.AdminItemCommandRedirect, request.Slot);
        }
    }
}
