using System.Collections.Generic;
using System.Linq;
using Fit4You.Core.Data;
using Fit4You.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fit4You.Core.ForFakeTests
{
    public class FakeUserRepository
    {
        public DbContextOptionsBuilder<Fit4YouDbContext> optionsBuilder;
        public FakeUserRepository()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();

            optionsBuilder = new DbContextOptionsBuilder<Fit4YouDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("Fit4YouConnectionString"));
        }
        public void Add(User user)
        {
            using (var context = new Fit4YouDbContext(optionsBuilder.Options))
            {
                context.User.Add(user);
                context.SaveChanges();
            }
        }

        public List<User> FindAll()
        {
            using (var context = new Fit4YouDbContext(optionsBuilder.Options))
            {
                return context.User.ToList();
            }
        }
    }
}
