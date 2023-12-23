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
    internal class EducationWriteRepository : WriteRepository<Education>, IEducationWriteRepository
    {
        public EducationWriteRepository(VirtualPetCareApiDbContext context) : base(context)
        {
        }
    }
}
