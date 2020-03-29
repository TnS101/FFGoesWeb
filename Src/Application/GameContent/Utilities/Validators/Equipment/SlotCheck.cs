namespace Application.GameContent.Utilities.Validators.Equipment
{
    using System.Linq;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameContent.Handlers;
    using Domain.Entities.Game.Items;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using Domain.Entities.Game.Units;

    public class SlotCheck
    {
        public SlotCheck()
        {
        }

        public async Task Check(int fightingClassNumber, int slotNumber, int[] stats, int fightingClassStatNumber, string fightingClassType, string weaponName, ValidatorHandler validatorHandler, IFFDbContext context, Hero hero)
        {
            if (slotNumber == 7)
            {
                Weapon templateWeapon = new Weapon
                {
                    Name = $"{fightingClassType}'s {weaponName}",
                    AttackPower = stats[0],
                    ClassType = fightingClassType,
                    Agility = stats[1],
                    Stamina = stats[2],
                    Strength = stats[3],
                    Level = stats[4],
                    Intellect = stats[5],
                    Spirit = stats[6],
                };

                validatorHandler.WeaponCheck.Check(fightingClassNumber, fightingClassType, weaponName);

                await context.Weapons.AddAsync(templateWeapon);

                context.WeaponsInventories.Where(w => w.InventoryId == hero.InventoryId).ToList().Add(new WeaponInventory
                {
                    InventoryId = hero.InventoryId,
                    WeaponId = templateWeapon.Id,
                });
            }
            else if (slotNumber == 8)
            {
                Trinket templateTrinket = new Trinket
                {
                    Name = $"{fightingClassType}'s Trinket",
                    Strength = stats[0],
                    ClassType = fightingClassType,
                    Stamina = stats[1],
                    Intellect = stats[2],
                    Spirit = stats[3],
                    Agility = stats[4],
                    Level = stats[5],
                };
                validatorHandler.FightingClassStatCheck.Check(templateTrinket, fightingClassType, fightingClassStatNumber);

                await context.Trinkets.AddAsync(templateTrinket);

                context.TrinketsInventories.Where(t => t.InventoryId == hero.InventoryId).ToList().Add(new TrinketInventory
                {
                    InventoryId = hero.InventoryId,
                    TrinketId = templateTrinket.Id,
                });
            }
            else
            {
                Armor templateArmor = new Armor
                {
                    Name = $"{fightingClassType}'s Armor",
                    ArmorValue = stats[0],
                    ClassType = fightingClassType,
                    RessistanceValue = stats[1],
                    Level = stats[2],
                    Spirit = stats[3],
                    Strength = stats[4],
                    Stamina = stats[5],
                    Agility = stats[6],
                    Intellect = stats[7],
                };

                validatorHandler.ArmorCheck.Check(templateArmor, slotNumber, fightingClassType, stats[0]);
                validatorHandler.FightingClassStatCheck.Check(templateArmor, fightingClassType, fightingClassStatNumber);

                await context.Armors.AddAsync(templateArmor);

                context.ArmorsInventories.Where(t => t.InventoryId == hero.InventoryId).ToList().Add(new ArmorInventory
                {
                    InventoryId = hero.InventoryId,
                    ArmorId = templateArmor.Id,
                });
            }
        }
    }
}
