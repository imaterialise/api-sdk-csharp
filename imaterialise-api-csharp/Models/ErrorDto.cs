
namespace imaterialise.Models
{
    public class ErrorDto
    {
        public ErrorDto()
        {
        }
        public ErrorDto(int code, string message)
        {
            Code = code;
            Message = message;
        }
        public string Message { get; set; }

        public int Code { get; set; }
    }
}