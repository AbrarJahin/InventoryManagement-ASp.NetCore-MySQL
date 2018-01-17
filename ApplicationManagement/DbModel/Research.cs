using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Research : BaseEntity
    {
        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Required]
        public string NameOfPublication { get; set; }
        [Required]
        public string NameOfPublicationPaper { get; set; }
        [Required]
        public string NameOfPublicationInstitute { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfPublication { get; set; }
        [Required]
        public string EditionOfPublication { get; set; }
        public string Note { get; set; }
    }
}
