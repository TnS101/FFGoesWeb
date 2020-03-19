using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities.Common;
using System;

namespace Application.CQ.User.Queries
{
    public class UserPartialViewModel : IHaveCustomMappings
    {
        public string UserName { get; set; }

        public int OnlineTime { get; set; } 

        public string Role { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ApplicationUser, UserPartialViewModel>();
        }
    }
}
