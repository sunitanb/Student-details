using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Student_details.Models;

namespace Student_details.Controllers
{
    public class HomeController : Controller
    {
        private tblStudentInfo1Entities db = new tblStudentInfo1Entities();

        // GET: C_tblStudentInfo
        public async Task<ActionResult> Index()
        {
            return View(await db.C_tblStudentInfo.ToListAsync());
        }

        // GET: C_tblStudentInfo/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_tblStudentInfo c_tblStudentInfo = await db.C_tblStudentInfo.FindAsync(id);
            if (c_tblStudentInfo == null)
            {
                return HttpNotFound();
            }
            return View(c_tblStudentInfo);
        }

        // GET: C_tblStudentInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: C_tblStudentInfo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Student_Id,Student_Name,Student_Mobile,Student_Address,Student_Dept")] C_tblStudentInfo c_tblStudentInfo)
        {
            if (ModelState.IsValid)
            {
                db.C_tblStudentInfo.Add(c_tblStudentInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(c_tblStudentInfo);
        }

        // GET: C_tblStudentInfo/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_tblStudentInfo c_tblStudentInfo = await db.C_tblStudentInfo.FindAsync(id);
            if (c_tblStudentInfo == null)
            {
                return HttpNotFound();
            }
            return View(c_tblStudentInfo);
        }

        // POST: C_tblStudentInfo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Student_Id,Student_Name,Student_Mobile,Student_Address,Student_Dept")] C_tblStudentInfo c_tblStudentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c_tblStudentInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(c_tblStudentInfo);
        }

        // GET: C_tblStudentInfo/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            C_tblStudentInfo c_tblStudentInfo = await db.C_tblStudentInfo.FindAsync(id);
            if (c_tblStudentInfo == null)
            {
                return HttpNotFound();
            }
            return View(c_tblStudentInfo);
        }

        // POST: C_tblStudentInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            C_tblStudentInfo c_tblStudentInfo = await db.C_tblStudentInfo.FindAsync(id);
            db.C_tblStudentInfo.Remove(c_tblStudentInfo);
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
