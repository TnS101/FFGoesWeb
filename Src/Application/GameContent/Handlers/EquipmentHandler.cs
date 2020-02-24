namespace FinalFantasyTryoutGoesWeb.Application.GameContent.Handlers
{
    using FinalFantasyTryoutGoesWeb.Application.GameContent.Utilities.EquipmentOptions;

    public class EquipmentHandler
    {
        public EquipmentHandler()
        {
        }

        public EquipOption EquipOption { get; set; } = new EquipOption();

        public UnEquipOption UnEquipOption { get; set; } = new UnEquipOption();
    }
}
