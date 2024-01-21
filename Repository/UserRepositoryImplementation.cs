using WebApiChallenge.Models.Context;
using WebApiChallenge.Models;

namespace WebApiChallenge.Repository.Implementations;

public class UserRepository(MySQLContext context) : IUserRepository
{
  private readonly MySQLContext _context = context;

  public List<User> FindAll()
  {
    return _context.Users.ToList();
  }

  public User FindByFederalTaxId(string federalTaxId)
  {
    return _context.Users.SingleOrDefault(param => param.FederalTaxId.Equals(federalTaxId));
  }

  public User Create(User user)
  {
    try
    {
      _context.Users.Add(user);
      _context.SaveChanges();
      return user;
    }
    catch (Exception)
    {
      throw;
    }
  }

  public User Update(User user)
  {
    if (!Exists(user.FederalTaxId))
    {
      return null;
    }

    var existingUser = _context.Users.FirstOrDefault(param => param.FederalTaxId.Equals(user.FederalTaxId));

    if (existingUser != null)
    {
      try
      {
        _context.Entry(existingUser).CurrentValues.SetValues(user);
        _context.SaveChanges();
        return user;
      }
      catch (Exception)
      {
        throw;
      }
    }

    return null;
  }


  public void Delete(string federalTaxId)
  {
    var result = _context.Users.FirstOrDefault(param => param.FederalTaxId.Equals(federalTaxId));

    if (result != null)
    {
      try
      {
        _context.Users.Remove(result);
        _context.SaveChanges();
      }
      catch (Exception)
      {
        throw;
      }

    }
  }

  public bool Exists(string federalTaxId)
  {
    return _context.Users.Any(param => param.FederalTaxId.Equals(federalTaxId));
  }
}