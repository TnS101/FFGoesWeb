namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Handlers
{
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.BattleOptions;
    using FinalFantasyTryoutGoesWeb.Domain.GameContent.Utilities.Validators.Battle;

    public class BattleHandler
    {
        public BattleHandler()
        {
        }

        public AttackOption AttackOption { get; set; } = new AttackOption();

        public DefendOption DefendOption { get; set; } = new DefendOption();

        public EndOption EndOption { get; set; } = new EndOption();

        public EscapeOption EscapeOption { get; set; } = new EscapeOption();

        public RegenerateOption RegenerateOption { get; set; } = new RegenerateOption();

        public SpellCastOption SpellCastOption { get; set; } = new SpellCastOption();

        public TurnCheck TurnCheck { get; set; } = new TurnCheck();
    }
}
