using CarService.Models;
using CarService.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CarService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarServiceBusinessLogic _services;
        public HomeController(ICarServiceBusinessLogic services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<FileStreamResult> Index(int month)
        {
            var fileStream = await _services.GetInfo(month);
            var file = File(fileStream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "report.xlsx");

            return file;
        }
    }
}