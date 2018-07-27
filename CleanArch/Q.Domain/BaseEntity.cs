using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime AddedDate { get; set; } = DateTime.Now;

        public DateTime? ModifiedDate { get; set; }

        public int AddedBy { get; set; }

        public int? ModifiedBy { get; set; }

        public bool IsArchived { get; set; }

        public bool IsDeleted { get; set; }

    }
}
