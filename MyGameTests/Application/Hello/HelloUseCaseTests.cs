using FluentAssertions;
using MyGame.Application.Hello;
using MyGame.Common.Logging;
using NSubstitute;

namespace MyGameTests.Application.Hello;

public class HelloUseCaseTests
{
    private readonly IGreetingService _service = Substitute.For<IGreetingService>();
    private readonly ILogger _logger = Substitute.For<ILogger>();
    private readonly HelloUseCase _sut;

    public HelloUseCaseTests()
    {
        _sut = new HelloUseCase(_service, _logger);
    }

    [Theory]
    [InlineData(null, "Error: Name cannot be empty")]
    [InlineData("", "Error: Name cannot be empty")]
    [InlineData("12", "Error: Name is too short")]
    [InlineData("12345678901", "Error: Name is too long")]
    public async Task Invalid_Names_Return_Error_And_Dont_Call_Service(string? name, string errorMessage)
    {
        var result = await _sut.HelloAsync(name);

        result.Should().Be(errorMessage);
        await _service.DidNotReceive().GetGreetingAsync(Arg.Any<string>());
    }
    
    [Theory]
    [InlineData("123")]
    [InlineData("1234567890")]
    public async Task Valid_Names_Return_Greeting(string? name)
    {
        _service.GetGreetingAsync(name).Returns("Hello");
        
        var result = await _sut.HelloAsync(name);

        result.Should().Be("Hello");
    }
}