using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM_CATEGORY")]
    public class TB_FORM_CATEGORY : TB_COMMON
    {
        public TB_FORM_CATEGORY(): base()
        {
            this.formCategoryNm = "";
            this.formCategoryLanguageFlag = "ko";
            this.formCategorySort = 0;

            this.tbForms = new List<TB_FORM>();
        }

        [Key]
        [Column("FORM_CATEGORY_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "Category seq가 필요 합니다.")]  // 변수로 설정을 할 생각이 있으면 전역으로 처리된 메시지 사용해야 함
        public int? formCategoryId { get; set; }

        [Column("FORM_CATEGORY_NM")]
        [StringLength(1, ErrorMessage = "1~30 자리 정보를 입력하여 주십시오.", MinimumLength = 30)]
        [Required(ErrorMessage = "분류 명을 입력하여 주십시오.")]  // 변수로 설정을 할 생각이 있으면 전역으로 처리된 메시지 사용해야 함
        public string formCategoryNm { get; set; }

        [Column("FORM_CATEGORY_LANGUAGE_FLAG")]
        [StringLength(2, ErrorMessage = "2 자리 정보만 입력이 가능합니다.", MinimumLength =2)]
        [Required(ErrorMessage = "언어를 입력하여 주십시오.")]  // 변수로 설정을 할 생각이 있으면 전역으로 처리된 메시지 사용해야 함
        public string formCategoryLanguageFlag { get; set; }

        [Column("FORM_CATEGORY_SORT")]
        [Required(ErrorMessage = "정렬 정보를 입력하여 주십시오.")]  // 변수로 설정을 할 생각이 있으면 전역으로 처리된 메시지 사용해야 함
        public int? formCategorySort { get; set; }

        public List<TB_FORM> tbForms { get; set; }
    }
}
