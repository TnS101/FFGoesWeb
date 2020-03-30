﻿namespace Domain.Entities.Game.Items
{
    using Domain.Contracts.Items.AdditionalTypes;
    using Domain.Entities.Game.Items.ManyToMany.Inventories;
    using System;
    using System.Collections.Generic;

    public class Treasure : ITreasure
    {
        public Treasure()
        {
            this.TreasureInventories = new HashSet<TreasureInventory>();
            this.Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }

        public string Name { get; set; }

        public string Rarity { get; set; }

        public int Reward { get; set; }

        public string ImageURL { get; set; }

        public ICollection<TreasureInventory> TreasureInventories { get; set; }
    }
}
