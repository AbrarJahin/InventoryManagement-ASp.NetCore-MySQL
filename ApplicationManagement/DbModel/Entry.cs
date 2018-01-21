using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class Entry : BaseEntity
    {
        [Required(ErrorMessage = "দয়া করে পণ্য গ্রহণ করার তারিখ দিন"), Display(Name = "তারিখ", Prompt = "Date of Entry")]  //, MySqlCharset("utf8_unicode_ci")
        public DateTime EntryDate { get; set; }
        [Required(ErrorMessage = "দয়া করে প্রারম্ভিক স্থিতির সঠিক সংখ্যা দিন"), Range(0, int.MaxValue, ErrorMessage = "প্রারম্ভিক স্থিতির সঠিক সংখ্যা দিন"), Display(Name = "প্রারম্ভিক স্থিতি", Prompt = "Initial count")]
        public int InitialCount { get; set; }
        [Required(ErrorMessage = "দয়া করে সরবরাহকারীর নাম দিন"), MinLength(3, ErrorMessage = "সরবরাহকারীর নাম নূনতম ৩ অক্ষর হতে হবে"), MaxLength(50, ErrorMessage = "সরবরাহকারীর নাম সর্বোচ্চ ৫০ অক্ষর হতে পারবে"), Display(Name = "সরবরাহকারীর নাম", Prompt = "Name of the Supplier")]
        public string NameOfSupplier { get; set; }
        [Required(ErrorMessage = "দয়া করে সরবরাহকারীর ঠিকানা দিন"), MinLength(3), MaxLength(50), Display(Name = "সরবরাহকারীর ঠিকানা", Prompt = "Address of the Supplier")]
        public string AddressOfSupplier { get; set; }
        [Required(ErrorMessage = "দয়া করে মালের বিবরণ দিন"), MinLength(10), MaxLength(100), Display(Name = "মালের বিবরণ", Prompt = "Description of Product")]
        public string DescriptionOfProduct { get; set; }
        [Required(ErrorMessage = "দয়া করে সরবরাহকৃত মালের পরিমান দিন"), Range(1, int.MaxValue), Display(Name = "সরবরাহকৃত মালের পরিমান", Prompt = "Number of product")]
        public int NumberOfSuppliedProduct { get; set; }
        [Required(ErrorMessage = "দয়া করে পন্যের একক মুল্য দিন"), Range(0, int.MaxValue), Display(Name = "একক মুল্য", Prompt = "Unit price")]
        public int SuppliedProductUnitPrice { get; set; }
        [Required(ErrorMessage = "দয়া করে পন্যের মোট মুল্য দিন"), Range(0, int.MaxValue), Display(Name = "মোট মুল্য", Prompt = "Total price")]
        public int SuppliedProductTotalPrice { get; set; }
        [Required(ErrorMessage = "দয়া করে মোট মালের পরিমান দিন"), Range(1, int.MaxValue), Display(Name = "মোট মালের পরিমান (পূর্বের স্থিথি সহ)", Prompt = "Aggregated total no of product")]
        public int TotalNoOfProductAfterInserted { get; set; }

        [Display(Name = "গ্রহনের তারিখ", Prompt = "Date of receiving")]
        public DateTime ? ReceiveDate { get; set; }
        [MinLength(3), MaxLength(50), Display(Name = "গ্রহণকারীর নাম", Prompt = "Name of the User")]
        public string NameOfUser { get; set; }
        [MinLength(10), MaxLength(100), Display(Name = "গ্রহণকারীর ঠিকানা", Prompt = "Address of the user")]
        public string  AddressOfUser { get; set; }
        [MinLength(3), MaxLength(50), Display(Name = "চাহিদা পত্র নং", Prompt = "Demand note no")]
        public string DemandnoteNo { get; set; }
        [Range(1, int.MaxValue), Display(Name = "গ্রহণকৃত মালের পরিমান", Prompt = "No of received product")]
        public int ? NumberOfReceivedProduct { get; set; }
        [Range(0, int.MaxValue), Display(Name = "অবশিষ্ট মালের পরিমান", Prompt = "remaining product count")]
        public int ? TotalNoOfProductAfterdeduction { get; set; }
    }
}