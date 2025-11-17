using Microsoft.EntityFrameworkCore;
using Domain.Entity;

namespace Persistence.DbContext
{
    public class DbInitializer
    {
        public static async Task SeedData(AppDbContext context)
        {
            if (await context.Activities.AnyAsync())
            {
                return;
            }

            var activities = new List<Activity>
            {
                new Activity
                {
                    Title = "Past Activity 1",
                    Date = DateTime.Now.AddMonths(-2),
                    Description = "Activity 2 months ago",
                    Category = "drinks",
                    City = "London",
                    Venue = "Pub",
                    Latitude = 51.5074,
                    Longitude = -0.1278
                },
                new Activity
                {
                    Title = "Past Activity 2",
                    Date = DateTime.Now.AddMonths(-1),
                    Description = "Activity 1 month ago",
                    Category = "culture",
                    City = "New York",
                    Venue = "Museum",
                    Latitude = 40.7128,
                    Longitude = -74.0060
                },
                new Activity
                {
                    Title = "Future Activity 1",
                    Date = DateTime.Now.AddMonths(1),
                    Description = "Activity 1 month in future",
                    Category = "culture",
                    City = "Paris",
                    Venue = "Louvre",
                    Latitude = 48.8566,
                    Longitude = 2.3522
                }
            };

            await context.Activities.AddRangeAsync(activities);
            await context.SaveChangesAsync();
        }
    }
}
