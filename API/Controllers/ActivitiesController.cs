using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        public ActivitiesController()
        {
        }

        [HttpGet]
        public ActionResult Get()
        {
            var model = new List<Activity>
            {
                new Activity
                {
                    Id = Guid.NewGuid().ToString(),
                    ActivityDateTime = DateTime.Now.AddDays(5),
                    CreatedBy = "Salman",
                    CreatedOn = DateTime.Now,
                    Description = "Learning API development using .NET 6",
                    Title = "API Development",
                    Venue = "Rawalpindi"
                },
                new Activity
                {
                    Id = Guid.NewGuid().ToString(),
                    ActivityDateTime = DateTime.Now.AddDays(5),
                    CreatedBy = "Ahmad",
                    CreatedOn = DateTime.Now,
                    Description = "Database development using MS SQL Server",
                    Title = "Database Development",
                    Venue = "Rawalpindi"
                },
            };

            return Ok(model);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(string id)
        {
            var model = new Activity
            {
                Id = Guid.NewGuid().ToString(),
                ActivityDateTime = DateTime.Now.AddDays(5),
                CreatedBy = "Ahmad",
                CreatedOn = DateTime.Now,
                Description = "Database development using MS SQL Server",
                Title = "Database Development",
                Venue = "Rawalpindi"
            };
            return Ok(model);
        }
    }
}
