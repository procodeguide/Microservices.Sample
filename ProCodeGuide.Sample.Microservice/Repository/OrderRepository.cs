using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Sample.Microservice.DbContexts;
using ProCodeGuide.Sample.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Sample.Microservice.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private IApplicationDbContext _dbcontext;
        public OrderRepository(IApplicationDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<string> Add(Order order)
        {
            _dbcontext.Orders.Add(order);
            await _dbcontext.SaveChanges();
            return order.Id;
        }

        public async Task<string> Cancel(string id)
        {
            var orderupt = await _dbcontext.Orders.Where(orderdet => orderdet.Id == id).FirstOrDefaultAsync();
            if (orderupt == null) return "Order does not exists";

            orderupt.Status = "Cancelled";

            await _dbcontext.SaveChanges();
            return "Order Cancelled Successfully";
        }

        public async Task<Order> GetByCustomerId(string custid)
        {
            var order = await _dbcontext.Orders.Where(orderdet => orderdet.CustomerId == custid).FirstOrDefaultAsync();
            return order;
        }

        public async Task<Order> GetById(string id)
        {
            var order = await _dbcontext.Orders.Where(orderdet => orderdet.Id == id).FirstOrDefaultAsync();
            return order;
        }
    }
}
