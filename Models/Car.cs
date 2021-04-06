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

        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public string Url { get; set; }






    }
}