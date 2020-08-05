using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM_FILE_GROUP")]
    public class FormFileGroup
    {
        public FormFileGroup()
        {
            this.groupVersion = 1;
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;

            this.formFiles = new List<FormFile>();
        }

        #region 테이블 컬럼 구조
        /*
        FILE_GROUP_ID	        int	        파일 그룹 아이디   PK
        FILE_GROUP_NM	        varchar(50)	파일 그룹 이름
        FILE_GROUP_DISPLAY_NM	varchar(50)	파일 그룹 표시명
        FILE_GROUP_VERSION	    int	        파일 그룹 버전
        USE_FLAG	            char(1)	    사용 여부
        INS_DATE	            datetime	생성일
        */
        #endregion

        [Key]
        [Column("FILE_GROUP_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [Column("FILE_GROUP_NM")]
        [StringLength(50, MinimumLength = 10, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string name { get; set; }

        [Column("FILE_GROUP_DISPLAY_NM")]
        [StringLength(50, MinimumLength = 10, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string displayName { get; set; }

        [Column("FILE_GROUP_VERSION")]        
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int groupVersion { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }

        public ICollection<FormFile> formFiles { get; set; } 
               
        public ICollection<Form> forms { get; set; }
    }
}
