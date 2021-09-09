using System.Threading.Tasks;
using PayCoin.Client.Requests;

namespace PayCoin.Client.Services
{
    public interface IAuthenticationService
    {
        LoginResult User { get; }
        Task Initialize();
        Task Login(string Phone, string Password);
        Task Logout();
        string GetToken();
    }

}