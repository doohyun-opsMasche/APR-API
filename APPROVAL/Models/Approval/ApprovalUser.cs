﻿using System;
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
        APPROVAL_ID	        int	            결재자 고유 아이디  PK
        PROCESS_INSTANCE_ID	int	            상신 프로세스 아이디 FK
        APPROVAL_TYPE	    char(2)	        결재자 권한 타입
        APPROVAL_USER_ID	varchar(20)	    결재자 아이디
        APPROVAL_USER_NM	nvarchar(50)    결재자 이름
        COMPANY_EMP_NO	    varchar(50)		법인사번    null
        GROUP_EMP_NO	    varchar(50)		그룹사번    null
        COMPANY_NM	        nvarchar(50)	법인명     null
        COMPANY_CODE	    varchar(50)		법인코드    null
        DEPARTMENT_NM	    nvarchar(50)	부서명     null
        DEPARTMENT_CODE	    varchar(50)		부서코드    null
        DUTY_NM	            nvarchar(50)	직책      null
        DUTY_CODE	        varchar(50)		직책코드    null
        APPROVAL_FLAG	    char(1)	        결재 여부
        APPROVAL_STATUS	    char(1)	        상태
        APPROVAL_SORT	    int	            결재 순서
        USE_FLAG	        char(1)	        사용 여부
        INS_DATE	        datetime	    생성일
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

        [Column("COMPANY_EMP_NO")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string comEmpNo { get; set; }

        [Column("GROUP_EMP_NO")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string groupEmpNo { get; set; }

        [Column("COMPANY_NM")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string comNm { get; set; }

        [Column("COMPANY_CODE")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string comCd { get; set; }

        [Column("DEPARTMENT_NM")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string deptNm { get; set; }

        [Column("DEPARTMENT_CODE")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string deptCd { get; set; }

        [Column("DUTY_NM")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string dutyNm { get; set; }

        [Column("DUTY_CODE")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string dutyCd { get; set; }

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
