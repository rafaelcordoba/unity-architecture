using System.Net;
using FluentAssertions;
using MyGame.Common.Net;
using MyGame.Common.Serialization;
using MyGame.Common.System;
using MyGame.Infrastructure;
using MyGame.Infrastructure.Hello;
using NSubstitute;

namespace MyGameTests.Infrastructure.Hello;

public class ServerApiTests
{
    private readonly IJsonSerializer _json;
    private readonly IHttpHandler _handler;
    private readonly IRandom _random;
    private const string BaseUrl = "anyUrl";
    private readonly ServerApi _sut;

    public ServerApiTests()
    {
        var config = Substitute.For<IServerConfig>();
        _json = Substitute.For<IJsonSerializer>();
        _handler = Substitute.For<IHttpHandler>();
        var factory = Substitute.For<IRandomFactory>();
        _random = Substitute.For<IRandom>();
        
        config.HelloRandomSeed.Returns(123);
        config.HelloBaseUrl.Returns(BaseUrl);
        factory.Create(123).Returns(_random);
        
        _sut = new ServerApi(config, _json, _handler, factory);
    }

    [Fact]
    public async Task Returns_Random_Greeting_Successfully()
    {
        _random.Next(1, 4).Returns(2);
        var response = CreateResponse(HttpStatusCode.OK, "anyJsonString");
        _handler.GetAsync($"{BaseUrl}/todos/2").Returns(response);

        var helloResponse = new HelloResponse { Title = "anyTitle" };
        _json.Deserialize<HelloResponse>("anyJsonString").Returns(helloResponse);

        var result = await _sut.GetGreetingAsync("anyName");

        result.Should().Be("Greetings, anyName!\n" +
                           "anyTitle");
    }
    
    [Fact]
    public async Task Http_Code_Not_OK_Throws_Exception()
    {
        var response = CreateResponse(HttpStatusCode.NotFound, string.Empty);
        _handler.GetAsync(Arg.Any<string>()).Returns(response);

        Func<Task> act = async () => await _sut.GetGreetingAsync("anyName");

        await act.Should().ThrowAsync<HttpRequestException>();
    }
    
    private static HttpResponseMessage CreateResponse(HttpStatusCode statusCode, string content)
    {
        return new HttpResponseMessage
        {
            StatusCode = statusCode,
            Content = new StringContent(content)
        };
    }
}