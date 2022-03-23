using System;

namespace Clinic.Response
{
  public class FailedResponse
  {
    public string StatusMessage { get; set; }
    public Exception Error { get; set; }
  }
}
