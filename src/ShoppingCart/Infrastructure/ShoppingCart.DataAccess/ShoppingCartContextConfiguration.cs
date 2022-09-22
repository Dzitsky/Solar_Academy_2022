using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShoppingCart.DataAccess.Interfaces;

namespace ShoppingCart.DataAccess;

public class ShoppingCartContextConfiguration : IDbContextOptionsConfigurator<ShoppingCartContext>
{
    private const string PostgesConnectionStringName = "PostgresShoppingCartDb";
    private const string MsSqlShoppingCartDb = "MsSqlShoppingCartDb";
    private readonly IConfiguration _configuration;
    private readonly ILoggerFactory _loggerFactory;

    public ShoppingCartContextConfiguration(ILoggerFactory loggerFactory, IConfiguration configuration)
    {
        _loggerFactory = loggerFactory;
        _configuration = configuration;
    }

    public void Configure(DbContextOptionsBuilder<ShoppingCartContext> options)
    {
        string connectionString;

        // var useMsSql = _configuration.Get<bool>("DataBaseOptions:UseMsSql").Value;
        var useMsSql = false;

        if (!useMsSql)
        {
            connectionString = _configuration.GetConnectionString(PostgesConnectionStringName);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    $"Не найдена строка подключения с именем '{PostgesConnectionStringName}'");
            }
            options.UseNpgsql(connectionString);
        }
        else
        {
            connectionString = _configuration.GetConnectionString(MsSqlShoppingCartDb);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException(
                    $"Не найдена строка подключения с именем '{MsSqlShoppingCartDb}'");
            }
            options.UseSqlServer(connectionString);
        }
        
        options.UseLoggerFactory(_loggerFactory);
    }
}