
using System.Threading.Tasks;
using ShopsRUs.Data.User;

namespace ShopsRUs.Services.Interfaces
{
    public interface IUserService
    {
        public Task<User> GetById(int userId);
    }
}