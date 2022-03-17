using System;
using System.Collections.Generic;
using System.Linq;
using PostgreSqlCRUD.Models;

namespace PostgresCRUD.DataAccess
{
  public class DataAccessProvider : IDataAccessProvider
  {
    private readonly PostgreSqlContext _context;

    public List<User> UserRecords => _context.Users.ToList();


    public User GetUserSingleRecord(string id) => _context.Users.FirstOrDefault(t => t.id == id);

    public void AddUserRecord(User user)
    {
      _context.Users.Add(user);
      _context.SaveChanges();
    }

    public void UpdateUserRecord(User user)
    {
      _context.Users.Update(user);
      _context.SaveChanges();
    }

    public void DeleteUserRecord(string id)
    {
      var entity = _context.Users.FirstOrDefault(t => t.id == id );
      _context.Users.Remove(entity);
      _context.SaveChanges();
    }
  }
}
