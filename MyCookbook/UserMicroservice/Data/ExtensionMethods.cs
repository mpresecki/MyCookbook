using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserMicroserviceAPI.Data.Entities;
using UserMicroserviceAPI.Data.Exceptions;

namespace UserMicroserviceAPI.Data
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
