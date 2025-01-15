using DbService.Common.Contexts;
using DbService.Common.Dtos;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace DbService.Tests;

public class DbServiceTests: IDisposable
{
    private readonly UserDbContext _context;
    private readonly UserDto _user;
    public DbServiceTests()
    {
        var options = new DbContextOptionsBuilder<UserDbContext>()
        .UseInMemoryDatabase(databaseName: "TestDatabase")
        .Options;

        _context = new(options);

        _user = new()
        {
            FirstName = "Caglar",
            FamilyName = "Oezdemir",
            Email = "info@oeeng.de"
        };
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    [Fact]
    public void AddUser_UserDto_CorrectUserDto()
    {
        // Arrange 
        var dbService = new DbService(_context);

        // Act
        dbService.AddUser(_user);


        // Assert
        var user = _context.Users.First();      
        user.Should().BeEquivalentTo(_user);
    }

    [Fact]
    public void DeleteUser_ExistingUserId_DeletesUser()
    {
        // Arrange
        var dbService = new DbService(_context);
        _context.Users.Add(_user);
        _context.SaveChanges();
        var userId = _context.Users.First().Id;

        // Act
        dbService.DeleteUser(userId);

        // Assert
        var user = _context.Users.SingleOrDefault(u => u.Id == userId);
        user.Should().BeNull();
    }

    [Theory]
    [MemberData(nameof(UserDataGeneration))]
    public void GetUsers_ExistingUsers_ReturnsUsers(UserDto user, UserDto user2)
    {
        // Arrange
        var dbService = new DbService(_context);
        _context.Users.Add(user);
        _context.SaveChanges();

        // Act
        var users = dbService.GetUsers();

        // Assert
        users.Should().ContainEquivalentOf(user);
    }



    public static IEnumerable<object[]> UserDataGeneration()
    {
        var list = new List<object[]>();

        for (int i = 0; i < 10; i++)
        {
            list.Add(new object[] { new UserDto { FirstName = "user"+i, FamilyName = "familiyname"+i, Email = "mail"+i+"@oeeng.de" },
                                    new UserDto { FirstName = "user"+i, FamilyName = "familiyname"+i, Email = "mail"+i+"@oeeng.de" }});
        }

        return list;
    }

}
