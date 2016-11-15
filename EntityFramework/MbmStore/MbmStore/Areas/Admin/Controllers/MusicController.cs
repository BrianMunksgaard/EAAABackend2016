using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MbmStore.DAL;
using MbmStore.Models;

namespace MbmStore.Areas.Admin.Controllers
{
    public class MusicController : Controller
    {
        /// <summary>
        /// Repository reference.
        /// </summary>
        private IRepository<MusicCD> repo = new ProductRepository<MusicCD>();

        // GET: Admin/Music
        public ActionResult Index()
        {
            return View(repo.GetItems());
        }

        // GET: Admin/Music/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicCD musicCD = repo.GetItem((int)id);
            if (musicCD == null)
            {
                return HttpNotFound();
            }
            return View(musicCD);
        }

        // GET: Admin/Music/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Music/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title,Price,ImageUrl,Category,Artist,Label,Released")] MusicCD musicCD)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.SaveItem(musicCD);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(musicCD);
        }

        // GET: Admin/Music/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MusicCD musicCD = repo.GetItem((int)id);
            if (musicCD == null)
            {
                return HttpNotFound();
            }
            return View(musicCD);
        }

        // POST: Admin/Music/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Title,Price,ImageUrl,Category,Artist,Label,Released")] MusicCD musicCD)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    repo.SaveItem(musicCD);
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(musicCD);
        }

        // GET: Admin/Music/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            MusicCD musicCD = repo.GetItem((int)id);
            if (musicCD == null)
            {
                return HttpNotFound();
            }
            return View(musicCD);
        }

        // POST: Admin/Music/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                MusicCD musicCD = repo.GetItem(id);
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                //db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
