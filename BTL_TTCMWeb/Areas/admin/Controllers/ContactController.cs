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
    public class ContactController : Controller
    {
        private readonly HAWContextEntities db = new HAWContextEntities();

        // GET: admin/Contact
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_contact.FirstOrDefaultAsync());
        }

        // GET: admin/Contact/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_contact tbl_contact = await db.tbl_contact.FindAsync(id);
            if (tbl_contact == null)
            {
                return HttpNotFound();
            }
            return View(tbl_contact);
        }

        // POST: admin/Contact/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,name,email,phone,address,comment,time")] tbl_contact tbl_contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_contact).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_contact);
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
