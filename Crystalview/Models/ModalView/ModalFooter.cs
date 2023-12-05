namespace Global.Models
{
    public class ModalFooter
    {
        public String? SubmitButtonText { get; set; } = "Submit";
        public String? CancelButtonText { get; set; } = "Cancel";
        public String? SubmitButtonID { get; set; } = "btn-submit";
        public String? CancelButtonID { get; set; } = "btn-cancel";
        public bool OnlyCancelButton { get; set; }

        public String? SubmitButtonIcon { get; set; } = "";
        public String? SubmitButtonClass { get; set; } = "";
        public String? CancelButtonIcon { get; set; } = "far fa-window-close";
    }
}