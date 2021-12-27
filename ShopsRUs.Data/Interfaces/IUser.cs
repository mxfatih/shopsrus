using ShopsRUs.Data.User;

namespace ShopsRUs.Data.Interfaces
{
    public interface IUser
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public UserType UserType { get; }
    }
}