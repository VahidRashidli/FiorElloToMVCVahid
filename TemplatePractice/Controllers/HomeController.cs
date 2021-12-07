using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TemplatePractice.DAL;
using TemplatePractice.Models;
using TemplatePractice.ViewModels;

namespace TemplatePractice.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            AboutSection aboutSection = _context.AboutSections.FirstOrDefault();
            ICollection<InfoList> infoLists = _context.InfoLists.ToList();
            return View(new HomeIndexViewModel {AboutSection=aboutSection,InfoLists=infoLists });
        }
    }
}
