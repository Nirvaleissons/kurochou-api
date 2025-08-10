using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kurochou.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize("UserPolicy")]
public class KuroController
{
}