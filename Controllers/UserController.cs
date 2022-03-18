using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinic.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]

  public class AppointmentController : ControllerBase
  {
    public AppointmentController()
    {
    }
  }
}
