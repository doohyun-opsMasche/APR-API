using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_APPROVAL_USER")]
    public class ApprovalUser
    {
        public ApprovalUser()
        {
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;
        }

        #region 테이블 컬럼 구조
        /*
        APPROVAL_ID	        int	        결재자 고유 아이디  PK
        PROCESS_INSTANCE_ID	int	        상신 프로세스 아이디 FK
        APPROVAL_TYPE	    char(2)	    결재자 권한 타입
        APPROVAL_USER_ID	varchar(20)	결재자 아이디
        APPROVAL_USER_NM	nvarchar(50)결재자 이름
        APPROVAL_FLAG	    char(1)	    결재 여부
        APPROVAL_STATUS	    char(1)	    상태
        APPROVAL_SORT	    int	        결재 순서
        USE_FLAG	        char(1)	    사용 여부
        INS_DATE	        datetime	생성일
        */
        #endregion

        [Key]
        [Column("APPROVAL_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [ForeignKey("pid")]
        public ProcessInstance processInstance { get; set; }

        [Column("PROCESS_INSTANCE_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int pid { get; set; }

        [Column("APPROVAL_TYPE", TypeName = "char(2)")]
        [MaxLength(2, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string type { get; set; }

        [Column("APPROVAL_USER_ID")]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string userId { get; set; }

        [Column("APPROVAL_USER_NM")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string userName { get; set; }

        [Column("APPROVAL_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string approvalFlag { get; set; }

        [Column("APPROVAL_STATUS", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string status { get; set; }

        [Column("APPROVAL_SORT")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int sort { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }
    }
}
