using Kurochou.Domain.DTO.Clips;
using Kurochou.Domain.Interface.Repository;
using Kurochou.Domain.Interface.Service;
using Kurochou.Domain.Model;

namespace Kurochou.Domain.Service;

public class UploadService : IUploadService
{
        private readonly IClipRepository _clipRepository;

        public UploadService(IClipRepository clipRepository)
        {
                _clipRepository = clipRepository;
        }

        public async Task<int> Upload(UploadRequest request, CancellationToken cancellationToken, Guid userId)
        {
                byte[] fileBytes;
                using (MemoryStream ms = new MemoryStream())
                {
                        await request.FileData.CopyToAsync(ms, cancellationToken);
                        fileBytes = ms.ToArray();
                }

                var clip = new Clip()
                {
                        Title = request.Title,
                        Description = request.Description,
                        UserId = userId,
                        Upvote = 0,
                        IsPublic = request.IsPublic,
                        FileData = fileBytes,
                        CreatedAt = DateTime.Now,
                };
                
                var clipId = await  _clipRepository.InsertAsync(clip);
                return clipId;
        }
        
}
