using System;
using System.ComponentModel.DataAnnotations;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.ViewModel
{
    public class TeacherApplication
    {
        public long JobCircularId { get; set; }

        //No 1 in form
        [Required(ErrorMessage = "আপনার বাংলা নাম লিখুন"), MinLength(3, ErrorMessage = "বাংলা নাম ৩ অক্ষরের বড় হতে হবে"), MaxLength(50, ErrorMessage = "বাংলা নাম ৫০ অক্ষরের ছোট হতে হবে"), Display(Name = "বাংলা নাম", Prompt = "Bengali Name")]
        public string BengaliName { get; set; }
        [Required(ErrorMessage = "আপনার ইংরেজী নাম লিখুন"), MinLength(3, ErrorMessage = "ইংরেজী নাম ৩ অক্ষরের বড় হতে হবে"), MaxLength(50, ErrorMessage = "ইংরেজী নাম ৫০ অক্ষরের ছোট হতে হবে"), Display(Name = "ইংরেজী নাম", Prompt = "English Name")]
        public string EnglishName { get; set; }
        [Required(ErrorMessage = "আপনার  ডাকনাম লিখুন"), MinLength(3, ErrorMessage = "ডাকনাম ৩ অক্ষরের বড় হতে হবে"), MaxLength(20, ErrorMessage = "ডাকনাম 2০ অক্ষরের ছোট হতে হবে"), Display(Name = "প্রার্থী যে নামে পরিচিত", Prompt = "Nickname")]
        public string NickName { get; set; }

        [Required, MinLength(9), MaxLength(16), Phone]
        public string PhoneNumber { get; set; }
        [Required, MinLength(4), MaxLength(50), EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(3), MaxLength(50), Display(Name = "Father Name")]
        public string FatherName { get; set; }  //No 2 in form
        [MinLength(3), MaxLength(50), Display(Name = "Spouce Name")]
        public string SpouceName { get; set; }  //No 3 in form
        [MinLength(3), MaxLength(50), Display(Name = "Mother Name")]
        public string MotherName { get; set; }  //No 4 in form

        //Present Address
        [Required, MinLength(3), MaxLength(50)]
        public string PresentHoldingNoOrVillage { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string PresentRoadBlockSector { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string PresentThana { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string PresentPostOffice { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string PresentDistrict { get; set; }

        //Permanent Address
        [Required, MinLength(3), MaxLength(50)]
        public string PermanentHoldingNoOrVillage { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string PermanentRoadBlockSector { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string PermanentThana { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string PermanentPostOffice { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string PermanentDistrict { get; set; }

        //No 5 in form
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        [Required, MinLength(3), MaxLength(20)]
        public string Nationality { get; set; }         //No 8 in form
        [Required, Display(Name = "Marital Status")]
        public IsMarried MaritalStatus { get; set; }    //No 9 in form
        [Required, Display(Name = "Religion Name")]
        public ReligionName Religion { get; set; }      //No 10 in form
        [Required, Range(1000000000, 99999999999999999), Display(Name = "National ID Card No.")]
        public UInt64 NId { get; set; }                 //No 11 in form

        //No 18 in form
        [Required, Display(Name = "Has Contact With Any Organization")]
        public Decision HasContactWithAnyOrganization { get; set; }
        [MinLength(9), MaxLength(600), Display(Name = "Organization Contact Description")]
        public string OrganizationContactDescription { get; set; }
        [MinLength(9), MaxLength(600), Display(Name = "Volunteer Experience")]
        public string VolunteerExperience { get; set; }                                   //No 20 in form
 
        //No 22 in form
        [Required, Display(Name = "Is Ever Suspended")]
        public Decision IsEverSuspended { get; set; }
        [MinLength(9), MaxLength(600), Display(Name = "Suspension Reason")]
        public string SuspensionReason { get; set; }

        //No 23 in form
        [Required, Display(Name = "Is Getting Pension")]
        public Decision IsGettingPension { get; set; }
        [Display(Name = "Pension Amount")]
        public UInt64 PensionAmount { get; set; }
        [MinLength(3), MaxLength(50), Display(Name = "Pension Giving Organization Name")]
        public string PensionOrganizationName { get; set; }

        //No 24 in form
        [Required]
        public Decision IsInvolvedWithAnyAssociation { get; set; }
        [MinLength(3), MaxLength(50), Display(Name = "Name Of Association")]
        public string NameOfAssociation { get; set; }
        [MinLength(9), MaxLength(600), Display(Name = "Description Of Association")]
        public string DescriptionOfAssociation { get; set; }

        //No 25 in form
        [Required(ErrorMessage = "ব্যাংক ড্রাফট/পে-অর্ডার নং প্রয়োজন"), MinLength(5), MaxLength(50), Display(Name = "Bank Draft Or Pay Order No")]
        public string BankDraftOrPayOrderNo { get; set; }
        [Required(ErrorMessage = "ব্যাংক ড্রাফট/পে-অর্ডার জমা দেওয়ার দিন প্রয়োজন"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true), Display(Name = "Date Of Draft Or Order")]
        public DateTime DateOfDraftOrOrder { get; set; }
        [Required(ErrorMessage = "জমা কৃত টাকার পরিমান প্রয়োজন"), Display(Name = "Amount Of Money")]
        public UInt16 AmountOfMoney { get; set; }
        [Required(ErrorMessage = "ব্যাংকের নাম প্রয়োজন"), MinLength(3), MaxLength(50), Display(Name = "Name Of Bank")]
        public string NameOfBank { get; set; }
        [Required(ErrorMessage = "ব্যাংকের ব্রাঞ্চের নাম প্রয়োজন"), MinLength(3), MaxLength(50), Display(Name = "Branch Of Bank")]
        public string BranchOfBank { get; set; }

        [MinLength(9, ErrorMessage = "অতিরিক্ত তথ্য ৯ অক্ষরের বড় হতে হবে"), MaxLength(1000, ErrorMessage = "অতিরিক্ত তথ্য ১০০০ অক্ষরের ছোট হতে হবে"), Display(Name = "Extra Information")]
        public string ExtraInformation { get; set; }
    }
}
