using VirtualPetCareApi.Application.Repositories;
using VirtualPetCareApi.Domain.Entities;
using VirtualPetCareApi.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtualPetCareApi.Persistence.Repositories
{
    public class HealthReadRepository : ReadRepository<Health>, IHealthReadRepository
    {
        public HealthReadRepository(VirtualPetCareApiDbContext context) : base(context)
        {
        }
    }
}
