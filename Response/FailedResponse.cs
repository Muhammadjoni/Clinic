using System;

namespace Clinic.Response
{
  public class FailedResponseContent
  {
    public string StatusMessage { get; set; }
    public Exception Error { get; set; }
  }
}
