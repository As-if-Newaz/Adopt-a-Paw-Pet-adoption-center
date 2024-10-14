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
    public class MedicalRecordDTO
    {
        public int Id { get; set; }


        public int PetId { get; set; }

        public bool IsDeleted { get; set; }

    }
}
