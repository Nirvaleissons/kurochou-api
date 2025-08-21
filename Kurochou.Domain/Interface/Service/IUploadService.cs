using Kurochou.Domain.DTO.Clips;

namespace Kurochou.Domain.Interface.Service;

public interface IUploadService
{
        Task<int> Upload(UploadRequest request, CancellationToken cancellationToken, Guid userId);
}
