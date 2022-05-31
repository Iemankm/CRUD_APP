using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_APP.Models.ViewModels
{
    public class HomeVM
    {
        public HomeVM()
        {
            AvgAgeStudents = 0;
            StudentsPerCountry = 0;
            StudentsePerClass = 0;
        }
        public int AvgAgeStudents { get; set; }

        public int StudentsePerClass { get; set; }

        public int StudentsPerCountry { get; set; }

        public List<Student> Students { get; set; }

    }
}
