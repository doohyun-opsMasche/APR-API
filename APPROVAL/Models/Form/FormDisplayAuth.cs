﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    [Table("TB_FORM_DISPLAY_AUTH")]
    public class FormDisplayAuth
    {
        public FormDisplayAuth()
        {
            this.insertDate = DateTime.Now;
        }

        [Key]
        [Column("FORM_DISPLAY_AUTH_FORM_ID", Order = 2)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int? formId { get; set; } 

        [Key]
        [Column("FORM_DISPLAY_AUTH_ID", Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public int? authId { get; set; } 

        [ForeignKey("formId")]
        public Form form { get; set; }

        [Column("FORM_DISPLAY_AUTH_RESOURCE")]
        [StringLength(20, MinimumLength = 8, ErrorMessageResourceName = "RangeErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string authResource { get; set; }

        [Column("FORM_DISPLAY_AUTH_TYPE")]
        [StringLength(8, MinimumLength = 8, ErrorMessageResourceName = "FixedErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public string authType { get; set; }

        [Column("INS_DATE")]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(DefineMessage))]
        public DateTime? insertDate { get; set; }
    }
}
