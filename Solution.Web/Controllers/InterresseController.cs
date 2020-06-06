using Microsoft.AspNet.Identity;
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
    public class InterresseController : Controller
    {
        ILikeService LikeService;
        public InterresseController()
        {
            LikeService = new likeService();
        }
       

        // GET: Interresse
        public ActionResult Index()
        {
            return View();
        }

        // GET: Interresse/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Interresse/Create
        public ActionResult Create()
        {
            return View();
        }

       
        // POST: Interesse/addLike
        [HttpPost]
        public ActionResult AddLike(LikeVM likevm, int idpa)
        {


            Interesse like = new Interesse();

            like.IdAnnonce = idpa;
            like.UserID = User.Identity.GetUserId();



            LikeService.Add(like);
            LikeService.Commit();




            return View();

        }

        // GET: Interresse/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Interresse/Edit/5
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

        // GET: Interresse/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Interresse/Delete/5
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
