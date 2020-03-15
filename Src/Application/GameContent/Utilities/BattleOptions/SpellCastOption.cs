namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.BattleOptions
{
    using FinalFantasyTryoutGoesWeb.Application.Common.Interfaces;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.EnemySpellRepository;
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Repositories.PlayerSpellRepository;
    using FinalFantasyTryoutGoesWeb.Domain.Entities.Game;
    using global::Application.GameCQ.Unit.Queries;
    using System;
    using System.Linq;

    public class SpellCastOption
    {
        public void PlayerSpellCast(UnitFullViewModel caster, UnitFullViewModel target, string spellName, IFFDbContext context)
        {
            Type type = typeof(PlayerSpellRepos);
            var instance = Activator.CreateInstance(type);

            if (context.Spells.Where(s => s.ClassType == caster.ClassType).Any(s => s.ManaRequirment <= caster.MaxMana))
            {
                var spellMethod = type.GetMethods().Where(m => m.Name.Split('_')[0] == caster.ClassType && m.IsPrivate).FirstOrDefault(m => m.Name.Split('_')[1] == spellName);
                spellMethod.Invoke(instance, new object[] { caster, target });
            }

            if (target.CurrentHP <= 0)
            {
                target.CurrentHP = 0;
            }
        }

        public void EnemySpellCast(UnitFullViewModel caster, UnitFullViewModel target, IFFDbContext context)
        {
            Random rng = new Random();
            Type type = typeof(EnemySpellRepos);
            var instance = Activator.CreateInstance(type);
            int spellNumber = rng.Next(0, 4);

            if (context.Spells.Where(s => s.ClassType == caster.ClassType).Any(s => s.ManaRequirment <= caster.MaxMana))
            {
                var spellMethod = type.GetMethods().Where(m => m.Name.Split('_')[0] == caster.ClassType && m.IsPrivate).ToList()[spellNumber];
                spellMethod.Invoke(instance, new object[] { caster, target });
            }
            if (target.CurrentHP <= 0)
            {
                target.CurrentHP = 0;
            }
        }
    }
}
