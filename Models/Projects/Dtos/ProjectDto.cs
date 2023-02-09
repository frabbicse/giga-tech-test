using Models.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Projects.Dtos
{
    public class ProjectDto : UtilityDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int ProjectTypeId { get; set; }
        public string Description { get; set; }
    }
}
