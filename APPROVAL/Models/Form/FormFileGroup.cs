using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM_FILE_GROUP")]
    public class FormFileGroup
    {
        public FormFileGroup()
        {
            this.level = 1;
            this.insertDate = DateTime.Now;

            this.formFiles = new List<FormFile>();
        }

        [Key]
        [Column("FORM_FILE_GROUP_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [Column("FORM_FILE_GROUP_NM")]
        [StringLength(255, MinimumLength = 10, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string name { get; set; }

        [Column("FORM_FILE_GROUP_DISPLAY_NM")]
        [StringLength(20, MinimumLength = 10, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string displayName { get; set; }

        [Column("FORM_FILE_GROUP_LEVEL")]
        [StringLength(300, MinimumLength = 10, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int level { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }

        public ICollection<FormFile> formFiles { get; set; } 
               
        public ICollection<Form> forms { get; set; }
    }
}
