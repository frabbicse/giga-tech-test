using Models.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Projects.Dtos
{
    public class TaskMemberDto : UtilityDto
    {
        [Required]
        public int MemberId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int TaskId { get; set; }
    }
}
