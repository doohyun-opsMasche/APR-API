using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM_DISPLAY_AUTH")]
    public class FormDisplayAuth
    {
        public FormDisplayAuth()
        {
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;
        }

        #region 테이블 컬럼 구조
        /*
        AUTH_ID	        int	        권한 아이디  PK
        FORM_ID	        int	        양식        PK, FK
        AUTH_TYPE	    char(1)	    권한 타입
        AUTH_RESOURCE	varchar(20)	권한 리소스
        USE_FLAG	    char(1)	    사용 여부
        INS_DATE	    datetime	생성일
        */
        #endregion

        [Key]
        [Column("AUTH_ID", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int? authId { get; set; }

        [Key]
        [Column("FORM_ID", Order = 2)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int? formId { get; set; }

        [ForeignKey("formId")]
        public Form form { get; set; }

        [Column("AUTH_TYPE", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string authType { get; set; }

        [Column("AUTH_RESOURCE")]
        [StringLength(20, MinimumLength = 8, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string authResource { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }
    }
}
