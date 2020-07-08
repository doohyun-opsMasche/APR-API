using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM_DISPLAY_AUTH")]
    public class TB_FORM_DISPLAY_AUTH
    {
        [Key]
        [Column("FORM_DISPLAY_AUTH_ID", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "DISP AUTH ID is required")]
        public int? formDisplayAuthId { get; set; } // int, not null

        [Key]
        [Column("FORM_DISPLAY_AUTH_FORM_ID", Order = 2)]
        [Required(ErrorMessage = "FORM ID is required")]
        public int? formDisplayAuthFormId { get; set; } // int, not null

        [ForeignKey("FORM_ID")]
        [Column("FORM_ID")]
        public TB_FORM formId { get; set; }


        [Column("FORM_DISPLAY_AUTH_RESOURCE")]
        [StringLength(20, ErrorMessage = "8~20 �ڸ� ������ �Է��Ͽ� �ֽʽÿ�.", MinimumLength = 8)]
        [Required(ErrorMessage = "���ҽ� ������ �Է��Ͽ� �ֽʽÿ�")]
        public string formDisplayAuthResource { get; set; } // nvarchar(20), null

        [Column("FORM_DISPLAY_AUTH_TYPE")]
        [StringLength(8, ErrorMessage = "8�ڸ� ������ �Է��Ͽ� �ֽʽÿ�.", MinimumLength = 8)]
        [Required(ErrorMessage = "���ҽ� Ÿ�� ������ �Է��Ͽ� �ֽʽÿ�")]
        public string formDisplayAuthType { get; set; } // nvarchar(9), null

    }
}
