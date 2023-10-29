namespace Backend.Models
{
    public class BaseResponse
    {
        public int Status { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
    }
}
