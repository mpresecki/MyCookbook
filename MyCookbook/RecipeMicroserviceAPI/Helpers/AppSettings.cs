﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; }

        public string UserAPI { get; set; }

        public string MealAPI { get; set; }
    }
}
