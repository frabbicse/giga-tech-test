using Infrastructure.IServices.IHelperService;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services.Helper
{
    public class DateFormat : IDateFormat
    {
        public DateTime Now => DateTime.Now;
         
    }
}
