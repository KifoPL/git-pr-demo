namespace GitPrDemo;

public static class PeselValidationReasons
{
    public const string InvalidLength = "Invalid length";
    public const string InvalidCharacters = "Invalid characters - all characters must be digits";
    public const string InvalidMonth = "Invalid month - cannot have a month {0}";
    public const string InvalidChecksum = "Invalid checksum - should be {0}";
}