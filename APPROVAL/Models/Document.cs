using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("Document")]
    public class Document
    {
        // camel 표기법 준수
        [Key]
        public int processId { get; set; } = 1;
        public string companyCode { get; set; } = "H0000000";
        public string companyName { get; set; } = "SGH";
        public string creator { get; set; } = "고두현";
        public string creatorId { get; set; }
        public string creatorDepartment { get; set; }
        public string subject { get; set; }
        public int formId { get; set; } = 0;
        public int ruleId { get; set; } = 0;
        public ApprovalCode status { get; set; } = ApprovalCode.Draft;

    }

}