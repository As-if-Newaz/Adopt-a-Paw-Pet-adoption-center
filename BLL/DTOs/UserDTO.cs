using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }


        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public bool Active { get; set; }
        [StringLength(15)]
        public string AuthKey { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime RegDate { get; set; }
        
        public bool IsDeleted { get; set; }
    }
}
