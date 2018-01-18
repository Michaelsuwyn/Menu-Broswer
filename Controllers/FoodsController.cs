using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Foods.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foods.Controllers
{
    [Route("api/[controller]")]
    public class FoodsController : Controller
    {
        private ApplicationDbContext _context;
        public FoodsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return _context.Foods.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Food Get(int id)
        {
            Food getter = _context.Foods.SingleOrDefault<Food>(f => f.FoodId == id);
            return getter;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Food food)
        {
            _context.Add(food);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Food food)
        {
            Food updater = _context.Foods.SingleOrDefault<Food>(f => f.FoodId == id);
            updater.Name = food.Name;
            updater.FoodGroup = food.FoodGroup;
            updater.Calories = food.Calories;
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Food deleter = _context.Foods.SingleOrDefault<Food>(f => f.FoodId == id);
            _context.Foods.Remove(deleter);
            _context.SaveChanges();
        }
    }
}
