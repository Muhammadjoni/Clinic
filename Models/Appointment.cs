using System;

namespace Clinic.Models
{
  public class Appointment
  {
    public int Id { get; set; }
    public int AppointmentDuration { get; set; }
    public int  Rooom { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
  }
}
