using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
  public  class UtilityBase
    {
        public int Id { get; set; }
        public int PostedBy { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        
    }
}
