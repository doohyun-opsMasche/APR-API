using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM_FILE_GROUP")]
    public class FormFileGroup : CommonColumn
    {
        public FormFileGroup() : base()
        {
            this.version = 1;

            this.formFiles = new List<FormFile>();
        }

        [Key]
        [Column("FORM_FILE_GROUP_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int id { get; set; }

        [Column("FORM_FILE_GROUP_NM")]
        [StringLength(255, MinimumLength = 10, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string name { get; set; }

        [Column("FORM_FILE_GROUP_DISPLAY_NM")]
        [StringLength(20, MinimumLength = 10, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string displayName { get; set; }

        [Column("FORM_FILE_GROUP_VERSION")]
        [StringLength(300, MinimumLength = 10, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int version { get; set; }

        public ICollection<FormFile> formFiles { get; set; } 
               
        public ICollection<Form> forms { get; set; }
    }
}
