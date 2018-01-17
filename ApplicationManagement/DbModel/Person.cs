using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.DbModel
{
    public class Person : BaseEntity
    {
        [Required, MinLength(3), MaxLength(200)]
        public string ProfileImageFileUrl { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string BengaliName { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string EnglishName { get; set; }
        [Required, MinLength(3), MaxLength(20)]
        public string NickName { get; set; }

        [Required, Phone, MinLength(9), MaxLength(16)]
        public string PhoneNumber { get; set; }
        [Required, EmailAddress, MinLength(4), MaxLength(50)]
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Check email address format!")]
        public string Email { get; set; }

        [Required, MinLength(3), MaxLength(50)]
        public string FatherName { get; set; }
        [MinLength(3), MaxLength(50)]
        public string SpouceName { get; set; }
        [MinLength(3), MaxLength(50)]
        public string MotherName { get; set; }

        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime DateOfBirth { get; set; }

        public long PresentAddressId { get; set; }
        [Required, ForeignKey("PresentAddressId")]
        public virtual Address PresentAddress { get; set; }

        public long PermanentAddressId { get; set; }
        [Required, ForeignKey("PermanentAddressId")]
        public virtual Address PermanentAddress { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Nationality { get; set; }
        [Required]
        public IsMarried MaritalStatus { get; set; }
        [Required]
        public ReligionName Religion { get; set; }
        [Required, Range(1000000000, 99999999999999999)]                    //Should Be Key
        public UInt64 NId { get; set; }

        public virtual ICollection<EducationResult> EducationalResults { get; set; }

        public virtual ICollection<ResearchDegree> ResearchDegries { get; set; }
        public virtual ICollection<Research> Researches { get; set; }
        public virtual ICollection<Language> Languages { get; set; }
        public virtual ICollection<Training> Trainings { get; set; }
        public virtual ICollection<Experience> Experiences { get; set; }

        public virtual ICollection<Reference> References { get; set; }

        [MinLength(9), MaxLength(600)]
        public string VolunteerExperience { get; set; }
        public virtual ICollection<CountryPerson> VisitedCountries { get; set; }

        [Required]
        public Decision IsInvolvedWithAnyAssociation { get; set; }
        [MinLength(3), MaxLength(50)]
        public string NameOfAssociation { get; set; }
        [MinLength(9), MaxLength(600)]
        public string DescriptionOfAssociation { get; set; }

        [Required]
        public Decision IsEverSuspended { get; set; }
        [MinLength(9), MaxLength(600)]
        public string SuspensionReason { get; set; }

        public virtual ICollection<TeacherApplication> TeacherApplications { get; set; }
    }
}
