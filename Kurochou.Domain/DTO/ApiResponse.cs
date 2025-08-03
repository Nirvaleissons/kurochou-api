namespace Kurochou.Domain.DTO;

public class ApiResponse<T>
{
        public T? Data { get; init; }
        public string Message { get; init; } = string.Empty;
        public int Status { get; init; }
}
