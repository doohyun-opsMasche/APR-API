using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_DELEGATION_USER")]
    public class DelegationUser
    {
        public DelegationUser()
        {
            this.useFlag = "Y";
            this.insertDate = DateTime.Now;
        }

        #region 테이블 컬럼 구조
        /*
        DELEGATION_ID               int             대결자 고유 아이디 PK
        DELEGATION_REQUEST_USER_ID  varchar(20)     대결 요청자 아이디
        DELEGATION_USER_ID          varchar(20)     대결자 아이디
        DELEGATION_START_TIME       datetime        대결 시작 기간
        DELEGATION_END_TIME         datetime        대결 종료 기간
        USE_FLAG                    char(1)         사용 여부
        INS_DATE                    datetime        생성일
        */
        #endregion

        [Key]
        [Column("DELEGATION_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public int id { get; set; }

        [Column("DELEGATION_REQUEST_USER_ID")]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string requestUserId { get; set; }

        [Column("DELEGATION_USER_ID")]
        [StringLength(20, MinimumLength = 1, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string userId { get; set; }

        [Column("DELEGATION_START_TIME")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime startTime { get; set; }

        [Column("DELEGATION_END_TIME")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime endTime { get; set; }

        [Column("USE_FLAG", TypeName = "char(1)")]
        [MaxLength(1, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(Define))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string useFlag { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public DateTime? insertDate { get; set; }
    }
}
