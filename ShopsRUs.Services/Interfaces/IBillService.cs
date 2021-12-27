
using ShopsRUs.Data.Bill;
using System.Threading.Tasks;

namespace ShopsRUs.Services.Interfaces
{
    public interface IBillService
    {
        public Task<Bill> GetById(int billId);
    }
}