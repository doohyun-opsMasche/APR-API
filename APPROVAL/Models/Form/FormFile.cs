using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace APPROVAL.Models
{
    [Table("TB_FORM_FILE")]
    public class FormFile : CommonColumn
    {
        public FormFile(): base()
        {
            this.type = "H";
            this.folderFlag = "F";

            this.formDisplayAuths = new List<FormDisplayAuth>();
        }

        [Key]
        [Column("FORM_FILE_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int id { get; set; }

        [Column("FORM_FILE_GROUP_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int groupId { get; set; }

        [ForeignKey("groupId")]
        public FormFileGroup formFileGroup { get; set; }

        [Column("FORM_FILE_PATH")]
        [StringLength(300, MinimumLength = 10, ErrorMessage = "RangeErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string path { get; set; }


        [Column("FORM_FILE_TYPE")]
        [MaxLength(1, ErrorMessage = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string type { get; set; }

        [Column("FORM_FILE_FOLDER_FLAG")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string folderFlag { get; set; }

        public ICollection<FormDisplayAuth> formDisplayAuths { get; set; }
    }
}
