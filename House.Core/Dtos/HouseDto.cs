using System;
using System.Collections.Generic;
using System.Text;

namespace House.Core.Dtos
{
    public class HouseDto
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
