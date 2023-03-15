using cah264_mission09.Models;
using System.Linq;

namespace cah264_mission09
{
    public interface ICartRepository
    {
        IQueryable<Order> Orders { get; }

        void SaveOrder(Order order);
    }
}