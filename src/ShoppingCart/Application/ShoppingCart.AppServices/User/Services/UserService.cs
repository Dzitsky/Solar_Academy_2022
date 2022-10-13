using ShoppingCart.AppServices.ShoppingCart.Repositories;
using ShoppingCart.Domain;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ShoppingCart.AppServices.ShoppingCart.Services;

/// <inheritdoc />
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IClaimsAccessor _claimsAccessor;



    public UserService(IUserRepository userRepository, IClaimsAccessor claimsAccessor)
    {
        _userRepository = userRepository;
        _claimsAccessor = claimsAccessor;
    }

    public async Task<User> GetCurrent(CancellationToken cancellationToken)
    {
        var claims = await _claimsAccessor.GetClaims(cancellationToken);
        var id = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(id))
        {
            return null;
        }

        var user = await _userRepository.FindWhere

        return null;

    }

    public async Task<string> Login(string login, string password, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.FindWhere(user => user.Login == login, cancellationToken);

        if (existingUser == null)
        {
            throw new Exception("Пользователь не найден.");
        }

        if (!existingUser.Password.Equals(password))
        {
            throw new Exception("Нет прав.");
        }

        var claims = new List<Claim>
        { 
            new Claim(ClaimTypes.NameIdentifier, existingUser.Id.ToString()),
            new Claim(ClaimTypes.Name, existingUser.Login)        
        };

        string secretKey = "secretKeysecretKeysecretKeysecretKey";

        var token = new JwtSecurityToken
            (
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            notBefore: DateTime.UtcNow,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                SecurityAlgorithms.HmacSha256                
                )
            );

        var result = new JwtSecurityTokenHandler().WriteToken(token);
        
        return result;
    }

    public async Task<Guid> Register(string login, string password, CancellationToken cancellationToken)
    {
        var user = new User {
            Name = login,
            Login = login,
            Password = password,
            CreateDate = DateTime.UtcNow
        };

        var existingUser = await _userRepository.FindWhere(user => user.Login == login, cancellationToken);
        if (existingUser != null)
        {
            throw new Exception($"Пользователь с логином '{login}' уже зарегистрирован!");
        }

        await _userRepository.AddAsync(user);

        return user.Id;
    }
}