using Foods.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Foods.ViewModels
{
    public class RestWithFood
    {
        public int RestId { get; set; }
        public string RestName { get; set; }
        public List<Food> Foods { get; set; }
    }
}
