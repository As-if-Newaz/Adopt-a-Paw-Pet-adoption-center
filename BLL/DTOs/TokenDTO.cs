using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }
        [StringLength(15)]
        public string Key { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ExpiredAt { get; set; }

        public bool IsValid { get; set; }

        public string UserId { get; set; }
    }
}
