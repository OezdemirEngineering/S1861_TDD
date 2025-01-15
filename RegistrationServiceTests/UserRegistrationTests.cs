using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using NSubstitute.Core.Arguments;
using UserRegistration;
using UserRegistration.Common.Contracts;

namespace RegistrationServiceTests;

public class UserRegistrationTests
{




    private readonly ServiceProvider _provider;

    public IEmailService EMailService
        => _provider.GetRequiredService<IEmailService>();
    public IDbService DbService
        => _provider.GetRequiredService<IDbService>();
    public ILoggerService LoggerService
        => _provider.GetRequiredService<ILoggerService>();

    public UserRegistrationService UserRegistrationService
        => _provider.GetRequiredService<UserRegistrationService>();

    public UserRegistrationTests()
    {
        var services = new ServiceCollection();

        var mockEmailService = Substitute.For<IEmailService>();
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
        var username = "testuser";
        var password = "testpassword";

        //Act
        UserRegistrationService.RegisterUser(username, password);


        //Assert
        EMailService.Received(1).SendEmail("testuser", Arg.Any<string>(), Arg.Any<string>());
        DbService.Received(1).SaveUser("testuser", "testpassword");
        LoggerService.Received(1).LogInfo(Arg.Any<string>());


        // Alternative solution to catch the method call 
        //mockEmailService.When(mockEmailService => mockEmailService.SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()))
        //    .Do(_ =>
        //    {
        //        _userNameInSendMail = _.ArgAt<string>(0); // first param
        //    });

    }

    [Fact]
    public void RegisterUser_ExistingUser_RegistrationFailed()
    {
        //Arrange
        var username = "testuser";
        var password = "testpassword";
        DbService.UserExists(username).Returns(true);

        //Act
        UserRegistrationService.RegisterUser(username, password);

        //Assert
        EMailService.DidNotReceive().SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        DbService.DidNotReceive().SaveUser(Arg.Any<string>(), Arg.Any<string>());
        LoggerService.Received(1).LogError(Arg.Any<string>());
    }

    [Fact]
    public void UnregisterUser_ExistingUser_Unregistration()
    {
        //Arrange
        var username = "testuser";
        DbService.UserExists(username).Returns(true);

        //Act
        UserRegistrationService.UnregisterUser(username);

        //Assert
        EMailService.Received(1).SendEmail("testuser", Arg.Any<string>(), Arg.Any<string>());
        DbService.Received(1).DeleteUser("testuser");
        LoggerService.Received(1).LogInfo(Arg.Any<string>());
    }

    [Fact]
    public void UnregisterUser_NonExistingUser_UnregistrationFailed()
    {
        //Arrange
        var username = "testuser";
        DbService.UserExists(username).Returns(false);

        //Act
        UserRegistrationService.UnregisterUser(username);

        //Assert
        EMailService.DidNotReceive().SendEmail(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>());
        DbService.DidNotReceive().DeleteUser(Arg.Any<string>());
        LoggerService.Received(1).LogError(Arg.Any<string>());
    }

}
