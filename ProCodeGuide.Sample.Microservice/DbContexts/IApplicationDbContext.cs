using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Sample.Microservice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProCodeGuide.Sample.Microservice.DbContexts
{
    public interface IApplicationDbContext
    {
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChanges();
    }
}
