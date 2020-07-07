namespace APPROVAL.Models
{
    public class ServiceResponse<T>
    {
        public bool completed { get; set; } = true;
        public string message { get; set; } = null;
        public string errorMsg { get; set; } = null;
        public string result { get; set; } = "ok";
        public T data { get; set; }
    }
}