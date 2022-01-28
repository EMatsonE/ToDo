using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<User> result = null;
            using (TodoContext context = new TodoContext())
            {
                result = context.User.ToList();
            }

            return View(result);
        }

        public IActionResult Welcome()
        {
            List<UserTask> result = null;
            using (TodoContext context = new TodoContext())
            {
                result = context.Task.ToList();
            }
            if (result.Count() == 0)
            {
                return View("Create");
            }
            else
            {
                return View(result);
            }
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserTask userTask, IFormCollection collection)
        {
            try
            {
                using (TodoContext context = new TodoContext())
                {
                    context.Task.Add(userTask);
                    context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("Error");
            }
        }

        //public IActionResult Delete()
        //{

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Delete()
        //{

        //}

        //public IActionResult Edit()
        //{

        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Edit()
        //{

        //}


        public IActionResult UserCheck(string email, string password)
        {
            List<User> result = null;
            using (TodoContext context = new TodoContext())
            {
                result = context.User.ToList();
                if (result.Any(x => x.Email == email && x.Password == password))
                {
                    return View("Welcome");
                }
                else
                {
                    return View("Error");
                }
            }
        }


        public IActionResult SaveUser(User user)
        {
            using (TodoContext context = new TodoContext())
            {
                context.User.Add(user);
                context.SaveChanges();
            }
            return Redirect("/");
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
