
using System;

using ShopsRUs.Data.Interfaces;

namespace ShopsRUs.Data.User
{
    [Serializable]
    public class UserBase : IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public virtual UserType UserType => UserType.BaseUser;
    }

    [Serializable]
    public abstract class User : UserBase, IUserDiscountable
    {
        public virtual decimal DiscountAmount { get; set; } = 0M;
        public virtual decimal DiscountPercentage { get; set; } = 0M;

        public virtual decimal GetDiscountAmount() => DiscountAmount;
        public virtual decimal GetDiscountPercentage() => DiscountPercentage;
    }

    [Serializable]
    public class Employee : User
    {
        public override decimal DiscountPercentage => 30M;
        public override UserType UserType => UserType.Employee;
    }

    [Serializable]
    public class Customer : User
    {
        public DateTime JoinDate { get; set; } = DateTime.Today;
        public override UserType UserType => UserType.Customer;

        public override decimal GetDiscountPercentage() => (DateTime.Today - JoinDate).TotalDays > 365 ? 5M : 0;
    }

    [Serializable]
    public class Affiliate : User
    {
        public override decimal DiscountPercentage => 10M;
        public override UserType UserType => UserType.Affiliate;
    }
}