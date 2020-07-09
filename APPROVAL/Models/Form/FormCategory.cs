using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM_CATEGORY")]
    public class FormCategory : CommonColumn
    {
        public FormCategory(): base()
        {
            this.name = "";
            this.languageFlag = "ko";
            this.sort = 0;

            this.forms = new List<Form>();
        }

        [Key]
        [Column("FORM_CATEGORY_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int id { get; set; }

        [Column("FORM_CATEGORY_NM")]
        [StringLength(30, MinimumLength = 1, ErrorMessage = "RangeErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string name { get; set; }

        [Column("FORM_CATEGORY_LANGUAGE_FLAG")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string languageFlag { get; set; }

        [Column("FORM_CATEGORY_SORT")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int? sort { get; set; }

        public ICollection<Form> forms { get; set; }
    }
}
