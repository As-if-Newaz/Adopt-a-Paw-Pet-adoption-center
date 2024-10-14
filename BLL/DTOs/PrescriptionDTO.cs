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
    public class PrescriptionDTO
    {
        public int Id { get; set; }

        public string DrName { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime CheckupDate { get; set; }


        public string Remarks { get; set; }

        public bool IsDeleted { get; set; }

        public int MedicalId { get; set; }

    }
}
