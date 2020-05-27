namespace Application.CQ.Admin.GameContent.Items.Queries.GetAllItemsQuery
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Common.Handlers;
    using Application.Common.Interfaces;
    using Application.GameCQ.Items.Queries.GetPersonalItemsQuery;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using MediatR;
    using Microsoft.EntityFrameworkCore;

    public class GetAllItemsQueryHandler : MapperHandler, IRequestHandler<GetAllItemsQuery, ItemListViewModel>
    {
        public GetAllItemsQueryHandler(IFFDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }

        public async Task<ItemListViewModel> Handle(GetAllItemsQuery request, CancellationToken cancellationToken)
        {
            if (request.Slot == "Weapon")
            {
                return new ItemListViewModel
                {
                    Items = await this.Context.Weapons.ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Armor")
            {
                return new ItemListViewModel
                {
                    Items = await this.Context.Armors.ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Trinket")
            {
                return new ItemListViewModel
                {
                    Items = await this.Context.Trinkets.ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ToListAsync(),
                };
            }
            else if (request.Slot == "Treasure")
            {
                return new ItemListViewModel
                {
                    Items = await this.Context.Treasures.Select(t => new ItemMinViewModel
                    {
                        Id = (ulong)t.Id,
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
                    Items = await this.Context.TreasureKeys.Select(tk => new ItemMinViewModel
                    {
                        Id = (ulong)tk.Id,
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
                    Items = await this.Context.Materials.Select(m => new ItemMinViewModel
                    {
                        Id = (ulong)m.Id,
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
                    Items = await this.Context.Tools.Select(t => new ItemMinViewModel
                    {
                        Id = (ulong)t.Id,
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
                    Items = await this.Context.Armors.ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ToListAsync(),
                };
            }
        }
    }
}
