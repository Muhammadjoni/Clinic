using Clinic.Models;

namespace Clinic.Exceptions
{
  public class SuccessResponseContent<T>
  {
    public string StatusMessage = ResponseContentStatusMessages.Success;
    public T ResultData { get; set; }
  }
}
