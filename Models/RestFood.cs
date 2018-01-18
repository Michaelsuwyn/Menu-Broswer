using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foods.Models
{
    public class RestFood
    {
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int RestId { get; set; }
        public Rest Rest { get; set; }

        
    }
}
