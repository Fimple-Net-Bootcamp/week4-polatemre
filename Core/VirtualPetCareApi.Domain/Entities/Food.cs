﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCareApi.Domain.Entities.Common;

namespace VirtualPetCareApi.Domain.Entities
{
    public class Food: BaseEntity
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
}
