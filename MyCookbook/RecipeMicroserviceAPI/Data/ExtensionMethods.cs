using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeMicroserviceAPI.Data.Entities;
using RecipeMicroserviceAPI.Data.Exceptions;

namespace RecipeMicroserviceAPI.Data
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
