using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

namespace APPROVAL.Models.Sample
{

    [Table("TB_SAMPLE_A")]
    public class SampleA
    {
        public SampleA()
        {
            this.sampleCode = "디폴트 값";
        }

        // 기본 키 설정 샘플
        [Key]                                                   // 기본키
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   // 자동증가
        [Column("COLUMN_NAME_ID")]                              // 컬럼
        public int? key { get; set; }

        // 외례키 설정 샘플
        // 1:다
        [Column("SAMPLE_REFERENCE_KEY")]
        public int? sampleBReferenceKey { get; set; }

        [ForeignKey("sampleBReferenceKey")]
        public SampleB sampleB { get; set; }

        // 일반 컬럼 설정 샘플
        [Column("COLUMN_NAME_2")]
        [StringLength(300, ErrorMessageResourceName = "ScopeErrorMessage", ErrorMessageResourceType = typeof(Define), MinimumLength = 10)]
        [Required(ErrorMessageResourceName = "ErrorMessage", ErrorMessageResourceType = typeof(Define))]
        public string sampleCode { get; set; }

    }

    [Table("TB_SAMPLE_B")]
    public class SampleB
    {
        public SampleB()
        {

            this.sampleAs = new List<SampleA>();
        }

        [Key]
        [Column("COLUMN_KEY")]
        public int? sampleKey { get; set; }


        public ICollection<SampleA> sampleAs { get; set; }

        // Custom Validation 1 
        [NotMapped]
        [OldEnoughValidationAttribute(20, ErrorMessage = "나이가 충분하지 않습니다.")]
        public int? age { get; set; }

        // Custom Validation 2
        [NotMapped]
        [PhoneValidation("010-9999-9999", ErrorMessage = "{0}의 전화번호가 {1}가 매칭되지 않습니다.")]
        public string phone { get; set; }
    }

    // Custom Validation 1 
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class OldEnoughValidationAttribute : ValidationAttribute
    {
        public int LimitAge { get; set; }
        public OldEnoughValidationAttribute(int limitAge)
        {
            LimitAge = limitAge;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            int val = (int)value;

            if (val >= LimitAge)
                return ValidationResult.Success;
            else
                return new ValidationResult(ErrorMessageString);
        }
    }

    // Custom Validation 2
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    sealed public class PhoneValidationAttribute : ValidationAttribute
    {
        // Internal field to hold the mask value. 
        readonly string _mask;

        public string Mask
        {
            get { return _mask; }
        }

        public PhoneValidationAttribute(string mask)
        {
            _mask = mask;
        }


        public override bool IsValid(object value)
        {
            var phoneNumber = (String)value;
            bool result = true;
            if (this.Mask != null)
            {
                result = MatchesMask(this.Mask, phoneNumber);
            }
            return result;
        }

        // Checks if the entered phone number matches the mask. 
        internal bool MatchesMask(string mask, string phoneNumber)
        {
            if (mask.Length != phoneNumber.Trim().Length)
            {
                // Length mismatch. 
                return false;
            }
            for (int i = 0; i < mask.Length; i++)
            {
                if (mask[i] == 'd' && char.IsDigit(phoneNumber[i]) == false)
                {
                    // Digit expected at this position. 
                    return false;
                }
                if (mask[i] == '-' && phoneNumber[i] != '-')
                {
                    // Spacing character expected at this position. 
                    return false;
                }
            }
            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
              ErrorMessageString, name, this.Mask);
        }
    }

}