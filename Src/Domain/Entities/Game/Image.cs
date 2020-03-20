namespace Domain.Entities.Game
{
    using System;

    public class Image 
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        public string Path { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string IconURL { get; set; }
    }
}
