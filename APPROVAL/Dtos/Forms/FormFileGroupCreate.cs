using System;

namespace APPROVAL.Dtos.Forms
{
    public class FormFileGroupCreate
    {
        public int id { get; set; }
        public string name { get; set; }
        public string displayName { get; set; }
        public int groupVersion { get; set; }
        public DateTime insertDate { get; set; }
    }
}
