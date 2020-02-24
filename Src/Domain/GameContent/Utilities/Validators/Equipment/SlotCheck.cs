namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.Equipment
{
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Equipment;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Handlers;
    using System.Collections.Generic;

    public class SlotCheck
    {
        public Item Check(int fightingClassNumber, int slotNumber, List<int> stats, int fightingClassStatNumber, string fightingClassType, string weaponName, ValidatorHandler validatorHandler)
        {
            if (slotNumber == 7)
            {
                Weapon templateWeapon = new Weapon($"{fightingClassType}'s {weaponName}",
                    "Weapon",
                    stats[0],
                     fightingClassType,
                    stats[1],
                    stats[2],
                     stats[3],
                     stats[4],
                    stats[5],
                    stats[6]);

                validatorHandler.WeaponCheck.Check(fightingClassNumber, fightingClassType, weaponName);
                return templateWeapon;
            }
            else if (slotNumber == 8)
            {
                Trinket templateTrinket = new Trinket($"{fightingClassType}'s Trinket",
                     "Trinket",
                    stats[0],
                     fightingClassType,
                    stats[1],
                    stats[2],
                     stats[3],
                     stats[4],
                    stats[5]);

                validatorHandler.FightingClassStatCheck.Check(templateTrinket, fightingClassType, fightingClassStatNumber);
                return templateTrinket;
            }
            else
            {
                Armor templateArmor = new Armor($"{fightingClassType}'s Armor",
                    "Armor",
                    stats[0],
                     fightingClassType,
                    stats[1],
                    stats[2],
                     stats[3],
                     stats[4],
                    stats[5],
                    stats[6],
                    stats[7]);

                validatorHandler.ArmorCheck.Check(templateArmor, slotNumber, fightingClassType, stats[0]);
                validatorHandler.FightingClassStatCheck.Check(templateArmor, fightingClassType, fightingClassStatNumber);

                return templateArmor;
            }
        }
    }
}
