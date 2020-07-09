using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM_FILE")]
    public class TB_FORM_FILE : TB_COMMON
    {
        public TB_FORM_FILE(): base()
        {
            this.formFileType = "H";
            this.formFileFolderFlag = "F";

            this.tbFormDisplayAuths = new List<TB_FORM_DISPLAY_AUTH>();
        }

        [Key]
        [Column("FORM_FILE_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "파일 아이디를 입력하여 주십시오.")]
        public int? formFileId { get; set; }

        // 샘플 1
        [ForeignKey("TB_FORM_FILE_GROUP")]
        [Column("FORM_FILE_GROUP_ID")]
        public int? formFileGroupId { get; set; }
        public TB_FORM_FILE_GROUP tbFormFileGroup { get; set; }

        // 샘플 2
        // [Column("FORM_FILE_GROUP_ID")]
        // public int? formFileGroupId { get; set; }

        // [ForeignKey("formFileGroupId")]
        // public TB_FORM_FILE_GROUP tbFormFileGroup { get; set; }

        // 샘플 3
        // public int? formFileGroupId { get; set; }
        // public TB_FORM_FILE_GROUP tbFormFileGroup { get; set; }


        [Column("FORM_FILE_PATH")]
        [StringLength(300, ErrorMessage ="10~300 자리의 PATH 정보를 입력하여 주십시오", MinimumLength = 10)]
        [Required(ErrorMessage = "파일 아이디를 입력하여 주십시오.")]
        public string formFilePath { get; set; }


        [Column("FORM_FILE_TYPE")]
        [MaxLength(1)]
        [Required(ErrorMessage = "파일 타입을 입력하여 주십시오.")]
        public string formFileType { get; set; }

        [Column("FORM_FILE_FOLDER_FLAG")]
        [MaxLength(1)]
        [Required(ErrorMessage = "저장 위치 정보를 입력하여 주십시오.")]
        public string formFileFolderFlag { get; set; }

        public List<TB_FORM_DISPLAY_AUTH> tbFormDisplayAuths { get; set; }
    }
}
