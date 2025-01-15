using DbService.Common.Contexts;
using DbService.Common.Contracts;
using DbService.Common.Dtos;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading.Tasks;

namespace DbService.Tests;

public class DbServiceDiTests
{
    private readonly ServiceProvider _serviceProvider;
    public DbServiceDiTests()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<IDbService,DbService>();
        serviceCollection.AddDbContext<UserDbContext>(options =>
        {
            options.UseInMemoryDatabase(databaseName: "TestDatabase");
        });

        _serviceProvider = serviceCollection.BuildServiceProvider();
    }

    [Fact]
    public void AddUser_UserDto_CorrectUserDto()
    {
        // Arrange 
        var dbService = _serviceProvider.GetRequiredService<IDbService>();
        var dbCOntext = _serviceProvider.GetRequiredService<UserDbContext>();

        var userData = new UserDto { FirstName="Max", FamilyName = "Mustermann", Email = "test@mail.de" };

        // Act
        dbService.AddUser(userData);


        // Assert
        var user = dbCOntext.Users.First();
        user.Should().BeEquivalentTo(userData);
    }
}

