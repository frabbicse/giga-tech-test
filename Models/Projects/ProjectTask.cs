using Models.Common;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Projects
{
    public   class ProjectTask : UtilityBase
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public int MemberId { get; set; }
        public string StartDate { get; set; }

        public string EndDate { get; set; }
        public int DifficultyId { get; set; }
        public int StatusId { get; set; }
    }
}
