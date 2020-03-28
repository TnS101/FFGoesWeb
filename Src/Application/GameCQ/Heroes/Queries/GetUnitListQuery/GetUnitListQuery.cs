﻿namespace Application.GameCQ.Heroes.Queries.GetUnitListQuery
{
    using System.Security.Claims;
    using MediatR;

    public class GetUnitListQuery : IRequest<UnitListViewModel>
    {
        public ClaimsPrincipal User { get; set; }
    }
}
