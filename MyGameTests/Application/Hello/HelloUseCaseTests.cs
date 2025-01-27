using FluentAssertions;
using MyGame.Application.Hello;
using MyGame.Common.Logging;
using MyGame.Domain.Hello;
using NSubstitute;
using NSubstitute.ExceptionExtensions;

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

    [Fact]
    public async Task HelloAsync_NullName_ReturnsErrorAndLogs()
    {
        var result = await _sut.HelloAsync(null);

        result.Should().Be("Error: Invalid name: ");
        _logger.Received(1).Error("Invalid name: ");
        await _service.DidNotReceive().GetGreetingAsync(Arg.Any<Name>());
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("12345678901")]
    public async Task HelloAsync_InvalidName_ReturnsErrorAndLogs(string invalidName)
    {
        var result = await _sut.HelloAsync(invalidName);

        result.Should().Be($"Error: Invalid name: {invalidName}");
        _logger.Received(1).Error($"Invalid name: {invalidName}");
        await _service.DidNotReceive().GetGreetingAsync(Arg.Any<Name>());
    }

    [Fact]
    public async Task HelloAsync_ValidName_ReturnsGreetingAndLogs()
    {
        const string testName = "Alice";
        _service.GetGreetingAsync(Arg.Any<Name>()).Returns($"Hello, {testName}!");

        var result = await _sut.HelloAsync(testName);

        result.Should().Be($"Hello, {testName}!");
        _logger.Received(1).Info($"Hello, {testName}!");
        await _service.Received(1).GetGreetingAsync(Arg.Is<Name>(n => n.Text == testName));
    }

    [Fact]
    public async Task HelloAsync_ServiceFails_ReturnsGenericErrorAndLogs()
    {
        const string testName = "Bob";
        _service.GetGreetingAsync(Arg.Any<Name>()).Throws(new System.Exception("Service failure"));

        var result = await _sut.HelloAsync(testName);

        result.Should().Be("Error: Failed to get greeting");
        _logger.Received(1).Error("Error getting greeting: Service failure");
    }

    [Theory]
    [InlineData("John")]
    [InlineData("Sarah")]
    [InlineData("1234567890")]
    public async Task HelloAsync_ValidNames_ReturnsExpectedGreeting(string validName)
    {
        _service.GetGreetingAsync(Arg.Any<Name>()).Returns($"Hello, {validName}!");

        var result = await _sut.HelloAsync(validName);

        result.Should().Be($"Hello, {validName}!");
        await _service.Received(1).GetGreetingAsync(Arg.Is<Name>(n => n.Text == validName));
    }
}