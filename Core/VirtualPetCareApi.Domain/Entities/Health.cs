using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareApi.Domain.Entities.Common;

namespace VirtualPetCareApi.Domain.Entities
{
    public class Health: BaseEntity
    {
        public int Value { get; set; }
        public string Description { get; set; }
        public ICollection<Pet> Pets { get; set; }
    }
}
