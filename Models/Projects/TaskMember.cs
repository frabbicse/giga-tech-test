using Models.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Projects
{
    public class TaskMember : UtilityBase
    {
        public int MemberId { get; set; }

        public int ProjectId { get; set; }

        public int TaskId { get; set; }
    }
}
