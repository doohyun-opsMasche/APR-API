using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_DELEGATE_PROVISION")]
    public class DelegateProvision
    {
        public DelegateProvision()
        {
            this.amountStart = 0;
            this.amountEnd = 0;
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;

            this.forms = new List<Form>();
            this.delegateProvisionLines = new List<DelegateProvisionLine>();
        }

        #region 테이블 컬럼 구조
        /*
        DELEGATE_PROVISION_ID           int             아이디 PK
        DELEGATE_PROVISION_CATEGORY_ID  int             카테고리 아이디 FK
        DELEGATE_PROVISION_TYPE         char(1)         타입
        DELEGATE_PROVISION_NM           varchar(50)     이름
        DELEGATE_PROVISION_AMOUNT_START decimal(18,2)   시작 금액   null
        DELEGATE_PROVISION_AMOUNT_END   decimal(18,2)   종료 금액   null
        DELEGATE_PROVISION_OPTIONS      NVARCHAR(50)    옵션(Json)
        USE_FLAG                        char(1)         사용 여부
        INS_DATE                        datetime        생성일
        */
        #endregion
        
        [Key]
        [Column("DELEGATE_PROVISION_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [ForeignKey("categoryId")]
        public DelegateProvisionCategory delegateProvisionCategory { get; set; }

        [Column("DELEGATE_PROVISION_CATEGORY_ID")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int categoryId { get; set; }

        [Column("DELEGATE_PROVISION_TYPE", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string type { get; set; }

        [Column("DELEGATE_PROVISION_NM")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string name { get; set; }

        [Column("DELEGATE_PROVISION_AMOUNT_START")]
        public decimal? amountStart { get; set; }

        [Column("DELEGATE_PROVISION_AMOUNT_END")]
        public decimal? amountEnd { get; set; }

        [Column("DELEGATE_PROVISION_OPTIONS")]
        [StringLength(50, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string option { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }

        public ICollection<Form> forms { get; set; }

        public ICollection<DelegateProvisionLine> delegateProvisionLines { get; set; }
    }
}
