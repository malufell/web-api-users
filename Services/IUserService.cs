using WebApiChallenge.Models;

namespace WebApiChallenge.Services;

public interface IUserService
{
	User Create(User user);

	User FindByFederalTaxId(string federalTaxId);

	List<User> FindAll();

	User Update(User user);

	void Delete(string federalTaxId);
}