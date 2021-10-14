using System;
using System.Collections.Generic;

namespace Gym.Models
{
  public class Amenity
  {
    public Amenity()
    {
      this.Reservations = new HashSet<Reservation>();
    }
    public int AmenityId { get; set; }
    public string Name { get; set; }
    public bool ReservationRequired {get;set;}
    public DateTime Open { get; set; }
    public DateTime Close { get; set; }
    public virtual ICollection <Reservation> Reservations {get;set;}
  }
}