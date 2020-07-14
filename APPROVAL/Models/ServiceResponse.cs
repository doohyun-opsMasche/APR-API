namespace APPROVAL.Models
{
    public class ServiceResponse<T>
    {
        //public ServiceResponse(bool completed, string message, string errorMsg, string result, T data) 
        //{
        //    this.completed = completed;
        //        this.message = message;
        //        this.errorMsg = errorMsg;
        //        this.result = result;
        //        this.data = data;
               
        //}

        public bool completed { get; set; } = true;
        public string message { get; set; } = null;
        public string errorMsg { get; set; } = null;
        public string result { get; set; } = "ok";
        public T data { get; set; }
    }
}