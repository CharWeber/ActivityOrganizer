using System;
using System.Collections.Generic;

namespace Gym.Models
{
  public class Player
  {
    public Player()
    {
      this.ActivityJoinEntities = new HashSet<ActivityPlayer>();
    }

    public int PlayerId {get; set;}
    public string Name {get; set;}
    public virtual ICollection <ActivityPlayer> ActivityJoinEntities {get; set;}
  }
}