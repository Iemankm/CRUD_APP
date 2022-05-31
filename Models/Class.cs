using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_APP.Models
{
    public class Class
    {
        [Key]
        public int ClassId { get; set; }

        [Required]
        [DisplayName("Class Name")]
        public string Name { get; set; }

        public ICollection<Student> Students { get; set; } = new HashSet<Student>();
    }
}
