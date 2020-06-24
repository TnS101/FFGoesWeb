namespace Domain.Entities.Game.Stations
{
    using System;

    public class Shop
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime? SaleStart { get; set; }

        public int SaleDuration { get; set; }
    }
}
