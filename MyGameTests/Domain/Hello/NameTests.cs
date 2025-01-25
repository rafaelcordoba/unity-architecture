using FluentAssertions;
using MyGame.Domain.Hello;

namespace MyGameTests.Domain.Hello;

public class NameTests
{
    [Fact]
    public void Null_Name_Is_Invalid()
    {
        var name = new Name(null);

        name.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Empty_Name_Is_Invalid()
    {
        var name = new Name("");

        name.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Whitespace_Name_Is_Invalid()
    {
        var name = new Name(" ");

        name.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Too_Big_Name_Is_Invalid()
    {
        var name = new Name("12345678901");

        name.IsValid.Should().BeFalse();
    }

    [Theory]
    [InlineData("1")]
    [InlineData("1234567890")]
    public void Acceptable_Names_Are_Valid(string acceptableName)
    {
        var name = new Name(acceptableName);

        name.IsValid.Should().BeTrue();
    }
}