using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationManagement.DbModel
{
    public class Entry : BaseEntity
    {
        public DateTime EntryDate { get; set; }
        public int InitialCount { get; set; }
        [Required, MinLength(3), MaxLength(50), Display(Name = "সরবরাহকারীর নাম", Prompt = "Name of the Supplier")]  //, MySqlCharset("utf8_unicode_ci")
        public string NameOfSupplier { get; set; }
        public string AddressOfSupplier { get; set; }
        public string DescriptionOfProduct { get; set; }
        public int NumberOfSuppliedProduct { get; set; }
        public int SuppliedProductUnitPrice { get; set; }
        public int SuppliedProductTotalPrice { get; set; }
        public int TotalNoOfProductAfterInserted { get; set; }

        public DateTime ReceiveDate { get; set; }
        public string NameOfUser { get; set; }
        public string AddressOfUser { get; set; }
        public string DemandnoteNo { get; set; }
        public int NumberOfReceivedProduct { get; set; }
        public int TotalNoOfProductAfterdeduction { get; set; }
    }
}