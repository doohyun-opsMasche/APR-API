using Microsoft.AspNetCore.SignalR;
using Microsoft.Diagnostics.Tracing.Parsers.AspNet;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM")]
    public class TB_FORM
    {
        public TB_FORM(): base()
        {
            this.formDocumentNumberFlag = "Y";
            this.formDelayAlertDay = 0;
            this.formDelayAlertTime = "0000";
            this.fromDocumentTransferFlag = "N";
            this.fromDirectionFlag = "";
            this.formMandatoryFlag = "N";
            this.formLegacyType = "LA";
            this.formApprovalLineModifyFlag = "YY";
            this.formDepartmentBoxReadFlag = "Y";

            this.tbFormDisplayAuths = new List<TB_FORM_DISPLAY_AUTH>();
        }

        [Key]
        [Column("FORM_ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "양식 ID가 필요 합니다.")]  // 변수로 설정을 할 생각이 있으면 전역으로 처리된 메시지 사용해야 함
        public int? formId { get; set; }

        [ForeignKey("TB_FORM_FILE_GROUP")]
        [Column("FORM_CATEGORY_ID")]
        public TB_FORM_CATEGORY formCategoryId { get; set; }

        [ForeignKey("FORM_FILE_GROUP_ID")]
        [Column("FORM_FILE_GROUP_ID")]
        public TB_FORM_FILE_GROUP formFormFileGroupId { get; set; }

        [Column("FORM_NM")]
        [StringLength(30, ErrorMessage = "1~30 자리 정보를 입력하여 주십시오." , MinimumLength = 1)]
        [Required(ErrorMessage = "양식 명을 입력하여 주십시오.")]
        public string formNm { get; set; }

        [Column("FORM_DESCRIPTION")]
        [MaxLength(4000, ErrorMessage ="4000자까지만 입력이 가능 합니다.")]
        public string formDescription { get; set; }

        [Column("FORM_SORT")]
        [Required(ErrorMessage = "정렬 순서를 입력하여 주십시오.")]
        public int? fromSort { get; set; }

        [Column("USE_FLAG")]
        [MaxLength(1)]
        [Required(ErrorMessage = "사용여부를 입력하여 주십시오.")]
        public string useFlag { get; set; }

        [Column("DISPLAY_FLAG")]
        [MaxLength(1)]
        [Required(ErrorMessage = "표시 정보를 입력하여 주십시오.")]
        public string displayFlag { get; set; }


        [Column("FORM_DELAY_ALERT_DAY")]
        [Required(ErrorMessage = "지연 알림 일수를 입력하여 주십시오.")]
        public int? formDelayAlertDay { get; set; }

        [Column("FORM_DELAY_ALERT_TIME")]
        [MaxLength(4)]
        [Required(ErrorMessage = "지연 알림 시간을 입력하여 주십시오.")]
        public string formDelayAlertTime { get; set; }

        [Column("FORM_LEGACY_FLAG")]
        [MaxLength(1)]
        [Required(ErrorMessage = "레거시 입력 여부를 입력하여 주십시오.")]
        public string formLegacyFlag { get; set; }

        [Column("FORM_LEGACY_TYPE")]
        public string formLegacyType { get; set; }

        [Column("FORM_LEGACY_URL")]
        public string formLegacyUrl { get; set; }

        [Column("FORM_DOCUMENT_NUMBER_FLAG")]
        [MaxLength(1)]
        [Required(ErrorMessage = "문서번호 발번 여부를 입력하여 주십시오.")]
        public string formDocumentNumberFlag { get; set; }

        [Column("FORM_DOCUMENT_TRANSFER_FLAG")]
        [MaxLength(1)]
        [Required(ErrorMessage = "문서 이동 여부를 입력하여 주십시오.")]
        public string fromDocumentTransferFlag { get; set; }

        [Column("FORM_DIRECTION_FLAG")]
        [MaxLength(1)]
        [Required(ErrorMessage = "문서 방향을 입력하여 주십시오.")]
        public string fromDirectionFlag { get; set; }

        [Column("FORM_APPROVAL_LINE_MODIFY_FLAG")]
        [MaxLength(1)]
        [Required(ErrorMessage = "결재 라인 변경 권한을 입력하여 주십시오.")]
        public string formApprovalLineModifyFlag { get; set; }

        [Column("FORM_DEPARTMENT_BOX_READ_FLAG")]
        [MaxLength(1)]
        [Required(ErrorMessage = "부서함 조회 여부를 입력하여 주십시오.")]
        public string formDepartmentBoxReadFlag { get; set; }

        [Column("FORM_MANDATORY_FLAG")]
        [MaxLength(1)]
        [Required(ErrorMessage = "전결 규정 적용 여부를 입력하여 주십시오.")]
        public string formMandatoryFlag { get; set; }

        [Column("FORM_DELEGATE_POLICY_ID")]
        public string formDelegatePolicyId { get; set; }


        public List<TB_FORM_DISPLAY_AUTH> tbFormDisplayAuths { get; set; }
    }
}
