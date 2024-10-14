using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class AdoptionApplication
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime ApplicationDate { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string ApprovalStatus { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ApprovalDate { get; set; }

        public bool IsDeleted { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }
        
        public virtual Pet Pet { get; set; }

        [ForeignKey("Pet")]
        [Required]
        public int PetId { get; set; }

    }
}
