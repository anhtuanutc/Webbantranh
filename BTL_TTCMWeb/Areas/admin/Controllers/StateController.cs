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
    public class StateController : Controller
    {
        private HAWContextEntities db = new HAWContextEntities();

        // GET: admin/State
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_state.ToListAsync());
        }

        // GET: admin/State/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_state tbl_state = await db.tbl_state.FindAsync(id);
            if (tbl_state == null)
            {
                return HttpNotFound();
            }
            return View(tbl_state);
        }

        // GET: admin/State/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/State/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "state_id,state_name")] tbl_state tbl_state)
        {
            if (ModelState.IsValid)
            {
                db.tbl_state.Add(tbl_state);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_state);
        }

        // GET: admin/State/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_state tbl_state = await db.tbl_state.FindAsync(id);
            if (tbl_state == null)
            {
                return HttpNotFound();
            }
            return View(tbl_state);
        }

        // POST: admin/State/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "state_id,state_name")] tbl_state tbl_state)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_state).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_state);
        }

        // GET: admin/State/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_state tbl_state = await db.tbl_state.FindAsync(id);
            if (tbl_state == null)
            {
                return HttpNotFound();
            }
            return View(tbl_state);
        }

        // POST: admin/State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_state tbl_state = await db.tbl_state.FindAsync(id);
            db.tbl_state.Remove(tbl_state);
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
