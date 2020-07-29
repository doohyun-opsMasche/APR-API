using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    public class DelegateProvisionLine
    {
        public DelegateProvisionLine()
        {
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;

            this.delegateProvisionLineDetails = new List<DelegateProvisionLineDetail>();
        }

        #region 테이블 컬럼 구조
        /*
        LINE_ID                 int             아이디 PK
        DELEGATE_PROVISION_ID   int             위임전결 규정 아이디 FK
        LINE_NM                 nvarchar(50)    결재선 이름
        LINE_TYPE               char(1)         결재선 타입
        LINE_BASE_DUTY_CD       varchar(20)     기준 직책   
        LINE_DEPARTMENT_CD      varchar(20)     부서 타입
        LINE_EXCEPTION          varchar(20)     예외
        LINE_INCLUSION_FLAG     char(1)         하위부서 포함 null
        USE_FLAG                char(1)         사용 여부
        INS_DATE                datetime        생성일
        */
        #endregion

        [Key]
        [Column("LINE_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [ForeignKey("delegateProvisionId")]
        public DelegateProvision delegateProvision { get; set; }

        [Column("DELEGATE_PROVISION_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int delegateProvisionId { get; set; }

        [Column("LINE_NM")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string name { get; set; }

        [Column("LINE_TYPE", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string type { get; set; }

        [Column("LINE_BASE_DUTY_CD")]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string baseDutyCode { get; set; }

        [Column("LINE_DEPARTMENT_CD")]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string deptCode { get; set; }

        [Column("LINE_EXCEPTION")]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string exception { get; set; }

        [Column("LINE_INCLUSION_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string inclusionFlag { get; set; }
        
        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }

        public ICollection<DelegateProvisionLineDetail> delegateProvisionLineDetails { get; set; }
    }
}
