using Models.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Projects.Dtos
{
    public class ProjectTaskDto :UtilityDto
    {
        [Required]
        public string Name { get; set; }
        [Required] 
        public string Description { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        [Required] 
        public string StartDate { get; set; }
        [Required] 
        public string EndDate { get; set; }
        public int DifficultyId { get; set; }
        public int StatusId { get; set; }
    }
}
