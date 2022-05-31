using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_APP.Models
{
    public class Country    
    {
        [Key]
        public int CountryId { get; set; }

        [Required]
        [Display(Name = "Country Name")]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
