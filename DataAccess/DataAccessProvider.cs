using System;
using System.Collections.Generic;
using System.Linq;
using Clinic.DataAccess;
using Clinic.Models;

namespace Clinic.DataAccess
{
  public class DataAccessProvider : IDataAccessProvider

  {
    private readonly ClinicDbContext _context ;

    public DataAccessProvider(ClinicDbContext context)
    {
      _context = context ;
    }

    List<User> IDataAccessProvider.GetUserRecords => _context.Users.ToList();

    User IDataAccessProvider.GetUserSingleRecord(int id) => _context.Users.FirstOrDefault(t => t.id == id);
    void IDataAccessProvider.AddUserRecord(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
    }

    void IDataAccessProvider.DeleteUserRecord(int id)
    {
      var entity = _context.Users.FirstOrDefault(t => t.id == id);
      _context.Users.Remove(entity);
      _context.SaveChanges();
    }

    void IDataAccessProvider.UpdateUserRecord(User user)
    {
      _context.Users.Update(user);
      _context.SaveChanges();
    }
  }
}
