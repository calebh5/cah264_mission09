using cah264_mission09.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace cah264_mission09
{
    public class EFCartRepository : ICartRepository
    {
        private BookstoreContext context;

        public EFCartRepository (BookstoreContext temp)
        {
            context = temp;
        }

        public IQueryable<Order> Orders => context.Orders.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(x => x.Book));

            if (order.OrderId == 0)
            {
                context.Orders.Add(order);
            }

            context.SaveChanges();
        }
    }
}