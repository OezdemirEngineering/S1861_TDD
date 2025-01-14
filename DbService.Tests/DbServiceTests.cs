using DbService.Common.Contexts;
using DbService.Common.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DbService.Tests;

public class DbServiceTests: IDisposable
{
    public void Dispose()
    {

    }

    [Fact]
    public void Test1()
    {
        // Arrange 
        var options = new DbContextOptionsBuilder<UserDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDatabase")
            .Options;

        var context = new UserDbContext(options);

        var dbService = new DbService(context);

        // Act
        dbService.AddUser(new UserDto { Id = 1, FirstName = "Caglar",FamilyName="Oezdemir",Email="info@oeeng.de" });


        // Assert
        var user = context.Users.First();


       


    }
}
