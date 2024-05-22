namespace GitPrDemo;

public readonly struct Pesel : IComparable<Pesel>
{
    public string PeselNumber { get; }

    public Pesel(string peselNumber)
    {
        PeselValidator.ThrowIfInvalid(peselNumber);
        PeselNumber = peselNumber;

        var month = int.Parse(peselNumber[2..4]);
        int century = 19;

        while (month > 12)
        {
            century++;
            month -= 20;
        }

        Month = month;
        Year = int.Parse(peselNumber[..2]) + century * 100;
        Day = int.Parse(peselNumber[4..6]);
    }

    public int Month { get; }
    public int Year { get; }
    public int Day { get; }
    public bool IsMale => (int.Parse(PeselNumber[^2..^1]) & 1) >> 0 == 1;

    public int CompareTo(Pesel other) => string.Compare(PeselNumber, other.PeselNumber, StringComparison.Ordinal);
}