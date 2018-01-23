using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class User : IdentityUser<long>  //ID Type = long
    {
        //Username and Password are already created after inhariting IdentityUser
        public string FullName { get; set; }

        //Base Class Properties - Just copy, this system should be updated
        [Key, HiddenInput(DisplayValue = false)]
        public long Id { get; set; }            //Already there, so no need

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

        //Concurrency controll - Edit a row same time by 2 users
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
