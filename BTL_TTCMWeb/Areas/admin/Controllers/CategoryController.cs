using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTL_TTCMWeb.Models;

namespace BTL_TTCMWeb.Areas.admin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly HAWContextEntities db = new HAWContextEntities();

        // GET: admin/Category
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_category.ToListAsync());
        }

        // GET: admin/Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "category_id,category_name,category_parent")] tbl_category tbl_category)
        {
            if (ModelState.IsValid)
            {
                db.tbl_category.Add(tbl_category);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_category);
        }

        // GET: admin/Category/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_category tbl_category = await db.tbl_category.FindAsync(id);
            if (tbl_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_category);
        }

        // POST: admin/Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "category_id,category_name,category_parent")] tbl_category tbl_category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_category).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_category);
        }

        // GET: admin/Category/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_category tbl_category = await db.tbl_category.FindAsync(id);
            if (tbl_category == null)
            {
                return HttpNotFound();
            }
            return View(tbl_category);
        }

        // POST: admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_category tbl_category = await db.tbl_category.FindAsync(id);
            db.tbl_category.Remove(tbl_category);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
