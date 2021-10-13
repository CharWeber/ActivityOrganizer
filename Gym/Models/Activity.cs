using System;
using System.Collections.Generic;

namespace Gym.Models
{
  public class Activity
  {
    public Activity()
    {
      this.PlayerJoinEntity = new HashSet <ActivityPlayer>();
    }

    public int ActivityId {get;set;}
    public string Name {get;set;}
    public int MaxPlayers {get;set;}
    public string Type {get;set;}
    public virtual ICollection <ActivityPlayer> PlayerJoinEntity {get;set;}
  }
}