using System;
using System.Collections.Generic;

namespace Gym.Models
{
  public class Activity
  {
    public Activity()
    {
      this.PlayerJoinEntities = new HashSet <ActivityPlayer>();
      this.Reservations = new HashSet<Reservation>();
      this.Completed = false;
    }

    public int ActivityId {get;set;}
    public string Name {get;set;}
    public int MaxPlayers {get;set;}
    public string Type {get;set;}
    public bool Completed {get; set;}
    public virtual ICollection <Reservation> Reservations {get;set;}
    public virtual ICollection <ActivityPlayer> PlayerJoinEntities {get;set;}
  }
}