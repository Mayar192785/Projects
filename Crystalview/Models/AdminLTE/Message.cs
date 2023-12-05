namespace Global.Models
{
    public class Message
    {
        public int Id { get; set; }
        public String? UserID { get; set; }
        public String? DisplayName { get; set; }
        public String? FontAwesomeIcon { get; set; }
        public String? AvatarURL { get; set; }
        public String? URLPath { get; set; }
        public String? ShortDesc { get; set; }
        public String? TimeSpan { get; set; }
        public int Percentage { get; set; }
        public String? Type { get; set; }
    }
}
