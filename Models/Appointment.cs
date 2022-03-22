using System;

namespace Clinic.Models
{
  public class Appointment
  {
    public int Id { get; set; }
    public int AppointmentDuration { get; set; }
    public int  Room { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

  }
}
