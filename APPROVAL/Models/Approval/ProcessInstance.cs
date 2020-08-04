using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_PROCESS_INSTANCE")]
    public class ProcessInstance
    {
        public ProcessInstance()
        {

            this.useFlag = "Y";
            this.insertDate = DateTime.Now;

            this.approvalReferences = new List<ApprovalReference>();
            this.approvalRequestUsers = new List<ApprovalRequestUser>();
            this.approvalUsers = new List<ApprovalUser>();
            this.attachFiles = new List<AttachFile>();
        }

        #region 테이블 컬럼 구조
        /*
        PROCESS_INSTANCE_ID	        int	            고유 아이디  PK
        PROCESS_DOCUMENT_NUMBER	    varchar(50)	    문서 넘버
        PROCESS_PROTECT_LEVEL	    varchar(50)	    보안 레벨
        DELEGEATE_PROVISION_ID	    int	            위임규정 아이디 FK
        FORM_ID	                    int	            양식 아이디    FK
        FORM_NM	                    varchar(100)	양식 제목
        PROCESS_CONTENTS	        varchar(max)	양식 데이터(JSON)
        PROCESS_DOCUMENT_IMAGE_PATH	varchar(200)	이미지로 변환 된 문서 PATH
        PROCESS_ATTACH_FLAG	        char(1)	        파일 첨부 여부
        USE_FLAG	                char(1)	        사용 여부
        COMPLATED_DATE	            datetime	    완료일     null
        INS_DATE	                datetime	    생성일
        UPT_DATE	                datetime	    수정일     null
        */
        #endregion

        [Key]
        [Column("PROCESS_INSTANCE_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int pid { get; set; }

        [Column("PROCESS_DOCUMENT_NUMBER")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string documentNumber { get; set; }

        [Column("PROCESS_PROTECT_LEVEL")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string protectLevel { get; set; }

        [ForeignKey("delegateProvisionId")]
        public DelegateProvision delegateProvision { get; set; }

        [ForeignKey("formId")]
        public Form form { get; set; }

        [Column("DELEGEATE_PROVISION_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int delegateProvisionId { get; set; }
        
        [Column("FORM_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int formId { get; set; }

        [Column("FORM_NM")]
        [StringLength(100, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string formName { get; set; }

        [Column("PROCESS_CONTENTS")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string contents { get; set; }

        [Column("PROCESS_DOCUMENT_IMAGE_PATH")]
        [StringLength(200, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string documentImagePath { get; set; }

        [Column("PROCESS_ATTACH_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string attachFlag { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("COMPLATED_DATE")]
        public DateTime? complatedDate { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }

        [Column("UPT_DATE")]
        public DataType? updateDate { get; set; }

        public ICollection<ApprovalReference> approvalReferences { get; set; }

        public ICollection<ApprovalRequestUser> approvalRequestUsers { get; set; }

        public ICollection<ApprovalUser> approvalUsers { get; set; }

        public ICollection<AttachFile> attachFiles { get; set; }
    }
}
