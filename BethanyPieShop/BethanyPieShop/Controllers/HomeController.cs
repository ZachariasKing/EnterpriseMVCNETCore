using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BethanyPieShop.Models;
using BethanyPieShop.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanyPieShop.Controllers
{
    //HomeController inherits from base 'Controller' class.
    //The controller will be using the repositories to talk with the model
    public class HomeController : Controller
    {
        //This variable needs to be created in order to help with dependency injection pattern.
        private readonly IPieRespository _pieRespository;

        public HomeController(IPieRespository pieRespository)
        {
            _pieRespository = pieRespository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            //The view bag is an object that will allow us to send data to the view
            //ViewBag.Title = "Pie Overview";

            //Assigning an ordered IEnumerable List to 'pies'
            var pies = _pieRespository.GetAllPies().OrderBy(p => p.Name);

            //Creating a new Home ViewModel as a means of one source to handle all of the data passing to the view. So, in a sense
            //the variable initialised here is a model in it's own right.
            var homeViewModel = new HomeViewModel()
            {
                Title = "Welcome to Bethany's Pie Shop",
                Pies = pies.ToList()
            };

            
            //Passing the list of pies to the view
            return View(homeViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRespository.GetPieById(id);
            if (pie == null)
            {
                return NotFound();
            }
            return View(pie);
        }
    }
}
