using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class ResearchDegree : BaseEntity
    {
        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Required]
        public string NameOfDegree { get; set; }
        [Required]
        public string SubjectOfResearch { get; set; }
        [Required]
        public string SupervisorsNameAndAddress { get; set; }
        [Required]
        public string UniversityName { get; set; }
        [Required]
        public Int64 YearOfPassing { get; set; }
    }
}
