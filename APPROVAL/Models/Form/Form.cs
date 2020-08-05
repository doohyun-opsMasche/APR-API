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
        public Form()
        {
            this.documentNumberFlag = "Y";
            this.sort = 0;
            this.documentTransferFlag = "N";
            this.direction = "";
            this.mandatoryFlag = "N";
            this.approvalLineModifyFlag = "YY";
            this.departmentBoxReadFlag = "Y";
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;

            this.formDisplayAuths = new List<FormDisplayAuth>();
            this.processInstances = new List<ProcessInstance>();
        }

        #region 테이블 컬럼 구조
        /*
        FORM_ID	                        int	            아이디            PK
        CATEGORY_ID	                    int	            대분류 아이디      FK  
        FILE_GROUP_ID	                int	            파일 그룹 아이디   FK  null
        FORM_NM	                        varchar(50)	    이름
        FORM_DESCRIPTION	            nvarchar(4000)	설명
        FORM_DIRECTION	                char(1)	        표시 방향
        FORM_SORT	                    int	            정렬순서
        FORM_DOCUMENT_NUMBER_FLAG	    char(1)	        문서 발번 여부(사전, 사후)
        FORM_DOCUMENT_TRANSFER_FLAG	    char(1)	        문서 이동 여부
        FORM_APPROVAL_LINE_MODIFY_FLAG	char(1)	        결재선 수정 여부
        FORM_DEPARTMENT_BOX_READ_FLAG	char(1)	        부서함 읽기 여부
        FORM_MANDATORY_FLAG	            char(1)	        위임전결 여부
        FORM_DELEGATE_PROVISION_ID	    int	            위임 전결 아이디   FK  null
        DISPLAY_FLAG	                char(1)	        표시 여부
        USE_FLAG	                    char(1)	        사용 여부
        INS_DATE		                datetime        생성일

        */
        #endregion

        [Key]
        [Column("FORM_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [ForeignKey("categoryId")]
        public FormCategory formCategory { get; set; }

        [ForeignKey("fileGroupId")]
        public FormFileGroup formFileGroup { get; set; }

        [ForeignKey("delegateProvisionId")]
        public DelegateProvision delegateProvision { get; set; }

        [Column("CATEGORY_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int? categoryId { get; set; }

        [Column("FILE_GROUP_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int fileGroupId { get; set; }

        [Column("FORM_NM")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string name { get; set; }

        [Column("FORM_DESCRIPTION")]
        [StringLength(4000, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string description { get; set; }

        [Column("FORM_DIRECTION", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string direction { get; set; }

        [Column("FORM_SORT")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int? sort { get; set; }

        [Column("FORM_DOCUMENT_NUMBER_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string documentNumberFlag { get; set; }

        [Column("FORM_DOCUMENT_TRANSFER_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string documentTransferFlag { get; set; }        

        [Column("FORM_APPROVAL_LINE_MODIFY_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
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

        [Column("FORM_DELEGATE_PROVISION_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int? delegateProvisionId { get; set; }

        [Column("DISPLAY_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string displayFlag { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }

        public ICollection<FormDisplayAuth> formDisplayAuths { get; set; }
        public ICollection<ProcessInstance> processInstances { get; set; }
    }
}
