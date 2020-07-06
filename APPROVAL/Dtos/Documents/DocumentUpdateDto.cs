using APPROVAL.Models;

namespace APPROVAL.Dtos.Documents
{
    public class DocumentUpdateDto
    {
        public int processId { get; set; } = 1;
        public string companyCode { get; set; } = "H0000000";
        public string companyName { get; set; } = "SGH";
        public string creator { get; set; } = "고두현";
        public string creatorId { get; set; }
    }
}