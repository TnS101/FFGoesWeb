namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Handlers
{
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.Battle;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.Equipment;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.SpellCheck;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.UnitCreation;
    using FinalFantasyTryoutGoesWeb.GameContent.Utilities.Validators.Equipment;
    using FinalFantasyTryoutGoesWeb.GameContent.Utilities.Validators.UnitCreation;

    public class ValidatorHandler
    {
        public ValidatorHandler()
        {
        }

        public ArmorCheck ArmorCheck { get; set; } = new ArmorCheck();

        public FightingClassStatCheck FightingClassStatCheck { get; set; } = new FightingClassStatCheck();

        public FightingClassCheck FightingClassCheck { get; set; } = new FightingClassCheck();

        public RaceCheck RaceCheck { get; set; } = new RaceCheck();

        public SlotCheck SlotCheck { get; set; } = new SlotCheck();

        public SpellCheck SpellCheck { get; set; } = new SpellCheck();

        public TurnCheck TurnCheck { get; set; } = new TurnCheck();

        public WeaponCheck WeaponCheck { get; set; } = new WeaponCheck();
    }
}
