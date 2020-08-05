using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM_CATEGORY")]
    public class FormCategory
    {
        public FormCategory()
        {
            this.name = "";
            this.language = "ko";
            this.sort = 0;
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;

            this.forms = new List<Form>();
        }

        #region 테이블 컬럼 구조
        /*
        CATEGORY_ID	        int	        아이디 PK
        CATEGORY_NM	        varchar(50)	이름
        CATEGORY_LANGUAGE	char(2)	    언어
        CATEGORY_SORT	    int	        정렬 순서
        USE_FLAG	        char(1)	    사용 여부
        INS_DATE	        datetime	생성일
        */
        #endregion

        [Key]
        [Column("CATEGORY_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [Column("CATEGORY_NM")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string name { get; set; }

        [Column("CATEGORY_LANGUAGE", TypeName = "char(2)")]
        [MaxLength(2, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string language { get; set; }

        [Column("CATEGORY_SORT")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int? sort { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }

        public ICollection<Form> forms { get; set; }
    }
}
