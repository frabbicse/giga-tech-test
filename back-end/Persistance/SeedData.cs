using Models.Settings;

using Persistance;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(GigaTechContext context)
        {
            if (!context.ProjectTypes.Any())
            {
                var types = new List<ProjectType>
                {
                    new ProjectType{ TypeName = "HR"},
                    new ProjectType{ TypeName = "Accounts"},
                    new ProjectType{ TypeName = "Marketing"},
                    new ProjectType{ TypeName = "Education"},
                    new ProjectType{ TypeName = "Small Business"},

                };

                {
                    await context.ProjectTypes.AddRangeAsync(types);
                }
            }

            if (!context.DifficultyLevels.Any())
            {
                var levels = new List<DifficultyLevel>
                {
                    new DifficultyLevel{ Name = "easy"},
                    new DifficultyLevel{ Name = "medium"},
                    new DifficultyLevel{ Name = "hard"},

                };


                {
                    await context.DifficultyLevels.AddRangeAsync(levels);
                }

            }
            if (!context.TaskStatuses.Any())
            {
                var status = new List<ProjectTaskStatus>
                {
                    new ProjectTaskStatus{ Name = "New"},
                    new ProjectTaskStatus{ Name = "In-Progress"},
                    new ProjectTaskStatus{ Name = "Done"},

                };


                {
                    await context.TaskStatuses.AddRangeAsync(status);
                }

            }
            await context.SaveChangesAsync();
        }
    }
}
