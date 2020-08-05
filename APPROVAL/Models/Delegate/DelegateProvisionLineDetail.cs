using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_DELEGATE_PROVISION_LINE_DETAIL")]
    public class DelegateProvisionLineDetail
    {
        public DelegateProvisionLineDetail()
        {
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;
        }
        #region 테이블 컬럼 구조
        /*
        DETAIL_ID                   int             아이디 PK
        LINE_ID                     int             위임전결 규정 결재선 아이디 FK
        DETAIL_SEQ                  int             시퀀스
        DETAIL_NM                   varchar(50)     상세 이름
        DETAIL_TYPE                 char(1)         상세 타입   
        DETAIL_RESOURCE             varchar(20)     상세 리소스
        DETAIL_ABSENCE_PERSON_FLAG  char(1)         공석시 이전 전결
        DETAIL_REFERENCE_FLAG       char(1)         회람 여부
        USE_FLAG                    char(1)         사용 여부
        INS_DATE                    datetime        생성일
        */
        #endregion

        [Key]
        [Column("DETAIL_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [ForeignKey("lineId")]
        public DelegateProvisionLine delegateProvisionLine { get; set; }

        [Column("LINE_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int lineId { get; set; }

        [Column("DETAIL_SEQ")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int seq { get; set; }

        [Column("DETAIL_NM")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string name { get; set; }

        [Column("DETAIL_TYPE", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType =typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string type { get; set; }

        [Column("DETAIL_RESOURCE")]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string resource { get; set; }

        [Column("DETAIL_ABSENCE_PERSON_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string absencePersonFlag { get; set; }

        [Column("DETAIL_REFERENCE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string referenceFlag { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }
    }
}
