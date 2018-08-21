﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.User
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public string EmailAddress { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public bool IsActive { get; set; } = true;

        public int UserRoleId { get; set; }

        public int UserTypeId { get; set; }

        public virtual UserProfile UserProfile { get; set; }

        public virtual UserRole UserRole { get; set; }

        public virtual UserType UserType { get; set; }

    }
}
