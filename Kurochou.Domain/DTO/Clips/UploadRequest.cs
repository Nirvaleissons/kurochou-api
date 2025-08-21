using Microsoft.AspNetCore.Http;

namespace Kurochou.Domain.DTO.Clips;

public record UploadRequest(string Title, string Description, Guid UserId, bool IsPublic, IFormFile FileData, DateTime UploadDate);
