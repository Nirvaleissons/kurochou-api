using Kurochou.API.Helpers;
using Kurochou.Domain.DTO.Clips;
using Kurochou.Domain.Interface.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kurochou.API.Controllers;

public class ClipController(IUploadService service) : KuroController
{
        [HttpPost("Upload")]
        public async Task<IResult> UploadAsync([FromForm] UploadRequest request, CancellationToken cancellationToken)
        {
                var result = await service.Upload(request, cancellationToken);
                if (result is null) 
                        return ApiResult.Failure("Unable to upload the clip.");

                return ApiResult.Success(result);
        }
}
