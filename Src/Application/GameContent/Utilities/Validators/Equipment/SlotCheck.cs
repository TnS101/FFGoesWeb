namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.Equipment
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Equipment;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers;
    using FinalFantasyTryoutGoesWeb.Domain.Entities;

    public class SlotCheck
    {
        public Item Check(int fightingClassNumber, int slotNumber, int regularStatNumber, int fightingClassStatNumber, string fightingClassType, string weaponName, ValidatorHandler validatorHandler)
        {
            if (slotNumber == 7)
            {
                Weapon templateWeapon = new Weapon($"{fightingClassType}'s {weaponName}",
                    "Weapon",
                    regularStatNumber,
                     fightingClassType,
                    regularStatNumber,
                    regularStatNumber,
                     regularStatNumber,
                     regularStatNumber,
                    regularStatNumber,
                    regularStatNumber);

                validatorHandler.WeaponCheck.Check(fightingClassNumber, fightingClassType, weaponName);
                return templateWeapon;
            }
            else if (slotNumber == 8)
            {
                Trinket templateTrinket = new Trinket($"{fightingClassType}'s Trinket",
                     "Trinket",
                    regularStatNumber,
                     fightingClassType,
                     regularStatNumber,
                     regularStatNumber,
                    regularStatNumber,
                     regularStatNumber,
                     regularStatNumber);

                validatorHandler.FightingClassStatCheck.Check(templateTrinket, fightingClassType, fightingClassStatNumber);
                return templateTrinket;
            }
            else
            {
                Armor templateArmor = new Armor($"{fightingClassType}'s Armor",
                    "Armor",
                    regularStatNumber,
                     fightingClassType,
                     regularStatNumber,
                     regularStatNumber,
                    regularStatNumber,
                     regularStatNumber,
                     regularStatNumber,
                     regularStatNumber,
                     regularStatNumber);

                validatorHandler.ArmorCheck.Check(templateArmor, slotNumber, fightingClassType, regularStatNumber);
                validatorHandler.FightingClassStatCheck.Check(templateArmor, fightingClassType, fightingClassStatNumber);

                return templateArmor;
            }
        }
    }
}
