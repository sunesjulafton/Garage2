using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Garage2.Models;
using Garage2.Configuration;
using System.Globalization;
using Garage2.Utilities;

namespace Garage2.Controllers
{
    public class VehiclesController : Controller
    {
        private GarageContext db = new GarageContext();

        //// GET: Vehicles
        //public ActionResult Index()
        //{
        //    //IndexModel model = new IndexModel(db.Vehicles.ToList(), new SortElement());


        //    //var data = db.Vehicles.ToList();

        //    //var tupleModel = new Tuple<List<Vehicle>, SortElement>(data, new SortElement());

        //    return View(db.Vehicles.ToList());
        //}


        public ActionResult Index()
        {
            //ViewBag.NameSortParm = sortOrder == "RegNum" ? "RegNum_desc" : "RegNum";

            var param = Request["sortOrder"];
            var list = db.Vehicles.Select(v => v);

            if (param != null) { 
                switch (param.ToString())
                {
                    case "RegNum":
                        list = list.OrderBy(v => v.RegNum);
                        break;
                    case "Type":
                        list = list.OrderBy(v => v.Type.ToString());
                        break;
                    case "Make":
                        list = list.OrderBy(v => v.Make);
                        break;
                    case "Model":
                        list = list.OrderBy(v => v.Model);
                        break;
                    case "Color":
                        list = list.OrderBy(v => v.Color);
                        break;
                    case "ArrivalTime":
                        list = list.OrderBy(v => v.ArrivalTime);
                        break;
                    default:
                        list = list.OrderBy(v => v.RegNum);
                        break;
                }
                ViewBag.SelectedOrder = param.ToString();
            }
            return View(list.ToList()   );
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
                bool valid = true;
                // Check if the same duplicate reg numbers exist with the same type
                var list =
                    db.Vehicles.Where(v => v.RegNum.Contains(vehicle.RegNum) && v.Type == vehicle.Type)
                        .Select(v => v)
                        .ToList();
                if (list.Count() > 0)
                {
                    valid = false;
                }

                // Check if duplicates exist within a category of vehicles
                if ((vehicle.Type == VehicleTypes.Bus) ||
                    (vehicle.Type == VehicleTypes.Car) ||
                    (vehicle.Type == VehicleTypes.Motorcycle))
                {
                    list =
                        db.Vehicles.Where(v => v.RegNum.Contains(vehicle.RegNum))
                            .Select(v => v)
                            .ToList();

                    if (list.Count > 0)
                    {
                        foreach (var item in list)
                        {
                            if ((item.Type == VehicleTypes.Bus) ||
                                (item.Type == VehicleTypes.Car) ||
                                (item.Type == VehicleTypes.Motorcycle))
                            {
                                valid = false;
                            }
                        }
                    }

                }

                if (valid)
                {
                    vehicle.ArrivalTime = DateTime.Now;
                    vehicle.RegNum = vehicle.RegNum.ToUpper();
                    db.Vehicles.Add(vehicle);
                    db.SaveChanges();
                }
                else
                {
                    ModelState.AddModelError("RegNum", "Fordon är redan parkerat");
                    return View("Create");
                }
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
        public ActionResult Edit([Bind(Include = "Id,Type,RegNum,Make,Model,Color,WheelCount, ArrivalTime")] Vehicle vehicle)
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
            if (receipt == false)
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
                    else if (list.Count > 1)
                    {
                        return View("Index", list);
                    }
                    else
                    {
                        ModelState.AddModelError("RegNum", "Fordonet hittades inte.");
                    }
                }
            }
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
            var price = Math.Floor(Duration.TotalMinutes * appSettings.PricePerMinute());
            ViewBag.TotalPrice = price.ToString("C",
                  CultureInfo.CreateSpecificCulture("sv-SE"));

            return View();
        }

        public ActionResult Statistics()
        {
            ViewBag.Tires = CalculateStatistics.CountTiresInDb(db.Vehicles.ToList());
            ViewBag.Types = CalculateStatistics.CountTypesInDb(db.Vehicles.ToList());
            ViewBag.Colors = CalculateStatistics.CountColorOfTypesInDb(db.Vehicles.ToList());
            ViewBag.Makes =  CalculateStatistics.CountMakeInDb(db.Vehicles.ToList());

            

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
