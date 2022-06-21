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
    public class OrderController : Controller
    {
        private HAWContextEntities db = new HAWContextEntities();

        // GET: admin/Order
        public async Task<ActionResult> Index()
        {
            var tbl_Order = await db.tbl_Order.Include(t => t.tbl_state).ToListAsync();
            return View(tbl_Order);
        }

        // GET: admin/Order/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Order tbl_Order = await db.tbl_Order.FindAsync(id);
            if (tbl_Order == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Order);
        }

        // GET: admin/Order/Create
        public ActionResult Create()
        {
            ViewBag.order_state = new SelectList(db.tbl_state, "state_id", "state_name");
            return View();
        }

        // POST: admin/Order/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "order_id,user_id,order_receiver_note,order_total_price,order_state")] tbl_Order tbl_Order)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Order.Add(tbl_Order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.order_state = new SelectList(db.tbl_state, "state_id", "state_name", tbl_Order.order_state);
            return View(tbl_Order);
        }

        // GET: admin/Order/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Order tbl_Order = await db.tbl_Order.FindAsync(id);
            if (tbl_Order == null)
            {
                return HttpNotFound();
            }
            ViewBag.order_state = new SelectList(db.tbl_state, "state_id", "state_name", tbl_Order.order_state);
            return View(tbl_Order);
        }

        // POST: admin/Order/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "order_id,user_id,order_receiver_note,order_total_price,order_state")] tbl_Order tbl_Order)
        {
            if (ModelState.IsValid)
            {
                var entity = db.tbl_Order.First(x => x.order_id == tbl_Order.order_id);
                entity.order_state = tbl_Order.order_state;
                db.Entry(entity).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.order_state = new SelectList(db.tbl_state, "state_id", "state_name", tbl_Order.order_state);
            return View(tbl_Order);
        }

        // GET: admin/Order/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Order tbl_Order = await db.tbl_Order.FindAsync(id);
            if (tbl_Order == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Order);
        }

        // POST: admin/Order/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_Order tbl_Order = await db.tbl_Order.FindAsync(id);
            db.tbl_Order.Remove(tbl_Order);
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
