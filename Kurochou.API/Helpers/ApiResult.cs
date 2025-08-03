using Kurochou.Domain.DTO;

namespace Kurochou.API.Helpers;

public static class ApiResult
{
        public static IResult Success<T>(T data, string message = "Success")
                => Results.Ok(new ApiResponse<T>
                {
                        Data = data,
                        Message = message,
                        Status = 200
                });

        public static IResult Failure(string message, int status = 400)
                => Results.Json(new ApiResponse<string>
                {
                        Data = null,
                        Message = message,
                        Status = status
                }, statusCode: status);
}
