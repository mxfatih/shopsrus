
using System.Threading.Tasks;

using ShopsRUs.Data.User;
using ShopsRUs.Services.Interfaces;

namespace ShopsRUs.Services
{
    public class UserService : IUserService
    {
        public async Task<User> GetById(int userId)
        {
            return userId switch
            {
                1 => new Employee
                {
                    Id = userId,
                    Name = "Adam",
                    SurName = "Employee"
                },
                2 => new Customer
                {
                    Id = userId,
                    Name = "Adam",
                    SurName = "Customer",
                    JoinDate = System.DateTime.Today.AddYears(-3)
                },
                3 => new Affiliate
                {
                    Id = userId,
                    Name = "Adam",
                    SurName = "Affiliate"
                },
                _ => null,
            };
        }
    }
}