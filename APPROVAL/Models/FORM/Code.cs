using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_COMMON_CODE")]
    public class Code
    {

        // 샘플 코드
        // public Code(Parameters)
        // {
        //     this.key = "";      // 초기 생성자 샘플
        // }

        // [Column("DB 칼럼명")]
        // [StringLength()]
        // [Required()]
        // public string sample { get; set; }

        public string category { get; set; }

        public string key { get; set; }

        public string value { get; set; }

        public DateTime? updateDate { get; set; }

        public string useFlag{get;set;}
    }
}
