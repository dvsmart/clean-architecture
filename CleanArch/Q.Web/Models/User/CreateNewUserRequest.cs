﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q.Web.Models.User
{
    public class CreateNewUserRequest : BaseModel
    {
        public string EmailAddress { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public int RoleId { get; set; }

        public int TypeId { get; set; }
    }
}
