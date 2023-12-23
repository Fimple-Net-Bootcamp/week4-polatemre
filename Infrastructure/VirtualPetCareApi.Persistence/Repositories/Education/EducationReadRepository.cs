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
    public class EducationReadRepository : ReadRepository<Education>, IEducationReadRepository
    {
        public EducationReadRepository(VirtualPetCareApiDbContext context) : base(context)
        {
        }
    }
}
