using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace APPROVAL.Models
{
    [Table("TB_FORM_FILE")]
    public class FormFile
    {
        public FormFile()
        {
            this.type = "H";
            this.folderFlag = "F";
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;
        }

        #region 테이블 컬럼 구조
        /*
        FILE_ID	            int	            파일 아이디  PK
        FILE_GROUP_ID	    int	            파일 그룹   FK
        FILE_TYPE	        char(1)	        파일 타입
        FILE_FOLDER_FLAG	char(1)	        폴더 타입
        FILE_PATH	        varchar(200)	파일 PATH
        USE_FLAG	        char(1)	        사용 여부
        INS_DATE	        datetime	    생성일
        */
        #endregion

        [Key]
        [Column("FILE_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [ForeignKey("groupId")]
        public FormFileGroup formFileGroup { get; set; }

        [Column("FILE_GROUP_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int groupId { get; set; }
                
        [Column("FILE_TYPE", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string type { get; set; }

        [Column("FILE_FOLDER_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string folderFlag { get; set; }

        [Column("FILE_PATH")]
        [StringLength(200, MinimumLength = 10, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string path { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }
    }
}
