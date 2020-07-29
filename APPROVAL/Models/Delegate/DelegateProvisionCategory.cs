using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    public class DelegateProvisionCategory
    {
        public DelegateProvisionCategory()
        {
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;

            this.delegateProvisions = new List<DelegateProvision>();
        }
        #region 테이블 컬럼 구조
        /*
        DELEGATE_PROVISION_CATEGORY_ID  int             아이디 PK
        DELEGATE_PROVISION_CATEGORY_NM  nvarchar(50)    이름
        USE_FLAG                        char(1)         사용 여부
        INS_DATE                        datetime        생성일
        */
        #endregion

        [Key]        
        [Column("DELEGATE_PROVISION_CATEGORY_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [Column("DELEGATE_PROVISION_CATEGORY_NM")]
        [StringLength(50, MinimumLength = 2, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage",ErrorMessageResourceType = typeof(Define))]
        public string name { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }

        public ICollection<DelegateProvision> delegateProvisions { get; set; }
    }
}
