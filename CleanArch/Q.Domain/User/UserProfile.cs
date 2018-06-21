using System;
using System.Collections.Generic;
using System.Text;

namespace Q.Domain.User
{
    public class UserProfile : BaseEntity
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string DisplayName { get { return DisplayName; } set { string.Format("{0} {1}", FirstName, LastName); } }

        public string Address { get; set; }

        public string City { get; set; }

        public int PreferredLanguage { get; set; } = 1;

        public virtual User User { get; set; }
        
    }
}
