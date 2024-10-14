using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class MedicalRecord
    {
        public int Id { get; set; }

       
        public virtual Pet Pet { get; set; }

        [ForeignKey("Pet")]
        [Required]
        public int PetId { get; set; }
        
        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public virtual ICollection<Prescription>  Prescriptions { get; set; }
        [Required]
        public virtual ICollection<Vaccination> vaccinations { get; set; }

        public MedicalRecord() 
        {
            Prescriptions = new List<Prescription>();
            vaccinations = new List<Vaccination>();
            
        }



    }
}
