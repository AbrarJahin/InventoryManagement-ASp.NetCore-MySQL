using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Advertisement : BaseEntity
    {
        public string Name { get; set; }
        public string Detail { get; set; }
        public string RecordNo { get; set; }
        public DateTime DateOfPublish { get; set; }
        public string AdvertisementImage { get; set; }

        public long OfficeId { get; set; }
        [ForeignKey("OfficeId")]
        public virtual Office OfficeName { get; set; }
    }
}
