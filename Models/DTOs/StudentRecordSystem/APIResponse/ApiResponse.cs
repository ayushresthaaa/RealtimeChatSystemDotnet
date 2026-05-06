namespace StudentRecordSystem.Models.DTO.APIResponse
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; } = default(T);
    }
}