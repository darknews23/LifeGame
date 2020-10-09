using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Life.AspNetCoreMVC.Models;
using Life.DAL.DatabaseFirst.Repositories;

namespace Life.AspNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SessionsRepo _sessionsRepo;

        public HomeController(ILogger<HomeController> logger, SessionsRepo sessionsRepo)
        {
            _logger = logger;
            _sessionsRepo = sessionsRepo;
        }

        public IActionResult Index()
        {
            return View();
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

        public IActionResult GameSessions()
        {
            var model = new GameSessionsViewModel(){SessionsInfo = _sessionsRepo.Get().ToList()};
            return View(model);
        }
    }
}
