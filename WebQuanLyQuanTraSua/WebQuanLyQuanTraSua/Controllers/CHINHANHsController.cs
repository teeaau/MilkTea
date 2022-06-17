﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQuanLyQuanTraSua.Models;

namespace WebQuanLyQuanTraSua.Controllers
{
    public class CHINHANHsController : Controller
    {
        private QLQuanTraSuaEntities db = new QLQuanTraSuaEntities();

        // GET: CHINHANHs
        public ActionResult Index()
        {
            var cHINHANHs = db.CHINHANHs.Include(c => c.QUANLY);
            return View(cHINHANHs.ToList());
        }

        // GET: CHINHANHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHINHANH cHINHANH = db.CHINHANHs.Find(id);
            if (cHINHANH == null)
            {
                return HttpNotFound();
            }
            return View(cHINHANH);
        }

        // GET: CHINHANHs/Create
        public ActionResult Create()
        {
            ViewBag.MaQL = new SelectList(db.QUANLies, "MaQL", "TenQL");
            return View();
        }

        // POST: CHINHANHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCN,TenCN,DiaChi,SDT,MaQL")] CHINHANH cHINHANH)
        {
            if (ModelState.IsValid)
            {
                db.CHINHANHs.Add(cHINHANH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaQL = new SelectList(db.QUANLies, "MaQL", "TenQL", cHINHANH.MaQL);
            return View(cHINHANH);
        }

        // GET: CHINHANHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHINHANH cHINHANH = db.CHINHANHs.Find(id);
            if (cHINHANH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaQL = new SelectList(db.QUANLies, "MaQL", "TenQL", cHINHANH.MaQL);
            return View(cHINHANH);
        }

        // POST: CHINHANHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCN,TenCN,DiaChi,SDT,MaQL")] CHINHANH cHINHANH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHINHANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaQL = new SelectList(db.QUANLies, "MaQL", "TenQL", cHINHANH.MaQL);
            return View(cHINHANH);
        }

        // GET: CHINHANHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHINHANH cHINHANH = db.CHINHANHs.Find(id);
            if (cHINHANH == null)
            {
                return HttpNotFound();
            }
            return View(cHINHANH);
        }

        // POST: CHINHANHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHINHANH cHINHANH = db.CHINHANHs.Find(id);
            db.CHINHANHs.Remove(cHINHANH);
            db.SaveChanges();
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
