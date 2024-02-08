using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurboAz.Models
{
    public class Model
    {
        static int count = 0;
        public int Id { get; private set; }
        public string Name { get; set; }
        public Marka? Marka { get; set; }

        public Model()
        {
            count++;
            this.Id = count;
        }
    }
}
