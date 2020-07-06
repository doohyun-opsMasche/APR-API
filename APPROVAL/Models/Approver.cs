namespace APPROVAL.Models
{
    public class Approver
    {
        public string id { get; set; }
        public string userName { get; set; }
        public byte[] passwordhash { get; set; }
        public byte[] passwordSalt { get; set; }
    }
}