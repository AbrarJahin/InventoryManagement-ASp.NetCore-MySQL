using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class Office : BaseEntity
    {
        [Required(ErrorMessage = "অফিসের নাম লিখুন"), MinLength(3, ErrorMessage = "অফিসের নাম ৩ অক্ষরের বড় হতে হবে"), MaxLength(50, ErrorMessage = "অফিসের নাম ৫০ অক্ষরের ছোট হতে হবে"), Display(Name = "অফিসের নাম", Prompt = "Name of the Office")]
        public string Name { get; set; }
        [Required(ErrorMessage = "অফিসের বিবরন লিখুন"), MinLength(10, ErrorMessage = "অফিসের বিবরন ১০ অক্ষরের বড় হতে হবে"), MaxLength(999, ErrorMessage = "অফিসের নাম ৯৯৯ অক্ষরের ছোট হতে হবে"), Display(Name = "অফিসের বিবরন", Prompt = "Description of the Office")]
        public string Description { get; set; }
        public ICollection<Advertisement> Advertisements { get; set; }
    }
}
