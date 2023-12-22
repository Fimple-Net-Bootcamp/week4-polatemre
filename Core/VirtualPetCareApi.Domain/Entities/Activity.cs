using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareApi.Domain.Entities.Common;
using VirtualPetCareApi.Domain.Entities.Identity;

namespace VirtualPetCareApi.Domain.Entities
{
    public class Activity: BaseEntity
    {
        public string Name { get; set; }

        public int PetId { get; set; }
        public Pet Pet { get; set; }
    }
}
