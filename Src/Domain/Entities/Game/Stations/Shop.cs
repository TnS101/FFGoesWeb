using System;

namespace Domain.Entities.Game.Stations
{
    public class Shop
    {
        public Shop()
        {

        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? SaleStart { get; set; }

        public int SaleDuration { get; set; }
    }
}
