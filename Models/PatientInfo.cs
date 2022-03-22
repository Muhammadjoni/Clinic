using System.Collections.Generic;

namespace Clinic.Models
{
  public class PatientInfo
  {
    public string Id { get; set; }
    public List<Appointment> History {get; set; }
  }
}
