using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_COMMON_CODE")]
    public class Code
    {
        public Code()
        {
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;
        }

        #region 테이블 컬럼 구조
        /*
        COMMON_ID	        int	            고유 아이디
        COMMON_CATEGORY	    varchar(50)	    카테고리 이름
        COMMON_KEY	        varchar(50)	    키
        COMMON_VALUE	    varchar(50)	    값
        USE_FLAG	        char(1)	        사용 여부
        INS_DATE	        datetime	    생성일
        */
        #endregion

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [Column("COMMON_CATEGORY")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string category { get; set; }

        [Column("COMMON_KEY")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string key { get; set; }

        [Column("COMMON_VALUE")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string value { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }
    }
}
