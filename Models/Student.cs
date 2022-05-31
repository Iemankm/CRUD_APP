using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_APP.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string Name { get; set; }

        public DateTimeOffset DOB { get; set; }

        [DisplayName("Country")]
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }

        [DisplayName("Class")]
        public int? ClassId { get; set; }
        [ForeignKey("ClassID")]
        public virtual Class Class { get; set; }

        [NotMapped]
        public double Age { get; set; }
    }
}
