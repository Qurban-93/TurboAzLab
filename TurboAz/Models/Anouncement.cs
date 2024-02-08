using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboAz.Models
{
    public class Anouncement
    {
        static int count = 0;
        public int Id { get; set; }
        public int March { get; set; }
        public double Price { get; set; }
        public Model Model { get; set; }

        public Anouncement()
        {
            count++;
            this.Id = count;
        }
    }
}
