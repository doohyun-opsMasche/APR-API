using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    public class TB_COMMON
    {
        public TB_COMMON()
        {
            insDate = DateTime.Now;
        }

        [Column("INS_DATE")]
        [Required(ErrorMessage = "생성 일을 입력하여 주십시오.")]  // 변수로 설정을 할 생각이 있으면 전역으로 처리된 메시지 사용해야 함
        public DateTime? insDate { get; set; }
    }
}
