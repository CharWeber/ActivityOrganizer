using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gym.Models;
using System.Collections.Generic;
using System.Linq;

namespace Gym.Controllers
{
  public class AmenitiesController : Controller
  {
    private readonly GymContext _db;

    public AmenitiesController(GymContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Amenities.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Amenity amenity)
    {
      _db.Amenity.Add(amenity);
      _sb.SaveChagnes();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      ViewBag.NoActivities = _db.Activities.ToList().Count ==0;
      ViewBag.ActivityId = new SelectList(_db.Activities, "ActivityId", "Name");
      var thisAmenity = _db.Amenities
        .Include(amenity => amenity.Reservations)
        .ThenInclude(join => join.Activty)
        .FirstOrDefault(Amenity = Amenity.AmenityId == id);
        return View(thisAmenity);
    }

    public ActionResult Edit (int id)
    {
      var thisAmenity = _db.Amenities.FirstOrDefault(amenity => amenity.AmenityId == id);
      return View(thisAmenity);
    }

    [HttpPost]
    public ActionResult Edit(Amenity amenity)
    {
      _db.Entry(amenity).State = EntityState.Modified;
      _sb.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisAmenity = _db.Amenities.FirstOrDefault(amenity => amenity.AmenityId == id);
      return View(thisAmenity);
    }

    [HttpPost, ActionName("Delete")]
    public Actionresult DeleteConfirmed(int id)
    {
      var thisAmenity = _db.Amenities.FirstOrDefault(amenity => amenity.AmenityId == id);
      _db.Amenities.remove(thisAmenity);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    //add reservation (add activty)
    //remove reservation (remove activity)
    //error .cshtml page
  }
}