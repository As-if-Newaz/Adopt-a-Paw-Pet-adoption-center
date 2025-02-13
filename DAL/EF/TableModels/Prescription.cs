﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF.TableModels
{
    public class Prescription
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string DrName { get; set; }

        [Required]
        [Column(TypeName = "datetime2")]
        public DateTime CheckupDate { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [StringLength(50)]
        public string Remarks { get; set; }

        [Required]
        public bool IsDeleted { get; set; }
        public virtual MedicalRecord MedicalRecord { get; set; }

        [ForeignKey("MedicalRecord")]
        [Required]
        public int MedicalId { get; set; }

    }
}
