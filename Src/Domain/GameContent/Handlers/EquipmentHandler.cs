namespace FinalFantasyTryoutGoesWeb.Domain.GameContent.Handlers
{
    using FinalFantasyTryoutGoesWeb.GameContent.Utilities.EquipmentOptions;

    public class EquipmentHandler
    {
        public EquipmentHandler()
        {
        }

        public EquipOption EquipOption { get; set; } = new EquipOption();

        public UnEquipOption UnEquipOption { get; set; } = new UnEquipOption();
    }
}
