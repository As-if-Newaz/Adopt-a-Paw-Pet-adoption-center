using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Password { get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Role {  get; set; }
        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Phone { get; set; }

        [Column(TypeName = "VARCHAR")]
        [Required]
        [StringLength(50)]
        public string Address { get; set; }
        [Required]
        public bool Active { get; set; }
        [Required]
        [StringLength(15)]
        public string AuthKey { get; set; }
        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime RegDate { get; set; }
        [Required]
        public bool IsDeleted { get; set; }

        public virtual ICollection<Pet> Pets { get; set; }

        public virtual ICollection<SuccessStory> successStories { get; set; }

        public virtual ICollection<AdoptionApplication> AdoptionApplications { get; set; }

        public User()
        {
            Pets = new List<Pet>();
            successStories = new List<SuccessStory>();
            AdoptionApplications = new List<AdoptionApplication>();
        }
    }
}
