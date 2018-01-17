using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class Language : BaseEntity
    {
        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Skill { get; set; }
    }
}
