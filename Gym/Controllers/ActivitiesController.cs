using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gym.Models;
using System.Collections.Generic;
using System.Linq;

namespace Gym.Controllers
{
  public class ActivitiesController : Controller
  {

  private readonly GymContext _db;

  public ActivitiesController(GymContext db)
  {
    _db = db;
  }

  public ActionResult Index()
  {
    return View(_db.Activities.ToList());
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Activity activity)
  {
    _db.Activities.Add(activity);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Details(int id)
  {
    ViewBag.NoPlayers = _db.Players.ToList().Count == 0;
    ViewBag.PlayerId = new SelectList(_db.Players, "PlayerId", "Name");
    var thisActivity = _db.Activities
      .Include(activity => activity.PlayerJoinEntities)
      .ThenInclude(join => join.Activity)
      .FirstOrDefault(activity =>activity.ActivityId == id);
    return View(thisActivity);
  }

  public ActionResult Edit(int id)
  {
    var thisActivity = _db.Activities.FirstOrDefault(activity => activity.ActivityId == id);
    return View (thisActivity);
  }

  [HttpPost]
  public ActionResult Edit(Activity activity)
  {
    _db.Entry(activity).State = EntityState.Modified;
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  public ActionResult Delete(int id)
  {
    var thisActivity = _db.Activities.FirstOrDefault(activty => activty.ActivityId == id);
    return View(thisActivity);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    var thisActivity = _db.Activities.FirstOrDefault(activity => activity.ActivityId == id);
    _db.Activities.Remove(thisActivity);
    _db.SaveChanges();
    return RedirectToAction ("Index");
  }

  // add Player
  [HttpPost]
  public ActionResult AddPlayer(Activity activity, int PlayerId)
  {
    if (PlayerId != 0)
    {
      _db.ActivityPlayer.Add(new ActivityPlayer() {PlayerId = PlayerId, ActivityId = activity.ActivityId});
    }
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  // remove Player
  [HttpPost]
  public ActionResult RemovePlayer(int joinId)
  {
    var thisJoin = _db.ActivityPlayer.FirstOrDefault(join => join.ActivityPlayerId == joinId);
    _db.ActivityPlayer.Remove(thisJoin);
    _db.SaveChanges();
    return RedirectToAction("Index");
  }

  //Complete Activity
  [HttpPost]
  public ActionResult CompleteActivity(int ActivityId)
  {
    var thisActivity = _db.Activities.FirstOrDefault(activity => activity.ActivityId == ActivityId);
    thisActivity.Completed = true; 
    _db.SaveChanges();
    return RedirectToAction("Index");
  }
  }
}