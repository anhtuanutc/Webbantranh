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
    public class ColorController : Controller
    {
        private readonly HAWContextEntities db = new HAWContextEntities();

        // GET: admin/Color
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_color.ToListAsync());
        }

        // GET: admin/Color/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_color tbl_color = await db.tbl_color.FindAsync(id);
            if (tbl_color == null)
            {
                return HttpNotFound();
            }
            return View(tbl_color);
        }

        // GET: admin/Color/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Color/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "color_id,color_name,color_img")] tbl_color tbl_color)
        {
            if (ModelState.IsValid)
            {
                db.tbl_color.Add(tbl_color);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_color);
        }

        // GET: admin/Color/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_color tbl_color = await db.tbl_color.FindAsync(id);
            if (tbl_color == null)
            {
                return HttpNotFound();
            }
            return View(tbl_color);
        }

        // POST: admin/Color/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "color_id,color_name,color_img")] tbl_color tbl_color)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_color).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_color);
        }

        // GET: admin/Color/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_color tbl_color = await db.tbl_color.FindAsync(id);
            if (tbl_color == null)
            {
                return HttpNotFound();
            }
            return View(tbl_color);
        }

        // POST: admin/Color/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_color tbl_color = await db.tbl_color.FindAsync(id);
            db.tbl_color.Remove(tbl_color);
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
