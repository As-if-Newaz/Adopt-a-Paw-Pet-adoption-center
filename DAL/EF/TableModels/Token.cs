using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Token
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string Key { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CreatedAt { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ExpiredAt { get; set; }

        [Required]
        public bool IsValid { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
    }
}
