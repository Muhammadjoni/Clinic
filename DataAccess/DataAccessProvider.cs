using System;
using System.Collections.Generic;
using System.Linq;
using Clinic.Models;

namespace Clinic.DataAccess
{
  public class DataAccessProvider : IDataAccessProvider

  {
    private readonly ClinicContext _context ;

    public DataAccessProvider(ClinicContext context)
    {
      _context = context ;
    }

    List<User> IDataAccessProvider.GetUserRecords => throw new NotImplementedException();

    User IDataAccessProvider.GetUserSingleRecord(int id)
    {
      throw new NotImplementedException();
    }
    void IDataAccessProvider.AddUserRecord(User user)
    {
      throw new NotImplementedException();
    }

    void IDataAccessProvider.DeleteUserRecord(int id)
    {
      throw new NotImplementedException();
    }

    void IDataAccessProvider.UpdateUserRecord(User user)
    {
      throw new NotImplementedException();
    }

    // public void AddUserRecord(User user)
    // {
    //   _context.Users.Add(user);
    //   _context.SaveChanges();
    // }

    // public void UpdateUserRecord(User user)
    // {
    //   _context.Users.Update(user);
    //   _context.SaveChanges();
    // }

    // public void DeleteUserRecord(string id)
    // {
    //   var entity = _context.Users.FirstOrDefault(t => t.id == id );
    //   _context.Users.Remove(entity);
    //   _context.SaveChanges();
    // }
    // public List<User> IDataAccessProvider.UserRecords()
    // {
    //   _context.Users.ToList();
    // }

    // public User GetUserSingleRecord(int id) => _context.Users.FirstOrDefault(t => t.id == id);

  }
}
