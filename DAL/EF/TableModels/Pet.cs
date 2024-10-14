using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Pet
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Breed { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(200)]
        public string Description { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Location { get; set; }
        [Required]
        public bool IsAvailable { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime DatePosted { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DateAdopted { get; set; }
      
        public virtual User User { get; set; }
        [ForeignKey("User")]
        [Required]
        public int UserId { get; set; }


        public virtual ICollection<AdoptionApplication> AdoptionApplications { get; set; }

        public Pet()
        {
            AdoptionApplications = new List<AdoptionApplication>();
        }

    }
}
