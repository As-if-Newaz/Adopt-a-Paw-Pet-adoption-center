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
    public class SuccessStoryDTO
    {
        public int Id { get; set; }


        public string Title { get; set; }

        public string Story { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime AdoptionDate { get; set; }
        public bool IsDeleted { get; set; }

        public int PetId { get; set; }

        public int UserId { get; set; }
    }
}
