using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class VaccinationDTO
    {
        public int Id { get; set; }


        public string VaccineName { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime VaccineDate { get; set; }
        public bool IsDeleted { get; set; }
 
        public int MedicalId { get; set; }
    }
}
