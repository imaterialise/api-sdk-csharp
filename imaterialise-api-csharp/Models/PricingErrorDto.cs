namespace imaterialise.Models
{
    public class PricingErrorDto
    {
        public PricingErrorDto()
        {
        }
        public PricingErrorDto(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public string Message { get; set; }

        public int Code { get; set; }
    }
}