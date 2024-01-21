using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApiChallenge.Validations;

namespace WebApiChallenge.Models;

[Table("users")]
public class User
{

  [Column("id")]
  public long Id { get; set; }

  [Column("name")]
  public string Name { get; set; }

  [Column("federal_tax_id")]
  public string FederalTaxId { get; set; }

  [Range(1, 100, ErrorMessage = "Age must be greater than 0")]
  [Column("age")]
  public int Age { get; set; }

  [Column("gender")]
  public string Gender { get; set; }

  [Column("place_of_birth")]
  public string PlaceOfBirth { get; set; }
}