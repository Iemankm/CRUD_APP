using CRUD_APP.Data;
using CRUD_APP.Models;
using CRUD_APP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var allstudents = await _db.Students.Include(p => p.Class).Include(p => p.Country).ToListAsync();
            var today = DateTime.Today;
            var years = 0.0;
            foreach (var item in allstudents)
            {
                var age = today.Subtract(item.DOB.DateTime).TotalDays;
                years = (age / 365);
                Math.Round(years);
                item.Age = years;
            }
            var avgAge = 0;
            if (allstudents.Count > 0)
            {
                avgAge = Convert.ToInt32(allstudents.Average(p => p.Age));
            }



            var studentsInClass = await _db.Students.Include(h => h.Class).Where(p => p.ClassId != null).ToListAsync();
            var studentsInCountry = await _db.Students.Include(h => h.Country).Where(p => p.CountryId != null).ToListAsync();
            var classStudents = studentsInClass.Count;
            var countryStudents = studentsInCountry.Count;

            var homeVM = new HomeVM()
            {
                StudentsePerClass = classStudents,
                StudentsPerCountry = classStudents,
                AvgAgeStudents = avgAge,
                Students = allstudents
            };

            return View(homeVM);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
