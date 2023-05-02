using System.Threading.Tasks;
using videoPortal.Domain;

namespace videoPortal.Services
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
    }
}
