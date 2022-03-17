using System.Collections.Generic;
using Clinic.Models;

namespace Clinic.DataAccess
{
  public interface IDataAccessProvider
  {
    void AddUserRecord(User user);
    void UpdateUserRecord(User user);
    void DeleteUserRecord(string id);
    User GetUserSingleRecord(string id);
    List<User> UserRecords { get; }
  }
}
