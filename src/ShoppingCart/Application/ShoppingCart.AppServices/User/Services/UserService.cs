using ShoppingCart.AppServices.ShoppingCart.Repositories;
using ShoppingCart.Contracts;
using ShoppingCart.Domain;

namespace ShoppingCart.AppServices.ShoppingCart.Services;

/// <inheritdoc />
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<User> GetCurrent(CancellationToken cancellationToken)
    {

        throw new NotImplementedException();
    }

    public async Task<string> Login(string Login, string Password, CancellationToken cancellationToken)
    {
        //TODO

        var result = "secretKey";
        
        return result;

        throw new NotImplementedException();
    }

    public async Task<int> Register(string Login, string Password, CancellationToken cancellationToken)
    {
        var result = 1;

        return 1;

        throw new NotImplementedException();
    }
}