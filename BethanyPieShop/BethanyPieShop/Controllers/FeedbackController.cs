using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanyPieShop.Controllers
{
    [Authorize]
    public class FeedbackController : Controller
    {
        //Dependency on FeedbackRepository
        private readonly IFeedbackRepository _feedbackRepository;

        //Constructor injection of the FeedbackRepository dependency
        public FeedbackController(IFeedbackRepository feedbackRepository)
        {
            _feedbackRepository = feedbackRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        //This action method is to be invoked when a POST request is recieved
        [HttpPost]
        public IActionResult Index(Feedback feedback)
        {
            //If there are no errors in the ModelState (is valid), add feedback data and display confirm message
            if (ModelState.IsValid)
            {
                _feedbackRepository.AddFeedback(feedback);
                //Redirect user to another action method to display 'Thanks for Feedback'
                return RedirectToAction("FeedbackComplete");
            }
            else {
                //If errors exist in ModelState then return user to same page with the same data.
                return View(feedback);
            }
        }

        public IActionResult FeedbackComplete()
        {
            return View();   
        }
    }
}