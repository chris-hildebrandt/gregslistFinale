using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gregslistFinale.Models
{
  public class Car
  {
    public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    // int needs to be made nullable with the elvis here or our null check won't work
    public int? Year { get; set; }
    public int? Price { get; set; }
    public string Description { get; set; }
    public string ImgUrl { get; set; }
    public string Color { get; set; }
  }
}