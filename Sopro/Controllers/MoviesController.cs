using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sopro.Models;
using Sopro.ViewModels;
using System.Data.Entity;

namespace Sopro.Controllers
{
    public class MoviesController : Controller
    {

        private ApplicationDbContext applicationDbContext;

        public MoviesController()
        {
            applicationDbContext = new ApplicationDbContext();
            
        }

        protected override void Dispose(bool disposing)
        {
            applicationDbContext.Dispose();
        }
        // GET: Movies
        public ActionResult Index()
        {

            var movies = applicationDbContext.Movies.ToList();

            return View(movies);
        }
        public ViewResult New()
        {
            var genres=applicationDbContext.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = applicationDbContext.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = applicationDbContext.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult AddMovie(Movie movie, ICollection<Genre> Genres)
        {
            if (movie.Id == 0)
            {
                applicationDbContext.Movies.Add(movie);
            }
            else
            {
                var newMovie=applicationDbContext.Movies.Single(m=>m.Id == movie.Id);
                newMovie.Title = movie.Title;
                //newMovie.GenreId = movie.GenreId;
                newMovie.ReleaseDate=movie.ReleaseDate;
            }

            applicationDbContext.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Details(int id)
        {
            //var genres = movie.Genres/*.ToList();*/
            var movie = applicationDbContext.Movies.Single(m => m.Id == id);
            

            return View(movie);
        }

    }

    
}