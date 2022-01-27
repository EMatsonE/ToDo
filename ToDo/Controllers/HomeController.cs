using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index(string email, string password)
        {
            List<User> result = null;
            using (TodoContext context = new TodoContext())
            {
                result = context.User.ToList();
                if (result.Contains(x => x.Email == email))
                {

                }
                else
                {
                    return View("Error");
                }
            }

            return View(result);
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
