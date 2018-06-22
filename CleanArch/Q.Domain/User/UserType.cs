using System.Collections.Generic;

namespace Q.Domain.User
{
    public class UserType : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<User> Users { get; set; }
    }
}
