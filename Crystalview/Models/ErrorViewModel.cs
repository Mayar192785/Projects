using Newtonsoft.Json;
namespace Global.Models
{
    public class ErrorViewModel
    {
        public String? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }



    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public String? Message { get; set; }


        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
