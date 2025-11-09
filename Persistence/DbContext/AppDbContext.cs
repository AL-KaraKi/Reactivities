namespace Persistence.DbContext
{
    using Domain.Entity;
    using Microsoft.EntityFrameworkCore;

    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        #region -- Constructor --


        #endregion


        #region -- DB Set --

        public required DbSet<Activity> Activities { get; set; }
        
        #endregion
    }
}