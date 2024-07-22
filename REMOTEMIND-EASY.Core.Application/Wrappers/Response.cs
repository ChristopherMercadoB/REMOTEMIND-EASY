namespace REMOTEMIND_EASY.Core.Application.Wrappers
{
    public class Response<T>
    {
        public bool Succeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }

        public Response()
        {
            
        }

        public Response(T Data, string message = null)
        {
            this.Data = Data;
            Succeded = true;
            this.Message = message;
        }

        public Response(string message)
        {
            Succeded = false;
            this.Message = message;
        }
    }
}
