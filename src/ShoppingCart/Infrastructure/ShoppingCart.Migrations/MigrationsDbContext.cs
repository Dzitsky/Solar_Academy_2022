using Microsoft.EntityFrameworkCore;
using ShoppingCart.DataAccess;

namespace ShoppingCart.Migrations;

public class MigrationsDbContext : ShoppingCartContext
{
    public MigrationsDbContext(DbContextOptions<MigrationsDbContext> options) : base(options)
    {
    }
}