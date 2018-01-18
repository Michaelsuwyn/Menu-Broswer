using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foods.Models
{
    public class Food
    {
        public int FoodId { get; set; }
        public string Name { get; set; }
        public string FoodGroup { get; set; }
        public int Calories { get; set; }
        public ICollection<RestFood> RestFoods { get; set; }
    }
}
