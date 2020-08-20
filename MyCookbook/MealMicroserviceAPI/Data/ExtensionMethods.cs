using MealMicroserviceAPI.Data.Entities;
using MealMicroserviceAPI.Data.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MealMicroserviceAPI.Data
{
    public static class ExtensionMethods
    {
        public static void RejectNotFound(this BaseEntity entity)
        {
            if (entity == null)
            {
                throw new NotFoundException();
            }
        }
    }
}
