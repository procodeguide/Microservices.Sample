using ProCodeGuide.Sample.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Sample.Microservice.Repository
{
    public interface IOrderRepository
    {
        Task<string> Add(Order order);
        Task<Order> GetById(string id);
        Task<string> Cancel(string id);
        Task<Order> GetByCustomerId(string custid);
    }
}
