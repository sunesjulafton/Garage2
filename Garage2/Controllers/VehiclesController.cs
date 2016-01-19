﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.Models;
using Garage2.Configuration;

namespace Garage2.Controllers
{
    public class VehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        // GET: Vehicles
        public ActionResult Index()
        {
            return View(db.Vehicles.ToList());
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Type,RegNum,Make,Model,Color,WheelCount")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Type,RegNum,Make,Model,Color,WheelCount")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, bool receipt = false)
        {
            
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
            db.SaveChanges();
            if ( receipt == false)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["vehicle"] = vehicle;
                return RedirectToAction("Receipt");
            }

        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Search([Bind(Include = "RegNum")] SearchString str)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(str.RegNum))
                {
                    var list =
                        db.Vehicles.Where(v => v.RegNum.Contains(str.RegNum))
                            .Select(v => v)
                            .ToList();
                    if (list.Count() == 1)
                    {
                        Vehicle vehicle = list[0];
                        return View("Details", vehicle);
                    }
                }
            }
            ModelState.AddModelError("Error", str.RegNum + " hittades inte.");
            return View("Search");
        }


        // GET: Vehicles/Receipt/5

        public ActionResult Receipt()
        {
            Vehicle v = TempData["vehicle"] as Vehicle;
            ViewBag.RegNum = v.RegNum;
            ViewBag.ArrivalTime = v.ArrivalTime;
            ViewBag.Departure = DateTime.Now;

            TimeSpan Duration = ViewBag.Departure.Subtract(ViewBag.ArrivalTime);
            ViewBag.Duration = String.Format("{0} dagar, {1} timmar, {2} minuter", Duration.Days, Duration.Hours, Duration.Minutes);
            ViewBag.TotalPrice = Math.Ceiling(Duration.TotalMinutes * appSettings.PricePerMinute());
            
            

            return View();
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
