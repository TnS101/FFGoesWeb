namespace Application.GameContent.Handlers
{
    using Application.GameContent.Utilities.EquipmentOptions;

    public class EquipmentHandler
    {
        public EquipmentHandler()
        {
        }

        public EquipOption EquipOption { get; set; } = new EquipOption();

        public UnEquipOption UnEquipOption { get; set; } = new UnEquipOption();
    }
}
