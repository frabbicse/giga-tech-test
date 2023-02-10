using Microsoft.EntityFrameworkCore;

using Models;
using Models.Auth;
using Models.Projects;
using Models.Settings;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace Persistance
{
    public class GigaTechContext : DbContext
    {
      public GigaTechContext(DbContextOptions options) : base(options)
        { }

        // authentication , authorization
        public DbSet<Register> Register{ get; set; }
        public DbSet<Login> Login{ get; set; }

        public DbSet<Role> Roles{ get; set; }


        // project related
        public DbSet<Project> Projects{ get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }

        //settings
        public DbSet<ProjectType> ProjectTypes{ get; set; }
        public DbSet<DifficultyLevel> DifficultyLevels { get; set; }
        public DbSet<ProjectTaskStatus> TaskStatuses { get; set; }
 
    }
}
