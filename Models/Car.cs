using System;
using System.ComponentModel.DataAnnotations;

namespace gregslist.Models
{
    public class Car
    {
        public Car(string make, string model, int year, string color, decimal price, string url)
        {
            Make = make;
            Model = model;
            Year = year;
            Color = color;
            Price = price;
            Url = url;

        }

        public Car()
        {

        }

        [Required]
        public string Make { get; set; }
        [Required]
        public string Model { get; set; }
        public int? Year { get; set; }
        public string Color { get; set; }
        [Range(0, 4)]
        public decimal? Price { get; set; }
        public string Url { get; set; }
        public int Id { get; set; }



    }
}