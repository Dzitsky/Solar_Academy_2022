using ShoppingCart.Contracts;
using ShoppingCart.Domain;

namespace ShoppingCart.AppServices.ShoppingCart.Services;

/// <summary>
/// 
/// </summary>
public interface IUserService
{
    /// <summary>
    /// ����������� ������������.
    /// </summary>
    /// <param name="Login">�����.</param>
    /// <param name="Password">������.</param>
    /// <param name="cancellationToken"></param>
    /// <returns>������������� ������������.</returns>
    Task<int> Register(string login, string password, CancellationToken cancellationToken);

    /// <summary>
    /// ������������.
    /// </summary>
    /// <param name="Login"></param>
    /// <param name="Password"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>�����.</returns>
    Task<string> Login(string login, string password, CancellationToken cancellationToken);

    /// <summary>
    /// �������� �������� ������������
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<User> GetCurrent(CancellationToken cancellationToken);
}