using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class BaseEntity
    {
        [Key]
        public long Id { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime? CreatedTime { get; set; }
        public long CreatorUserId { get; set; }
        public string CreatorIPAddress { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true)]
        public DateTime? LastModifiedTime { get; set; }
        public long? LastModifireUserId { get; set; }
        public string LastModifireIPAddress { get; set; }

        /*
        //Concurrency controll - Edit a row same time by 2 users
        [Timestamp]
        public byte[] RowVersion { get; set; }
        */
    }
}
