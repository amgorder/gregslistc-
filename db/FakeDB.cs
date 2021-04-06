using System.Collections.Generic;
using gregslist.Models;


namespace gregslist.db
{
    public class FakeDB
    {
        public static List<Car> Cars { get; set; } = new List<Car>();
    }
}