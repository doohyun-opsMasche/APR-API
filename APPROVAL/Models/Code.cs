using Newtonsoft.Json.Serialization;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{

        // 샘플 코드
        // 디폴크 값 선언
        // public Code(Parameters)
        // {
        //     this.key = "";      // 초기 생성자 샘플
        // }

        // [Column("DB 칼럼명")]
        // [StringLength()]
        // [Required()]
        // public string sample { get; set; }

    [Table("TB_COMMON_CODE")]
    public class Code
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int id { get; set; }

        [Column("COMMON_CATEGORY")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "RangeErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string category { get; set; }

        [Column("COMMON_KEY")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "RangeErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string key { get; set; }

        [Column("COMMON_VALUE")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "RangeErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string value { get; set; }

        [Column("USE_FLAG")]
        [MaxLength(1, ErrorMessage = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string useFlag{get;set;}

        [Column("UPD_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public DateTime? updateDate { get; set; }
    }
}
