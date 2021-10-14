using System;
using System.Collections.Generic;

namespace Gym.Models
{
  public class Reservation
  {
    public int ReservationId {get; set;}
    public string AmenityReserved {get;set;}
    public DateTime Start {get;set;}
    public DateTime End {get;set;}
    public virtual Amenity Amenity {get;set;}
    public virtual Activity Activity {get;set;}
  }
}