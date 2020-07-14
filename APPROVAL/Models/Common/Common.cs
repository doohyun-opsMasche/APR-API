using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPROVAL.Models
{
    /// <summary>
    /// Attribute 메시지 정의 클래스
    /// </summary>
    public class Define
    {
        public static string ErrorMessage
        {
            get
            {
                return "{0}을 입력해 주십시오.";
            }
        }

        public static string RangeErrorMessage
        {
            get
            {
                return "{0}의 범위는 {1}~{2}의 자릿수를 입력하여 주십시오";
            }
        }

        public static string FixedErrorMessage
        {
            get
            {
                return "{1}자리 길이값의 데이터만 입력 가능합니다.";
            }
        }
    }
}
