using Microsoft.AspNetCore.SignalR;
using Microsoft.Diagnostics.Tracing.Parsers.AspNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM")]
    public class Form : IModel
    {
        public Form()
        {
            this.documentNumberFlag = "Y";
            this.sort = 0;
            this.delayDay = 0;
            this.delayTime = "0000";
            this.documentTransferFlag = "N";
            this.directionFlag = "";
            this.mandatoryFlag = "N";
            this.legacyType = "LA";
            this.approvalLineModifyFlag = "YY";
            this.departmentBoxReadFlag = "Y";
            this.insertDate = DateTime.Now;

            this.formDisplayAuths = new List<FormDisplayAuth>();
        }

        [Key]
        [Column("FORM_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [ForeignKey("categoryId")]
        public FormCategory formCategory { get; set; }

        [ForeignKey("fileGroupId")]
        public FormFileGroup formFileGroup { get; set; }

        [Column("FORM_CATEGORY_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int? categoryId { get; set; }

        [Column("FORM_FILE_GROUP_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int fileGroupId { get; set; }

        [Column("FORM_NM")]
        [StringLength(30, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string name { get; set; }

        [Column("FORM_DESCRIPTION")]
        [StringLength(4000, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string description { get; set; }

        [Column("FORM_SORT")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int? sort { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("DISPLAY_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string displayFlag { get; set; }


        [Column("FORM_DELAY_ALERT_DAY")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int delayDay { get; set; }

        [Column("FORM_DELAY_ALERT_TIME")]
        [StringLength(4, MinimumLength = 4, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string delayTime { get; set; }

        [Column("FORM_LEGACY_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string legacyFlag { get; set; }

        [Column("FORM_LEGACY_TYPE")]
        public string legacyType { get; set; }

        [Column("FORM_LEGACY_URL")]
        public string legacyUrl { get; set; }

        [Column("FORM_DOCUMENT_NUMBER_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string documentNumberFlag { get; set; }

        [Column("FORM_DOCUMENT_TRANSFER_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string documentTransferFlag { get; set; }

        [Column("FORM_DIRECTION_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string directionFlag { get; set; }

        [Column("FORM_APPROVAL_LINE_MODIFY_FLAG", TypeName = "char(2)")]
        [StringLength(2, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string approvalLineModifyFlag { get; set; }

        [Column("FORM_DEPARTMENT_BOX_READ_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string departmentBoxReadFlag { get; set; }

        [Column("FORM_MANDATORY_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string mandatoryFlag { get; set; }

        [Column("FORM_DELEGATE_POLICY_ID")]
        public string delegatePolicyId { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }

        public ICollection<FormDisplayAuth> formDisplayAuths { get; set; }
    }
}
