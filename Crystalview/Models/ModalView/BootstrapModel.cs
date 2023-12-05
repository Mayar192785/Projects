namespace Global.Models
{
    public class BootstrapModel
    {
        public String? ID { get; set; }
        public String? AreaLabeledId { get; set; }
        public ModalSize Size { get; set; }
        public String? Message { get; set; }

        public String? ModelClass { get; set; }
        public String? ModalSizeClass
        {
            get
            {
                switch (this.Size)
                {
                    case ModalSize.Small:
                        return "modal-sm";
                    case ModalSize.Large:
                        return "modal-lg";
                    case ModalSize.Medium:
                    default:
                        return "";
                }
            }
        }
    }
}