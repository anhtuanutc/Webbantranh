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
    public class ProducerController : Controller
    {
        private HAWContextEntities db = new HAWContextEntities();

        // GET: admin/Producer
        public async Task<ActionResult> Index()
        {
            var tbl_producer = db.tbl_producer.Include(t => t.tbl_state);
            return View(await tbl_producer.ToListAsync());
        }

        // GET: admin/Producer/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_producer tbl_producer = await db.tbl_producer.FindAsync(id);
            if (tbl_producer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_producer);
        }

        // GET: admin/Producer/Create
        public ActionResult Create()
        {
            ViewBag.state = new SelectList(db.tbl_state, "state_id", "state_name");
            return View();
        }

        // POST: admin/Producer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "producer_id,producer_name,producer_address,state")] tbl_producer tbl_producer)
        {
            if (ModelState.IsValid)
            {
                db.tbl_producer.Add(tbl_producer);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.state = new SelectList(db.tbl_state, "state_id", "state_name", tbl_producer.state);
            return View(tbl_producer);
        }

        // GET: admin/Producer/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_producer tbl_producer = await db.tbl_producer.FindAsync(id);
            if (tbl_producer == null)
            {
                return HttpNotFound();
            }
            ViewBag.state = new SelectList(db.tbl_state, "state_id", "state_name", tbl_producer.state);
            return View(tbl_producer);
        }

        // POST: admin/Producer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "producer_id,producer_name,producer_address,state")] tbl_producer tbl_producer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_producer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.state = new SelectList(db.tbl_state, "state_id", "state_name", tbl_producer.state);
            return View(tbl_producer);
        }

        // GET: admin/Producer/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_producer tbl_producer = await db.tbl_producer.FindAsync(id);
            if (tbl_producer == null)
            {
                return HttpNotFound();
            }
            return View(tbl_producer);
        }

        // POST: admin/Producer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_producer tbl_producer = await db.tbl_producer.FindAsync(id);
            db.tbl_producer.Remove(tbl_producer);
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
