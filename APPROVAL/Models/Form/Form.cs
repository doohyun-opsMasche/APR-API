using Microsoft.AspNetCore.SignalR;
using Microsoft.Diagnostics.Tracing.Parsers.AspNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM")]
    public class Form
    {
        public Form(): base()
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

            this.formDisplayAuths = new List<FormDisplayAuth>();
        }

        [Key]
        [Column("FORM_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int id { get; set; }

        [Column("FORM_CATEGORY_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int? categoryId { get; set; }

        [ForeignKey("categoryId")]
        public FormCategory formCategory { get; set; }

        [Column("FORM_FILE_GROUP_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int fileGroupId { get; set; }

        [ForeignKey("fileGroupId")]
        public FormFileGroup formFileGroup { get; set; }

        [Column("FORM_NM")]
        [StringLength(30, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string name { get; set; }

        [Column("FORM_DESCRIPTION")]
        [StringLength(4000, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string description { get; set; }

        [Column("FORM_SORT")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int? sort { get; set; }

        [Column("USE_FLAG")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string useFlag { get; set; }

        [Column("DISPLAY_FLAG")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string displayFlag { get; set; }


        [Column("FORM_DELAY_ALERT_DAY")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int delayDay { get; set; }

        [Column("FORM_DELAY_ALERT_TIME")]
        [StringLength(4, MinimumLength = 4, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string delayTime { get; set; }

        [Column("FORM_LEGACY_FLAG")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string legacyFlag { get; set; }

        [Column("FORM_LEGACY_TYPE")]
        public string legacyType { get; set; }

        [Column("FORM_LEGACY_URL")]
        public string legacyUrl { get; set; }

        [Column("FORM_DOCUMENT_NUMBER_FLAG")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string documentNumberFlag { get; set; }

        [Column("FORM_DOCUMENT_TRANSFER_FLAG")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string documentTransferFlag { get; set; }

        [Column("FORM_DIRECTION_FLAG")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string directionFlag { get; set; }

        [Column("FORM_APPROVAL_LINE_MODIFY_FLAG")]
        [StringLength(2, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string approvalLineModifyFlag { get; set; }

        [Column("FORM_DEPARTMENT_BOX_READ_FLAG")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string departmentBoxReadFlag { get; set; }

        [Column("FORM_MANDATORY_FLAG")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string mandatoryFlag { get; set; }

        [Column("FORM_DELEGATE_POLICY_ID")]
        public string delegatePolicyId { get; set; }


        public ICollection<FormDisplayAuth> formDisplayAuths { get; set; }
    }
}
