using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Training : BaseEntity
    {
        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Required, MinLength(3), MaxLength(70)]
        public string Name { get; set; }
        [Required, MinLength(9), MaxLength(1000)]
        public string Description { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        public TimeSpan Duration { get; set; }

        public Training()
        {
            Duration = EndDate - StartDate;
        }
    }
}
