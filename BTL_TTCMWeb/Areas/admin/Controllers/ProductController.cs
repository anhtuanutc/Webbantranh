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
    public class ProductController : Controller
    {
        private HAWContextEntities db = new HAWContextEntities();

        // GET: admin/Product
        public async Task<ActionResult> Index()
        {
            var tbl_product = db.tbl_product.Include(t => t.tbl_category).Include(t => t.tbl_producer).Include(t => t.tbl_state);
            return View(await tbl_product.ToListAsync());
        }

        // GET: admin/Product/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_product tbl_product = await db.tbl_product.FindAsync(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_product);
        }

        // GET: admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.category_id = new SelectList(db.tbl_category, "category_id", "category_name");
            ViewBag.product_producer = new SelectList(db.tbl_producer, "producer_id", "producer_name");
            ViewBag.state = new SelectList(db.tbl_state, "state_id", "state_name");
            return View();
        }

        // POST: admin/Product/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "product_id,product_name,product_alias,product_description,product_content,product_img,product_sub_img,product_isHot,product_isNew,product_isSale,product_CreatedAt,product_UpdatedAt,product_code,product_package,product_delivery,product_delivery_time,product_payment,product_payment_type,product_sub_info,state,title_seo,des_seo,friendly_url,keyword,product_material,product_shape,product_producer,category_id")] tbl_product tbl_product)
        {
            if (ModelState.IsValid)
            {
                db.tbl_product.Add(tbl_product);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.category_id = new SelectList(db.tbl_category, "category_id", "category_name", tbl_product.category_id);
            ViewBag.product_producer = new SelectList(db.tbl_producer, "producer_id", "producer_name", tbl_product.product_producer);
            ViewBag.state = new SelectList(db.tbl_state, "state_id", "state_name", tbl_product.state);
            return View(tbl_product);
        }

        // GET: admin/Product/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_product tbl_product = await db.tbl_product.FindAsync(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            ViewBag.category_id = new SelectList(db.tbl_category, "category_id", "category_name", tbl_product.category_id);
            ViewBag.product_producer = new SelectList(db.tbl_producer, "producer_id", "producer_name", tbl_product.product_producer);
            ViewBag.state = new SelectList(db.tbl_state, "state_id", "state_name", tbl_product.state);
            return View(tbl_product);
        }

        // POST: admin/Product/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "product_id,product_name,product_alias,product_description,product_content,product_img,product_sub_img,product_isHot,product_isNew,product_isSale,product_CreatedAt,product_UpdatedAt,product_code,product_package,product_delivery,product_delivery_time,product_payment,product_payment_type,product_sub_info,state,title_seo,des_seo,friendly_url,keyword,product_material,product_shape,product_producer,category_id")] tbl_product tbl_product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_product).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.category_id = new SelectList(db.tbl_category, "category_id", "category_name", tbl_product.category_id);
            ViewBag.product_producer = new SelectList(db.tbl_producer, "producer_id", "producer_name", tbl_product.product_producer);
            ViewBag.state = new SelectList(db.tbl_state, "state_id", "state_name", tbl_product.state);
            return View(tbl_product);
        }

        // GET: admin/Product/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_product tbl_product = await db.tbl_product.FindAsync(id);
            if (tbl_product == null)
            {
                return HttpNotFound();
            }
            return View(tbl_product);
        }

        // POST: admin/Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_product tbl_product = await db.tbl_product.FindAsync(id);
            db.tbl_product.Remove(tbl_product);
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
