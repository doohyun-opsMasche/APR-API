using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_ATTACH_FILE")]
    public class AttachFile
    {
        public AttachFile()
        {
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;
        }

        #region 테이블 컬럼 구조
        /*
        ATTACH_ID	            int	            첨부 파일 고유 아이디    PK
        PROCESS_INSTANCE_ID	    int	            결재 상신 아이디       FK
        ATTACH_SERVER_TYPE	    char(1)	        첨부 파일 저장 서버
        ATTACH_PHYSICAL_PATH	varchar(200)	물리적 PATH
        ATTACH_PHYSICAL_NM	    varchar(100)	실제 파일 명
        ATTACH_VIRTUAL_PATH	    varchar(200)	가상 PATH
        ATTACH_VIRTUAL_NM	    varchar(100)	첨부 파일 명
        ATTACH_EXTENSION	    varchar(10)	    확장자
        ATTACH_SIZE	            int	            파일 사이즈
        ATTACH_CREATER	        varchar(20)	    생성자
        USE_FLAG	            char(1)	        사용여부
        INS_DATE	            datetime	    생성일
        */
        #endregion

        [Key]
        [Column("ATTACH_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [ForeignKey("pid")]
        public ProcessInstance processInstance { get; set; }

        [Column("PROCESS_INSTANCE_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int pid { get; set; }

        [Column("ATTACH_SERVER_TYPE", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string serverType { get; set; }

        [Column("ATTACH_PHYSICAL_PATH")]
        [StringLength(200, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string physicalPath { get; set; }

        [Column("ATTACH_PHYSICAL_NM")]
        [StringLength(100, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string physicalName { get; set; }

        [Column("ATTACH_VIRTUAL_PATH")]
        [StringLength(200, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string virtualPath { get; set; }

        [Column("ATTACH_VIRTUAL_NM")]
        [StringLength(100, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string virtualName { get; set; }

        [Column("ATTACH_EXTENSION")]
        [StringLength(10, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string extension { get; set; }

        [Column("ATTACH_SIZE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int size { get; set; }

        [Column("ATTACH_CREATER", TypeName = "char(1)")]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string creater { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }
    }
}
