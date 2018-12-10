using System.Threading.Tasks;
using AgroEX.API.Models;

namespace AgroEX.API.Repository
{
    public interface IUserRepo
    {
         Task<User> Register(User user, string password);
         Task<User> Login(string username, string password);
         Task<bool> UserExists(string username);

    }
}