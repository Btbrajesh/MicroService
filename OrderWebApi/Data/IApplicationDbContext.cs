using Microsoft.EntityFrameworkCore;

namespace OrderWebApi.Data
{
    public interface IApplicationDbContext
    {
        DbSet<Entities.Order> Orders { get; set; }
        Task<int> SaveChanges();
    }
}
