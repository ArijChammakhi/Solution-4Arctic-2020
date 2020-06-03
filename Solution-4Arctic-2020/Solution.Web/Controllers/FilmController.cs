using Solution.Domain.Entities;
using Solution.Service;
using Solution.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Web.Controllers
{
    public class FilmController : Controller
    {
        IfilmService service;
        public FilmController()
        {
            service = new FilmService();
        }
        // GET: Film
        public ActionResult Index(string searchString)
        {
            List<FilmVM> Films = new List<FilmVM>();
            List<Film> FilmDomain = service.GetMany().ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                FilmDomain = FilmDomain.Where(m => m.Title.Contains(searchString)).ToList();
            }
            
            foreach (Film f in service.GetMany())
            {
                Films.Add(new FilmVM
                {
                    Id = f.Id,
                    Description = f.Description,
                    Genre = f.Genre,
                    ImageUrl = f.ImageUrl,
                    OutDate = f.OutDate,
                    Title = f.Title

                }
                );
            }
            return View();
        }

        // GET: Film/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Film/Create
        [HttpPost]
        public ActionResult Create(FilmVM filmVM)
        {
            Film F = new Film()
            {
                Id = filmVM.Id,
                Description = filmVM.Description,
                Genre = filmVM.Genre,
                ImageUrl = filmVM.ImageUrl,
                OutDate = filmVM.OutDate,
                Title = filmVM.Title

            };
            service.Add(F);
            service.Commit();
            return RedirectToAction("Index");
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Film/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Film/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
