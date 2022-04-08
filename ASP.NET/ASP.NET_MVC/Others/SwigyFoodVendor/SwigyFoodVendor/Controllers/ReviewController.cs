using SwigyDataRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SwigyFoodVendor.Controllers
{
    public class ReviewController : Controller
    {
        FoodDb _db = new FoodDb();

        // GET: Review
        public ActionResult Index()
        {
            var model = _db.Reviews;

            return View(model);
        }

        // GET: Review/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Review/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Review/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Review/Edit/5
        public ActionResult Edit(int id)
        {
            var review=_db.Reviews.FirstOrDefault(r => r.ID == id);

            return View(review);
        }

        // POST: Review/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var review = _db.Reviews.FirstOrDefault(r => r.ID == id);
            try
            {
                TryUpdateModel(review);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(review);
            }
        }

        // GET: Review/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Review/Delete/5
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
