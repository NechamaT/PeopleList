using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PeopleList.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PeopleList.Data;

namespace PeopleList.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=PeopleDb;Integrated Security=true;";


        public IActionResult Index()
        {
            var db = new PeopleDb(_connectionString);
            var vm = new IndexViewModel
            {
                People = db.GetAllPeople()
            };
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }

        public IActionResult AddPeople()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPeople(List<Person> people)
        {
            var db = new PeopleDb(_connectionString);
            db.AddPeople(people);
            if (people.Count > 1)
            {
                TempData["message"] = "People added successfully!";
            }
            else
            {
                TempData["message"] = "Person added successfully!";
            }

            return Redirect("/");

            

        }
    }
}
