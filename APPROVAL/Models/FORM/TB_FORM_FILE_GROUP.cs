using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM_FILE_GROUP")]
    public class TB_FORM_FILE_GROUP : TB_COMMON
    {
        public TB_FORM_FILE_GROUP() : base()
        {
            formFileGroupVersion = 1;

            this.tbFormFiles = new List<TB_FORM_FILE>();
            this.tbForms = new List<TB_FORM>();
        }

        [Key]
        [Column("FORM_FILE_GROUP_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "파일 그룹 아이디를 입력하여 주십시오.")]
        public int? formFileGroupId { get; set; }

        [Column("FORM_FILE_GROUP_NM")]
        [StringLength(255, ErrorMessage = "10~255자리의 이름을 입력하여 주십시오.", MinimumLength = 10)]
        [Required(ErrorMessage = "파일 그룹 명을 입력하여 주십시오.")]
        public string formFileGroupNm { get; set; }

        [Column("FORM_FILE_GROUP_DISPLAY_NM")]
        [StringLength(20, ErrorMessage = "10~20자리의 이름을 입력하여 주십시오.", MinimumLength = 10)]
        [Required(ErrorMessage = "파일 그룹 표시 이름을 입력하여 주십시오.")]
        public string formFileGroupDisplayNm { get; set; }

        [Column("FORM_FILE_GROUP_VERSION")]
        [Required(ErrorMessage = "파일 그룹의 버전을 입력하여 주십시오.")]
        public int? formFileGroupVersion { get; set; }

        public List<TB_FORM_FILE> tbFormFiles { get; set; }

        // 샘플 3
        // [ForeignKey("formFileGroupId")]
        // public List<TB_FORM_FILE> tbFormFiles { get; set; }
        
        public List<TB_FORM> tbForms { get; set; }
    }
}
