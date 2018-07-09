using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Q.Domain.Asset
{
    public class AssetProperty : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string DataId { get { return "AR" + Id.ToString(); } private set { } }

        public int AssetId { get; set; }
        public string PropertyReference { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }
        public int? CountyId { get; set; }
        public int? CountryId { get; set; }
        public string Postcode { get; set; }
        public string KnownAs { get; set; }

        public decimal? PropertySize { get; set; }
        public decimal? NetInternalSize { get; set; }
        public decimal? GrossInternalSize { get; set; }
        public short? NumberOfFloors { get; set; }
        public short? NumberOfPlantRooms { get; set; }

        public DateTime? StatusStartDate { get; set; }
        public DateTime? StatusArchiveDate { get; set; }

        public virtual Asset Asset { get; set; }
    }
}
