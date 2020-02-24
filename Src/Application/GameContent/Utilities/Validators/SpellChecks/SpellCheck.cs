namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.SpellCheck
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.SpellChecks.Buffs;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.SpellChecks.DamageInfliction;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.SpellChecks.Effects;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.Validators.SpellChecks.MainStats;

    public class SpellCheck
    {
        public SpellCheck()
        {
        }

        public BuffCheck BuffCheck { get; set; }

        public DeBuffCheck DeBuffCheck { get; set; }

        public PhysicalDamageCheck PhysicalDamageCheck { get; set; }

        public SpellDamageCheck SpellDamageCheck { get; set; }

        public NegativeEffectCheck NegativeEffectCheck { get; set; }

        public PositiveEffectCheck PositiveEffectCheck { get; set; }

        public HealCheck HealCheck { get; set; }

        public ManaCheck ManaCheck { get; set; }
    }
}
