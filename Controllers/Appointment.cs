using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Controllers
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
