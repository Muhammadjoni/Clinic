// using Clinic.Models;

namespace Clinic.Response
{
  public class SuccessResponse<T>
  {
    public string StatusMessage = ResponseContent.Success;
    public T ResultData { get; set; }
  }
}
