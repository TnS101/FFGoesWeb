﻿namespace Application.CQ.Admin.GameContent.Items.Queries.GetAllItemsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Interfaces;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, ItemListViewModel>
    {
        private readonly IFFDbContext context;
        private readonly IMapper mapper;

        public GetAllItemsQueryHandler(IFFDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<ItemListViewModel> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            if (request.Slot == "Weapon")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Weapons.ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Armor")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Armors.ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Trinket")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Trinkets.ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Treasure")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Treasures.Select(t => new ItemMinViewModel
                    {
                        Id = t.Id.ToString(),
                        Name = t.Name,
                        Slot = t.Slot,
                        ImagePath = t.ImagePath,
                    }).ToListAsync(),
                };
            }
            else if (request.Slot == "Treasure Key")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.TreasureKeys.Select(tk => new ItemMinViewModel
                    {
                        Id = tk.Id.ToString(),
                        Name = tk.Name,
                        Slot = tk.Slot,
                        ImagePath = tk.ImagePath,
                    }).ToListAsync(),
                };
            }
            else if (request.Slot == "Material")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Materials.Select(m => new ItemMinViewModel
                    {
                        Id = m.Id.ToString(),
                        Name = m.Name,
                        Slot = m.Slot,
                        ImagePath = m.ImagePath,
                    }).ToListAsync(),
                };
            }
            else if (request.Slot == "Tool")
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Tools.Select(t => new ItemMinViewModel
                    {
                        Id = t.Id.ToString(),
                        Name = t.Name,
                        Slot = t.Slot,
                        ImagePath = t.ImagePath,
                    }).ToListAsync(),
                };
            }
            else
            {
                return new ItemListViewModel
                {
                    Items = await this.context.Armors.ProjectTo<ItemMinViewModel>(this.mapper.ConfigurationProvider).ToListAsync(),
                };
            }
        }
    }
}
