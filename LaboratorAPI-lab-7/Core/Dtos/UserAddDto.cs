using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos
{
    public class UserAddDto
    {
        [Required] 
        public string Username { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
