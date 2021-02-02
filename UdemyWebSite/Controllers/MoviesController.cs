using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UdemyWebSite.Models;
using UdemyWebSite.ViewModels;

namespace UdemyWebSite.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            Movie movie = new Movie() { Name = "Shrek" };
            List<Customer> customers = new List<Customer>(){ 
                
                new Customer() { Name = "Customer 1"}, 
                new Customer() { Name = "Customer 2"},
                new Customer() { Name = "Customer 3"},
                new Customer() { Name = "Customer 4"},
                new Customer() { Name = "Customer 5"},
                new Customer() { Name = "Customer 6"}

            };

            RandomMovieViewModel viewModel = new RandomMovieViewModel(){

                Movie = movie,
                Customers = customers

            };

            return View(viewModel);
        }

        /* 
         * Attribue for Custom Route; month can contain only 2 digits 
         * and be in range between 1 and 12. Year - only 4 digits 
         */
        
        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1, 12)}")] 
        public ActionResult ByReleaseYear(int year, byte month) 
        {
            return Content(year + "/" + month);
        }
    }
}