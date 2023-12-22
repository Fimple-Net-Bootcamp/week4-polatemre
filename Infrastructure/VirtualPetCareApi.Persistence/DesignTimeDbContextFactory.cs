using VirtualPetCareApi.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCareApi.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<VirtualPetCareApiDbContext>
    {
        public VirtualPetCareApiDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<VirtualPetCareApiDbContext> optionsBuilder = new();
            optionsBuilder.UseNpgsql(Configuration.ConnectionString);
            return new(optionsBuilder.Options);
        }
    }
}
