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

namespace HAW.Areas.admin.Controllers
{
    public class EmployeeController : Controller
    {
        private HAWContextEntities db = new HAWContextEntities();

        // GET: admin/Employee
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_admin.ToListAsync());
        }

        // GET: admin/Employee/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_admin tbl_admin = await db.tbl_admin.FindAsync(id);
            if (tbl_admin == null)
            {
                return HttpNotFound();
            }
            return View(tbl_admin);
        }

        // GET: admin/Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "admin_id,admin_name,admin_password,admin_phone,admin_email,admin_isEmployee")] tbl_admin tbl_admin)
        {
            if (ModelState.IsValid)
            {
                db.tbl_admin.Add(tbl_admin);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_admin);
        }

        // GET: admin/Employee/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_admin tbl_admin = await db.tbl_admin.FindAsync(id);
            if (tbl_admin == null)
            {
                return HttpNotFound();
            }
            return View(tbl_admin);
        }

        // POST: admin/Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "admin_id,admin_name,admin_password,admin_phone,admin_email,admin_isEmployee")] tbl_admin tbl_admin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_admin).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_admin);
        }

        // GET: admin/Employee/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_admin tbl_admin = await db.tbl_admin.FindAsync(id);
            if (tbl_admin == null)
            {
                return HttpNotFound();
            }
            return View(tbl_admin);
        }

        // POST: admin/Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_admin tbl_admin = await db.tbl_admin.FindAsync(id);
            db.tbl_admin.Remove(tbl_admin);
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
