using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.DbModel
{
    public class JobCircular : BaseEntity
    {
        [Required, MinLength(3), MaxLength(50), Display(Name = "পদের নাম", Prompt = "Name of the Post")]
        public string PostName { get; set; }

        [Required, Display(Name = "এপ্লিকেশন ফর্মের নাম", Prompt = "Name of the Application Form")]
        public ApplicationTypes ApplicationFormat { get; set; }

        [Required, MinLength(9), MaxLength(600), Display(Name = "চাকুরীর বিবরন", Prompt = "Description of the Post")]
        public string Description { get; set; }

        [Required, Display(Name = "পদের সংখ্যা", Prompt = "No Of Total Available Posts")]
        public UInt16 NoOfTotalAvailablePosts { get; set; }

        [Required, MinLength(3), MaxLength(200), Display(Name = "চাকুরীর বিজ্ঞপ্তির ছবি", Prompt = "Should be implemented with file upload")]
        public string NoticeImageFileUrl { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "আবেদনের শেষ দিন", Prompt = "End Date of Application")]
        public DateTime EndDate { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "আবেদন শুরুর দিন", Prompt = "Start Date of Application")]
        public DateTime StartDate { get; set; }

        public virtual ICollection<TeacherApplication> TeacherApplications { get; set; }
    }
}
