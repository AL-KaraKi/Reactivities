using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.DbContext;

namespace Reactivities.Controllers
{
    public class ActivitiesController(AppDbContext context) : BaseApiController
    {
        [HttpGet("GetActivities")]
        public async Task<ActionResult<List<Activity>>> GetActivities()
        {
            var activities = await context.Activities.ToListAsync();
            return Ok(activities);
        }

        [HttpGet("GetActivityDetail/{id}")]
        public async Task<ActionResult<Activity>> GetActivityDetail(string id)
        {
            var activity = await context.Activities.FindAsync(id);
            if (activity == null) return NotFound();
            return Ok(activity);
        }
    }
}
