using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class Country : BaseEntity
    {
        [Required]
        public string BengaliName { get; set; }

        [Required]
        public string EnglishName { get; set; }

        [Required]
        public string ShortName { get; set; }

        public virtual ICollection<CountryPerson> Visitors { get; set; }
    }
}
