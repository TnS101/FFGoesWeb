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
                    Inventory = await this.Context.Weapons.ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
                };
            }
            else if (request.Slot == "Armor")
            {
                return new ItemListViewModel
                {
                    Inventory = await this.Context.Armors.ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
                };
            }
            else if (request.Slot == "Trinket")
            {
                return new ItemListViewModel
                {
                    Inventory = await this.Context.Trinkets.ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
                };
            }
            else if (request.Slot == "LootBox")
            {
                return new ItemListViewModel
                {
                    Inventory = await this.Context.LootBoxes.Select(t => new ItemMinViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Slot = t.Slot,
                        ImagePath = t.ImagePath,
                    }).ToArrayAsync(),
                };
            }
            else if (request.Slot == "Loot Key")
            {
                return new ItemListViewModel
                {
                    Inventory = await this.Context.LootKeys.Select(tk => new ItemMinViewModel
                    {
                        Id = tk.Id,
                        Name = tk.Name,
                        Slot = tk.Slot,
                        ImagePath = tk.ImagePath,
                    }).ToArrayAsync(),
                };
            }
            else if (request.Slot == "Material")
            {
                return new ItemListViewModel
                {
                    Inventory = await this.Context.Materials.Select(m => new ItemMinViewModel
                    {
                        Id = m.Id,
                        Name = m.Name,
                        Slot = m.Slot,
                        ImagePath = m.ImagePath,
                    }).ToArrayAsync(),
                };
            }
            else if (request.Slot == "Tool")
            {
                return new ItemListViewModel
                {
                    Inventory = await this.Context.Tools.Select(t => new ItemMinViewModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Slot = t.Slot,
                        ImagePath = t.ImagePath,
                    }).ToArrayAsync(),
                };
            }
            else
            {
                return new ItemListViewModel
                {
                    Inventory = await this.Context.Armors.ProjectTo<ItemMinViewModel>(this.Mapper.ConfigurationProvider).ToArrayAsync(),
                };
            }
        }
    }
}
