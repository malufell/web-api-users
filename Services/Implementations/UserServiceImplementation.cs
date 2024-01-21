using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiChallenge.Exceptions;
using WebApiChallenge.Models;
using WebApiChallenge.Repository;
using WebApiChallenge.Validations;

namespace WebApiChallenge.Services.Implementations;

public class UserServiceImplementation(IUserRepository repository) : IUserService
{
  private readonly IUserRepository _repository = repository;

  public List<User> FindAll()
  {
    return _repository.FindAll();
  }

  public User FindByFederalTaxId(string federalTaxId)
  {
    return _repository.FindByFederalTaxId(federalTaxId);
  }

  public User Create(User user)
  {
    if (!FederalTaxIdValidator.IsValid(user.FederalTaxId))
    {
      throw new ArgumentException("Federal Tax Id is invalid");
    }

    try
    {
      return _repository.Create(user);
    }
    catch (DbUpdateException ex)
    {
      if (ex.InnerException is MySqlConnector.MySqlException mysqlEx && mysqlEx.Number == 1062)
      {
        throw new UniqueConstraintViolationException();
      }
      else
      {
        throw new Exception();
      }
    }
  }

  public User Update(User user)
  {
    if (!FederalTaxIdValidator.IsValid(user.FederalTaxId))
    {
      throw new ArgumentException("Federal Tax Id is invalid");
    }

    var existingUser = _repository.FindByFederalTaxId(user.FederalTaxId);
    if (existingUser == null)
    {
      throw new NotFoundException();
    }

    return _repository.Update(user);
  }

  public void Delete(string federalTaxId)
  {
    _repository.Delete(federalTaxId);
  }
}