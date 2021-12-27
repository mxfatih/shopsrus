
namespace ShopsRUs.Data.User
{
    [System.Serializable]
    public enum UserType : int
    {
        BaseUser = 1,
        Employee,
        Customer,
        Affiliate
    }
}