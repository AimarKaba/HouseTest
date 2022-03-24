using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace House.Models.House
{
    public class HouseListItem
    {
        public Guid? Id { get; set; }
        public string Category { get; set; }
        public string Address { get; set; }
        public double Size { get; set; }
        public double Rooms { get; set; }
        public double Price { get; set; }
        public DateTime ListedAt { get; set; }
    }
}
