using System.Diagnostics.CodeAnalysis;

namespace GitPrDemo;

public static class PeselValidator
{
    public static void ThrowIfInvalid(string peselNumber)
    {
        if (IsValid(peselNumber, out string? reason)) return;
        
        throw new ArgumentException(reason);
    }
    
    public static bool IsValid(string peselNumber, [NotNullWhen(false)] out string? reason)
    {
        if (peselNumber.Length is not 11)
        {
            reason = PeselValidationReasons.InvalidLength;
            return false;
        }
        
        if (!peselNumber.All(char.IsDigit))
        {
            reason = PeselValidationReasons.InvalidCharacters;
            return false;
        }
        
        int month = int.Parse(peselNumber[2..4]);

        while (month > 12)
        {
            month -= 20;
        }
        
        if (month < 1)
        {
            reason = string.Format(PeselValidationReasons.InvalidMonth, month);
            return false;
        }

        int[] weights = [1, 3, 7, 9, 1, 3, 7, 9, 1, 3];
        int sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += weights[i] * (peselNumber[i] - '0');
        }

        int checksum = (10 - sum % 10) % 10;
        bool isValid = checksum == peselNumber[10] - '0';
        
        reason = isValid ? null : string.Format(PeselValidationReasons.InvalidChecksum, checksum);
        return isValid;
    }
}