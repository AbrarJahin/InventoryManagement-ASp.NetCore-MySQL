using System;
using System.ComponentModel.DataAnnotations;
using static ApplicationManagement.DbModel.CustomTypes;

namespace ApplicationManagement.DbModel
{
    public class Payment : BaseEntity
    {
        public PaymentStatus IsPaymentDone { get; set; }
        [Required, MinLength(5), MaxLength(50)]
        public string BankDraftOrPayOrderNo { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfDraftOrOrder { get; set; }
        [Required]
        public Int64 AmountOfMoney { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string NameOfBank { get; set; }
        [Required, MinLength(3), MaxLength(50)]
        public string BranchOfBank { get; set; }

        public virtual TeacherApplication TeacherApplications { get; set; }

        public Payment()
        {
            IsPaymentDone = PaymentStatus.Pending;
        }
    }
}
