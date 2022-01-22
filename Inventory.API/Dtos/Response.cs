namespace Inventory.API.Dtos
{
    public abstract class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }

    public class SuccessResponse<T> : Response<T>
    {
        public SuccessResponse()
        {
            Status = true;
        }
    }

    public class FailureResponse<T> : Response<T>
    {
        public FailureResponse()
        {
            Status = false;
        }
    }
}
