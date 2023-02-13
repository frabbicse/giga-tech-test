using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Auth
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public string FullName { get; set; }
        public int BusinessTypeId { get; set; }
        public string Password { get; set; }
        public string PhoneNo { get; set; }
        public string EmailId { get; set; }
    }
}
