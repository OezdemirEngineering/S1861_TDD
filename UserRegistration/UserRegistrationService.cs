using UserRegistration.Common.Contracts;

namespace UserRegistration;

public class UserRegistrationService(IDbService dbService, ILoggerService loggerService, IEmailService emailService)
{
    private readonly IDbService _dbService = dbService;
    private readonly ILoggerService _loggerService = loggerService ;
    private readonly IEmailService _emailService = emailService;

    private string  _privateStr = "testPrivateStr";



    internal void TestPrivateMethod(string param)
    {
        Console.WriteLine("TestPrivateMethod"+param);
    }

    public void RegisterUser(string username, string password)
    {
        if (_dbService.UserExists(username))
        {
            _loggerService.LogError($"User {username} already exists");
            return;
        }

        _dbService.SaveUser(username, password);
        _loggerService.LogInfo($"User {username} registered successfully");
        _emailService.SendEmail(username, "Registration successful", "Welcome to our platform!");
    }

    public void UnregisterUser(string username)
    {
        if (!_dbService.UserExists(username))
        {
            _loggerService.LogError($"User {username} does not exist");
            return;
        }
        _dbService.DeleteUser(username);
        _loggerService.LogInfo($"User {username} unregistered successfully");
        _emailService.SendEmail(username, "Unregistration successful", "We are sorry to see you go!");
    }


}
