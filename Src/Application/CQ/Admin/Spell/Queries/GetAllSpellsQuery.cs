using Application.GameCQ.Spell.Queries;
using MediatR;

namespace Application.CQ.Admin.Spell.Queries
{
    public class GetAllSpellsQuery : IRequest<SpellListViewModel>
    {
    }
}
