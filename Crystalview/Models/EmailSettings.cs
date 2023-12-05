namespace Global.Models
{
    public class EmailSettings
    {
        public String? MailServer { get; set; }
        public int MailPort { get; set; }
        public String? SenderName { get; set; }
        public String? Sender { get; set; }
        public String? Password { get; set; }
    }
}
