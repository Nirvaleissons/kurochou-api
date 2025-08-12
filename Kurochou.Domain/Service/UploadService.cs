using Kurochou.Domain.DTO.Clips;
using Kurochou.Domain.Interface.Service;

namespace Kurochou.Domain.Service;

public class UploadService : IUploadService
{
        public async Task<string> Upload(UploadRequest request, CancellationToken cancellationToken)
        {
                var sanitizedTitle = string.Concat(request.Title.Split(Path.GetInvalidFileNameChars()));
                var fileName = $"{sanitizedTitle}{Path.GetExtension(request.File.FileName)}";
                var savePath = Path.Combine("Uploads", fileName);

                Directory.CreateDirectory("Uploads");

                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                        await request.File.CopyToAsync(stream, cancellationToken);
                }

                return fileName;
        }
}
