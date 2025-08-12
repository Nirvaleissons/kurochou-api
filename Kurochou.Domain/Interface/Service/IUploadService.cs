using Kurochou.Domain.DTO.Clips;

namespace Kurochou.Domain.Interface.Service;

public interface IUploadService
{
        Task<string> Upload(UploadRequest request, CancellationToken cancellationToken);
}
