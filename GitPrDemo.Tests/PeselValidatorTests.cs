using System;
using FluentAssertions;
using GitPrDemo;
using Xunit;

namespace GitPrDemo.Tests;

public class PeselValidatorTests
{
    [Fact]
    public void TestThrowIfInvalid_WithInvalidLength()
    {
        var invalidPesel = "1234567890"; // less than 11
        var act = () => PeselValidator.ThrowIfInvalid(invalidPesel);

        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void TestThrowIfInvalid_WithInvalidCharacters()
    {
        var invalidPesel = "1234567890A"; // contains non-digit character
        var act = () => PeselValidator.ThrowIfInvalid(invalidPesel);
        
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void InvalidTest()
    {
        false.Should().BeTrue("showcase of failed test in CI checks");
    }

    [Theory]
    [MemberData(nameof(PeselValidationData))]
    public void TestIsValid(string pesel, bool isValidExpected, string testReason)
    {
        bool isValid = PeselValidator.IsValid(pesel, out var reason);
        isValid.Should().Be(isValidExpected, $"{testReason}; {reason}");
    }
    
    public static TheoryData<string, bool, string> PeselValidationData => new()
    {
        { "12345678901", false, "Invalid checksum" },
        { "1234567890A", false, "Invalid characters" },
        { "1234567890", false, "Invalid length" },
        { "83051401358", true, "valid PESEL" },
        { "01020345670", true, "valid PESEL" },
        { "00540145678", false, "Invalid month" },
        { "00220145679", false, "Invalid checksum" },
        { "00220145670", false, "Invalid checksum" },
        { "00220145671", false, "Invalid checksum" },
        { "00220145672", false, "Invalid checksum" },
        { "00220145673", false, "Invalid checksum" },
        { "00220145674", false, "Invalid checksum" },
        { "00220145675", true, "valid PESEL" },
        { "00220145676", false, "Invalid checksum" },
        { "00220145677", false, "Invalid checksum" }
    };
}