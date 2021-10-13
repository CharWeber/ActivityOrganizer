using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Registrar.Models;
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
  }
}