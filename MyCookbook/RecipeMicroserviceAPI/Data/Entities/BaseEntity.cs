﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }
    }
}
