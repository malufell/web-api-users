using Microsoft.AspNetCore.Mvc;
using WebApiChallenge.Exceptions;
using WebApiChallenge.Models;
using WebApiChallenge.Services;

namespace WebApiChallenge.Controllers;
[ApiController]
[Route("api/[controller]")]

public class UserController(IUserService userService) : Controller
{
  private readonly IUserService _userService = userService;

  [HttpGet("")]
  public IActionResult Get()
  {
    return Ok(_userService.FindAll());
  }

  [HttpGet("{federalTaxId}")]
  public IActionResult Get(string federalTaxId)
  {
    var user = _userService.FindByFederalTaxId(federalTaxId);

    if (user == null) return NotFound();

    return Ok(user);
  }

  [HttpPost]
  public IActionResult Create([FromBody] User user)
  {

    if (user == null) return BadRequest();

    try
    {
      return Ok(_userService.Create(user));
    }
    catch (UniqueConstraintViolationException)
    {
      return UnprocessableEntity("Federal Tax Id already exists");
    }
    catch (ArgumentException ex)
    {
      return UnprocessableEntity(ex.Message);
    }
  }

  [HttpPut]
  public IActionResult Update([FromBody] User user)
  {
    if (user == null) return BadRequest();

    try
    {
      return Ok(_userService.Update(user));
    }
    catch (NotFoundException)
    {
      return UnprocessableEntity("Federal Tax Id not found");
    }
    catch (ArgumentException ex)
    {
      return UnprocessableEntity(ex.Message);
    }
  }

  [HttpDelete("{federalTaxId}")]
  public IActionResult Delete(string federalTaxId)
  {
    var user = _userService.FindByFederalTaxId(federalTaxId);

    if (user == null) return NotFound();

    _userService.Delete(federalTaxId);

    return NoContent();
  }
}