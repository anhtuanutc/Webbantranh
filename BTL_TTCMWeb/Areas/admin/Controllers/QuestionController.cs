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
    public class QuestionController : Controller
    {
        private HAWContextEntities db = new HAWContextEntities();

        // GET: admin/Question
        public async Task<ActionResult> Index()
        {
            return View(await db.tbl_question.ToListAsync());
        }

        // GET: admin/Question/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/Question/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "question_id,question")] tbl_question tbl_question)
        {
            if (ModelState.IsValid)
            {
                db.tbl_question.Add(tbl_question);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tbl_question);
        }

        // GET: admin/Question/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_question tbl_question = await db.tbl_question.FindAsync(id);
            if (tbl_question == null)
            {
                return HttpNotFound();
            }
            return View(tbl_question);
        }

        // POST: admin/Question/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "question_id,question")] tbl_question tbl_question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_question).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tbl_question);
        }

        // GET: admin/Question/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_question tbl_question = await db.tbl_question.FindAsync(id);
            if (tbl_question == null)
            {
                return HttpNotFound();
            }
            return View(tbl_question);
        }

        // POST: admin/Question/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tbl_question tbl_question = await db.tbl_question.FindAsync(id);
            db.tbl_question.Remove(tbl_question);
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
