using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foods.Models
{
    public class Rest
    {
        public int RestId { get; set; }
        public string RestName { get; set; }
        public string Style { get; set; }
        public string Menu { get; set; }
        public string Location { get; set; }
        public ICollection<RestFood> RestFoods { get; set; }
    }
}
