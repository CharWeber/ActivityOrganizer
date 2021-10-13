using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Gym.Models;
using System.Collections.Generic;
using System.Linq;

namespace Gym.Controllers
{
  public class PlayersController : Controller
  {
    private readonly GymContext _db;

    public PlayersController(GymContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Players.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }
    
    [HttpPost]
    public ActionResult Create(Player player)
    {
      _db.Players.Add(player);
      _db.SaveChanges();
      return RedirectToAction ("Index");
    }

    public ActionResult Details(int id)
    {
      ViewBag.NoActivities = _db.Activities.ToList().Count == 0;
      ViewBag.ActivityId = new SelectList(_db.Activities, "ActivityId", "Name");
      var thisPlayer = _db.Players
        .Include(player => player.ActivityJoinEntities)
        .ThenInclude(join => join.Activity)
        .FirstOrDefault(player => player.PlayerId == id);
      return View(thisPlayer);
    }

    public ActionResult Edit (int id)
    {
      var thisPlayer = _db.Players.FirstOrDefault(player => player.PlayerId == id);
      return View(thisPlayer);
    }

    [HttpPost]
    public ActionResult Edit(Player player)
    {
      _db.Entry(player).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisPlayer = _db.Players.FirstOrDefault(player => player.PlayerId == id);
      return View(thisPlayer);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisPlayer = _db.Players.FirstOrDefault(player => player.PlayerId == id);
      _db.Players.Remove(thisPlayer);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    // Add Activity
    [HttpPost]
    public ActionResult AddActivity(Player player, int ActivityId)
    {
      if (ActivityId != 0)
      {
        _db.ActivityPlayer.Add(new ActivityPlayer() {PlayerId = player.PlayerId, ActivityId = ActivityId});
      }
      _db.SaveChanges();
      return RedirectToAction ("Index");
    }

    // Remove Activity
    [HttpPost]
    public ActionResult RemoveActivity(int joinId)
    {
      var thisJoin = _db.ActivityPlayer.FirstOrDefault(join => join.ActivityPlayerId == joinId);
      _db.ActivityPlayer.Remove(thisJoin);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }


  }
}