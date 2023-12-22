using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareApi.Domain.Entities.Common;
using VirtualPetCareApi.Domain.Entities.Identity;

namespace VirtualPetCareApi.Domain.Entities
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }

        public int HealthId { get; set; }
        public Health Health { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<Activity> Activities { get; set; }
    }
}
