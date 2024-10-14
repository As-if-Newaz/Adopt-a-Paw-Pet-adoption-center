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
    public class PetDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Breed { get; set; }

        public int Age { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public bool IsAvailable { get; set; }
        public bool IsDeleted { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime DatePosted { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? DateAdopted { get; set; }

        public int UserId { get; set; }


    }
}
