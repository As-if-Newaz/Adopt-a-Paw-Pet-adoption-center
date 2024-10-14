﻿using DAL.EF.TableModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public class AdoptionApplicationDTO
    {
        public int Id { get; set; }

        public string Description { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime ApplicationDate { get; set; }

        public string ApprovalStatus { get; set; }
        [Column(TypeName = "datetime2")]
        public DateTime? ApprovalDate { get; set; }
        public bool IsDeleted { get; set; }

        public int UserId { get; set; }

        public int PetId { get; set; }
    }
}