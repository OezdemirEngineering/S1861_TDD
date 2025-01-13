using DbService.Common.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbService.Common.Contexts;

public class UserDbContext : DbContext
{
    public DbSet<UserDto> Users { get; set; }

    public UserDbContext(DbContextOptions<UserDbContext> options) : base(options) { }
}
