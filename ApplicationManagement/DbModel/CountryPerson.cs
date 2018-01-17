using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class CountryPerson : BaseEntity
    {
        [Column(Order = 1)]
        public long CountryID { get; set; }
        [Column(Order = 2)]
        public long PersonID { get; set; }

        public virtual Country Country { get; set; }
        public virtual Person Person { get; set; }

        public string ReasonOfTour { get; set; }
    }
}
