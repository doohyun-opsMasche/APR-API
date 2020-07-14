using System;

namespace APPROVAL.Dtos.Forms
{
    public class FormFileGroupRead
    {
        public int id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public int level { get; set; }
        public DateTime insertDate { get; set; }
    }
}
