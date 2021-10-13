using Gym.Models;

namespace Gym.Models
{
  public class ActivityPlayer
  {
    public ActivityPlayer()
    {
      this.Completed = false;
    }

    public int ActivityPlayerId {get;set;}
    public int PlayerId {get;set;}
    public int ActivityId {get;set;}
    public bool Completed {get;set;}
    public virtual Player Player {get;set;}
    public virtual Activity Activity {get;set;}

  }
}