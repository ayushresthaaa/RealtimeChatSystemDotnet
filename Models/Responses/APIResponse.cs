namespace MessagingPlatformBackend.Models.Responses
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set;}
        public List<string>? Errors { get; set; }

        public static APIResponse<T> SucessResponse(T data, string message = "Sucess")
        {
            return new APIResponse<T>
            {
                Success = true,
                Message = message,
                Data = data
            };
        }

    }
}