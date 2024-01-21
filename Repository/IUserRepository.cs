using WebApiChallenge.Models;

namespace WebApiChallenge.Repository;

public interface IUserRepository
{
    User Create(User user);

    User FindByFederalTaxId(string federalTaxId);

    List<User> FindAll();

    User Update(User user);

    void Delete(string federalTaxId);

    bool Exists(string federalTaxId);
}