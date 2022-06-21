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
    public class ProductColorController : Controller
    {
        private HAWContextEntities db = new HAWContextEntities();

        // GET: admin/ProductColor
        public async Task<ActionResult> Index()
        {
            var tbl_productColor = db.tbl_productColor.Include(t => t.tbl_color).Include(t => t.tbl_product);
            return View(await tbl_productColor.ToListAsync());
        }

        // GET: admin/ProductColor/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_productColor tbl_productColor = await db.tbl_productColor.FindAsync(id);
            if (tbl_productColor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_productColor);
        }

        // GET: admin/ProductColor/Create
        public ActionResult Create(int productId)
        {
            ViewBag.color_id = new SelectList(db.tbl_color, "color_id", "color_name");
            ViewBag.product_id = new SelectList(db.tbl_product.Where(x=>x.product_id == productId), "product_id", "product_name");
            ViewBag.IdProduct = productId;
            return View();
        }

        // POST: admin/ProductColor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,color_id,product_id,size,amount,product_price,product_sale,product_discount")] tbl_productColor tbl_productColor)
        {
            if (ModelState.IsValid)
            {
                db.tbl_productColor.Add(tbl_productColor);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Product");
            }

            ViewBag.color_id = new SelectList(db.tbl_color, "color_id", "color_name", tbl_productColor.color_id);
            ViewBag.product_id = new SelectList(db.tbl_product.Where(x=>x.product_id == tbl_productColor.product_id), "product_id", "product_name", tbl_productColor.product_id);
            return View(tbl_productColor);
        }

        // GET: admin/ProductColor/Edit/5
        public async Task<ActionResult> Edit(int? id, int productId)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_productColor tbl_productColor = await db.tbl_productColor.FindAsync(id);
            if (tbl_productColor == null)
            {
                return HttpNotFound();
            }
            ViewBag.color_id = new SelectList(db.tbl_color, "color_id", "color_name", tbl_productColor.color_id);
            ViewBag.product_id = new SelectList(db.tbl_product.Where(x => x.product_id == productId), "product_id", "product_name", tbl_productColor.product_id);
            ViewBag.IdProduct = productId;
            return View(tbl_productColor);
        }

        // POST: admin/ProductColor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,color_id,product_id,size,amount,product_price,product_sale,product_discount")] tbl_productColor tbl_productColor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_productColor).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Product");
            }
            ViewBag.color_id = new SelectList(db.tbl_color, "color_id", "color_name", tbl_productColor.color_id);
            ViewBag.product_id = new SelectList(db.tbl_product.Where(x => x.product_id == tbl_productColor.product_id), "product_id", "product_name", tbl_productColor.product_id);
            return View(tbl_productColor);
        }

        // GET: admin/ProductColor/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_productColor tbl_productColor = await db.tbl_productColor.FindAsync(id);
            if (tbl_productColor == null)
            {
                return HttpNotFound();
            }
            return View(tbl_productColor);
        }

        // POST: admin/ProductColor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_productColor tbl_productColor = await db.tbl_productColor.FindAsync(id);
            db.tbl_productColor.Remove(tbl_productColor);
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
