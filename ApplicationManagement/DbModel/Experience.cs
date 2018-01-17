using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.DbModel
{
    public class Experience : BaseEntity
    {
        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Required]
        public string NameOfPost { get; set; }
        [Required]
        public string NameOfOrganization { get; set; }
        [Required]
        public OrganizationType OrganizationType { get; set; }
        [Required]
        public UInt16 SalaryScale { get; set; }
        [Required]
        public UInt16 TotalSalary { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string CertificatePdfFileUrl { get; set; }

        public TimeSpan ExperienceTime { get; set; }
        
        public Experience()
        {
            ExperienceTime = EndDate - StartDate;
        }
    }
}
