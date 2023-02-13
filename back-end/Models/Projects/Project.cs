using Models.Common;

namespace Models.Projects
{
    public class Project : UtilityBase
    {
        public string Name { get; set; }
        public int ProjectTypeId { get; set; }
        public string Description { get; set; }
    }
}
