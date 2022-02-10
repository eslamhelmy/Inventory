namespace Inventory.API.Dtos
{
    public abstract class ResponseDto<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }

    public class SuccessResponseDto<T> : ResponseDto<T>
    {
        public SuccessResponseDto()
        {
            Status = true;
        }
    }

    public class FailureResponseDto<T> : ResponseDto<T>
    {
        public FailureResponseDto()
        {
            Status = false;
        }
    }
}
