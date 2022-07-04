using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Proj3_Khan.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Proj3_Khan.Controllers
{
    public class HomeController : Controller
    {
        private RegistrationContext _context;

        public HomeController(RegistrationContext registrationContext)
        {
            _context = registrationContext;
        }

        //it will create a dropdown list of degree programs
        public IActionResult Index()
        {
            List<SelectListItem> options = new List<SelectListItem>();
            options.Add(new SelectListItem { Text = "Information System", Value = "Information System" });
            options.Add(new SelectListItem { Text = "Information Technology", Value = "Information Technology"});
            options.Add(new SelectListItem { Text = "Project Managment", Value = "Project Managment"});
            options.Add(new SelectListItem { Text = "Data Science", Value = "Data Science"});
            options.Add(new SelectListItem { Text = "Visual Effects", Value = "Visual Effects"});
            options.Add(new SelectListItem { Text = "Business Administration", Value = "Business Administration"});
            options.Add(new SelectListItem { Text = "Film Making", Value = "Film Making"});
            options.Add(new SelectListItem { Text = "Undecided", Value = "Undecided", Selected = true });
            ViewBag.DropDownOptions = options;
            return View();
        }

        [HttpPost]
        public IActionResult Submit(RegisteredUser userInfo)
        {
            if (ModelState.IsValid)
            {
                userInfo.RegistrationDate = DateTime.Now;
                try
                {
                    _context.Add(userInfo);
                    _context.SaveChanges();
                }
                catch(Exception e)
                {
                    View("Error");
                }
                RegisterViewModel vm = new RegisterViewModel();
                vm.UserInfo = userInfo;
                vm.ClientInfo = Request.Headers["User-Agent"].ToString();
                return View("submit", vm);
            }
            else
            {
                ErrorViewModel error = new ErrorViewModel();
                error.Message = "You need to enter required fields.";
                return View("Error", error);
            }
        }

        public IActionResult Registrations(string filter)
        {
            List<RegisteredUser> userInfo;
            if (string.IsNullOrEmpty(filter))
            {
                userInfo = (from r in _context.Registrations select r).ToList();
            }
            else 
            {
                userInfo = (from r in _context.Registrations
                            where r.Name.Contains(filter)
                            select r).ToList();
            }
            return View(userInfo);

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
