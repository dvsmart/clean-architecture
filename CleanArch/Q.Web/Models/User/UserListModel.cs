using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Q.Web.Models.Base;

namespace Q.Web.Models.User
{
    public class UserListModel : BaseModel
    {
        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string DisplayName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string RoleName { get; set; }
       
    }
}
