
using System.Threading.Tasks;

using ShopsRUs.Data.User;
using ShopsRUs.Services.Interfaces;

namespace ShopsRUs.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetById(int userId)
        {
            return new Employee
            {
                Id = userId,
                Name = "Adam",
                SurName = "Employee"
            };
        }
    }
}