using ShoppingCart.AppServices.ShoppingCart.Repositories;
using ShoppingCart.Domain;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace ShoppingCart.AppServices.ShoppingCart.Services;

/// <inheritdoc />
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IClaimsAccessor _claimsAccessor;
    private readonly IConfiguration _configuration;


    public UserService(
        IUserRepository userRepository, 
        IClaimsAccessor claimsAccessor,
        IConfiguration configuration)
    {
        _userRepository = userRepository;
        _claimsAccessor = claimsAccessor;
        _configuration = configuration;
    }

    public async Task<User> GetCurrent(CancellationToken cancellationToken)
    {
        var claims = await _claimsAccessor.GetClaims(cancellationToken);
        var claimId = claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(claimId))
        {
            return null;
        }

        var id = Guid.Parse(claimId);
        var user = await _userRepository.FindById(id, cancellationToken);

        if (user == null)
        {
            throw new Exception($"Не найден пользователь с идентификатором '{id}'");
        }

        return user;
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

        var secretKey = _configuration["Token:SecretKey"];

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