using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class BaseEntity
    {
        [Key, HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true), Display(Name = "যোগ করার সময়")]
        public DateTime? CreatedTime { get; set; }
        [HiddenInput(DisplayValue = false)]
        public long CreatorUserId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string CreatorIPAddress { get; set; }

        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss.fff}", ApplyFormatInEditMode = true), Display(Name = "শেষ হালনাগাদের সময়")]
        public DateTime? LastModifiedTime { get; set; }
        [HiddenInput(DisplayValue = false)]
        public long? LastModifireUserId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string LastModifireIPAddress { get; set; }

        /*
        //Concurrency controll - Edit a row same time by 2 users
        [Timestamp]
        public byte[] RowVersion { get; set; }
        */
    }
}
