using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurboAz.Enums;

namespace TurboAz.Models
{
    public class Anouncement
    {
        static int count = 0;
        public int Id { get; set; }
        public int March { get; set; }
        public double Price { get; set; }
        public Model Model { get; set; }
        public Banner Banner { get; set; }
        public FuelType FuelType { get; set; }
        public GearBox GearBox { get; set; }
        public Transmission Transmission { get; set; }

        public Anouncement()
        {
            count++;
            this.Id = count;
        }
    }
}
