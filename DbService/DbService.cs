using DbService.Common.Contexts;
using DbService.Common.Contracts;
using DbService.Common.Dtos;

namespace DbService;

public class DbService : IDbService
{
    private readonly UserDbContext _context;
    public DbService(UserDbContext context)
    {
        _context = context;
    }


    //Add,Remove, Update events 
    public event Action<UserDto> UserAdded;
    public event Action<UserDto> UserRemoved;
    public event Action<UserDto> UserUpdated;

    public void AddUser(UserDto user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
        UserAdded?.Invoke(GetUser(user.Id));
    }
    public UserDto GetUser(int id)
    {
        return _context.Users.SingleOrDefault(u => u.Id == id);
    }

    public List<UserDto> GetUsers()
    {
        return _context.Users.ToList();
    }

    public void UpdateUser(UserDto user)
    {
        _context.Users.Update(user);
        _context.SaveChanges();
        UserUpdated?.Invoke(GetUser(user.Id));
    }

    public void DeleteUser(int id)
    {
        var user = _context.Users.SingleOrDefault(u => u.Id == id);
        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
            UserRemoved?.Invoke(user);
        }
    }
}
