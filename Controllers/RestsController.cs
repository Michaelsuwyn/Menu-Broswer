using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Foods.Models;
using Microsoft.EntityFrameworkCore;
using Foods.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Foods.Controllers
{
    [Route("api/[controller]")]
    public class RestsController : Controller
    {

        private ApplicationDbContext _context;

        public RestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Rest> Get()
        {
            return _context.Rests.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public RestWithFood Get(int id)
        {
            RestWithFood rwf = (from r in _context.Rests
                                   where r.RestId == id
                                   select new RestWithFood
                                   {
                                       RestId = r.RestId,
                                       RestName = r.RestName,
                                       Foods = (from rf in _context.RestFoods // this is the join table
                                                 where rf.RestId == r.RestId // where the id's match
                                                 select rf.Food).ToList() // select the actor and add to list
                                   }).FirstOrDefault(); // return first or default like normal.
            return rwf;
        }

        [HttpPost("foods")]
        public string AssignFood([FromBody] RestFood rf)
        {
            //find deck and card in database and pull them
            Rest rest = _context.Rests.FirstOrDefault(r => r.RestId == rf.RestId);
            Food food = _context.Foods.FirstOrDefault(f => f.FoodId == rf.FoodId);

            //make sure deckCards is not null
            if(rest.RestFoods == null)
            {
                rest.RestFoods = new List<RestFood>();
            }

            //setting the properties
            rest.RestFoods.Add(
                new RestFood
                {
                    Rest = rest,
                    Food = food
                });
            _context.SaveChanges();
            return "success";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Rest rest)
        {
            _context.Add(rest);
            _context.SaveChanges();

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Rest rest)
        {
            Rest updater = _context.Rests.SingleOrDefault<Rest>(r => r.RestId == id);
            updater.RestName = rest.RestName;
            updater.Style = rest.Style;
            updater.Menu = rest.Menu;
            updater.Location = rest.Location;
            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Rest deleter = _context.Rests.SingleOrDefault<Rest>(r => r.RestId == id);
            _context.Rests.Remove(deleter);
            _context.SaveChanges();

        }
    }
}
