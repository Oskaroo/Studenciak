namespace Application.Security;

public interface IPasswordManager
{
    string Secure(string password);
}