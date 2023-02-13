using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IServices.IHelperService
{
  public  interface IDateFormat
    {
        DateTime Now { get; }
    }
}
