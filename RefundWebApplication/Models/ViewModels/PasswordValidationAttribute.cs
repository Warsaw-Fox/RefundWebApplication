using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

public class PasswordValidationAttribute : ValidationAttribute
{
    private readonly bool requireDigit;
    private readonly bool requireLowercase;
    private readonly bool requireNonAlphanumeric;
    private readonly bool requireUppercase;
    private readonly int requiredLength;
    private readonly int requiredUniqueChars;

    public PasswordValidationAttribute(bool requireDigit, bool requireLowercase, bool requireNonAlphanumeric, bool requireUppercase, int requiredLength, int requiredUniqueChars)
    {
        this.requireDigit = requireDigit;
        this.requireLowercase = requireLowercase;
        this.requireNonAlphanumeric = requireNonAlphanumeric;
        this.requireUppercase = requireUppercase;
        this.requiredLength = requiredLength;
        this.requiredUniqueChars = requiredUniqueChars;

        ErrorMessage = "Password does not meet the required criteria.";
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string password = value as string;

        if (string.IsNullOrEmpty(password))
        {
            return new ValidationResult(ErrorMessage);
        }

        // Sprawdzaj długość hasła
        if (password.Length < requiredLength)
        {
            return new ValidationResult($"Password must be at least {requiredLength} characters long.");
        }

        // Sprawdzaj wymagane cyfry
        if (requireDigit && !password.Any(char.IsDigit))
        {
            return new ValidationResult("Password must contain at least one digit.");
        }

        // Sprawdzaj wymagane małe litery
        if (requireLowercase && !password.Any(char.IsLower))
        {
            return new ValidationResult("Password must contain at least one lowercase letter.");
        }

        // Sprawdzaj wymagane duże litery
        if (requireUppercase && !password.Any(char.IsUpper))
        {
            return new ValidationResult("Password must contain at least one uppercase letter.");
        }

        // Sprawdzaj wymagane znaki specjalne
        if (requireNonAlphanumeric && !password.Any(ch => !char.IsLetterOrDigit(ch)))
        {
            return new ValidationResult("Password must contain at least one non-alphanumeric character.");
        }

        // Sprawdzaj unikalne znaki
        if (requiredUniqueChars > 0 && password.Distinct().Count() < requiredUniqueChars)
        {
            return new ValidationResult($"Password must contain at least {requiredUniqueChars} unique characters.");
        }

        return ValidationResult.Success;
    }
}
