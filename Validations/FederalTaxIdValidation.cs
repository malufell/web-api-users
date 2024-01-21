namespace WebApiChallenge.Validations;

public static class FederalTaxIdValidator
{
  public static bool IsValid(string cpf)
  {
    // Removes non -numerical characters
    string cleanedCpf = new string(cpf
        .ToCharArray()
        .Where(char.IsDigit)
        .ToArray());

    // Check if it has 11 digits
    if (cleanedCpf.Length != 11)
    {
      return false;
    }

    // Checks if all digits are equal
    if (cleanedCpf.All(digit => digit == cleanedCpf[0]))
    {
      return false;
    }

    // Calculate verifier digits
    int[] digits = cleanedCpf.Select(c => int.Parse(c.ToString())).ToArray();
    int sum = 0;
    for (int i = 0; i < 9; i++)
    {
      sum += digits[i] * (10 - i);
    }
    int firstVerifier = (sum % 11) < 2 ? 0 : 11 - (sum % 11);

    sum = 0;
    for (int i = 0; i < 10; i++)
    {
      sum += digits[i] * (11 - i);
    }
    int secondVerifier = (sum % 11) < 2 ? 0 : 11 - (sum % 11);

    // Check if the verification digits are valid
    return digits[9] == firstVerifier && digits[10] == secondVerifier;
  }
}
