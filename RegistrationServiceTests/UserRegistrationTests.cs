using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using UserRegistration;
using UserRegistration.Common.Contracts;

namespace RegistrationServiceTests;

public class UserRegistrationTests
{
    private ServiceProvider _provider;
    public UserRegistrationTests()
    {
        var services = new ServiceCollection();

        var mockEmailService = Substitute.For<IEmailService>();

        mockEmailService.When(mockEmailService => mockEmailService.SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()))
            .Do(_ => Console.WriteLine("Email sent"));

        var mockLoggerService = Substitute.For<ILoggerService>();
        var mockDbService = Substitute.For<IDbService>();

        services.AddSingleton<IEmailService>(mockEmailService)
            .AddSingleton<ILoggerService>(mockLoggerService)
            .AddSingleton<IDbService>(mockDbService)
            .AddTransient<UserRegistrationService>();

        _provider = services.BuildServiceProvider();
    }



    [Fact]
    public void RegisterUser_UserNamePassword_Registration()
    {
        //Arrange
        var userRegistrationService = _provider.GetRequiredService<UserRegistrationService>();
        var username = "testuser";
        var password = "testpassword";


        //Act
        userRegistrationService.RegisterUser(username, password);



    }
}
