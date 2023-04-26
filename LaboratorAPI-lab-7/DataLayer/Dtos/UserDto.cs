using DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Dtos
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcludeFromSwaggerAttribute : Attribute
    {
        [AttributeUsage(AttributeTargets.Property)]
        public class SwaggerExcludeAttribute : Attribute { }
    }
    public class UserDto
    {
        [ExcludeFromSwagger]
        public int Id { get; set; }

        public string UserName { get; set; }
        public RoleType Role { get; set; }
    }
}
