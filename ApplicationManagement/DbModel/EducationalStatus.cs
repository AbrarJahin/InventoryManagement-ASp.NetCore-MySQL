using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationManagement.DbModel
{
    public class EducationResult : BaseEntity
    {
        public long PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        public string ExamName { get; set; }
        public string BoardOrUniversity { get; set; }
        public string GroupOrSubject { get; set; }
        public UInt16 YearOfPassing { get; set; }
        public UInt16 YearOfExam { get; set; }
        public string DivisionOrClassOrGPAOrCGPA { get; set; }
        public string CertificatePdfFileUrl { get; set; }
        public string TranscriptPdfFileUrl { get; set; }
    }
}
