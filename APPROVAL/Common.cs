using APPROVAL.Resources;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Reflection;
using System.Text;

namespace APPROVAL
{
    public class Common
    {
        private readonly IOptionsMonitor<AppSettings> options;
        private readonly IStringLocalizerFactory factory;
        private readonly IHttpContextAccessor context;

        public Common(IOptionsMonitor<AppSettings> options, IStringLocalizerFactory factory, IHttpContextAccessor context)
        {
            this.options = options;
            this.factory = factory;
            this.context = context;
        }

        #region 쿠키 핸들링
        public IRequestCookieCollection GetCookies()
        {
            return context.HttpContext.Request.Cookies;
        }

        public string GetCookie(string key)
        {
            if (context.HttpContext.Request != null)
            {
                if (context.HttpContext.Request.Cookies.ContainsKey(key))
                {
                    return Base64Decode(context.HttpContext.Request.Cookies[key]);
                }
                return string.Empty;
            }
            else
            {
                return null;
            }
        }

        public void SetCookie(string key, string value, CookieOptions options = null)
        {
            if (options == null)
            {
                context.HttpContext.Response.Cookies.Append(key, Base64Encode(value));
            }
            else
            {
                context.HttpContext.Response.Cookies.Append(key, Base64Encode(value), options);
            }
        }
        #endregion 쿠키 핸들링 

        #region 리소스 값 가져오기
        /// <summary>
        /// 리소스 값 가져오기
        /// </summary>
        /// <param name="type">Resource 객체 이름(ex:WF_Resx)</param>
        /// <param name="key">Key 값</param>
        /// <returns>String</returns>
        public string GetGlobalResource(string strType, string strKey)
        {
            if (!string.IsNullOrEmpty(strType) && !string.IsNullOrEmpty(strKey))
                return GetLocalizer(strType)[strKey];
            else
                return "";
        }

        /// <summary>
        /// Resource 설정을 위한 팩토리 메소드
        /// </summary>
        /// <param name="type">Resource 객체 이름</param>
        /// <returns>IStringLocalizer</returns>
        private IStringLocalizer GetLocalizer(string strType)
        {
            IStringLocalizer localizer;

            switch (strType)
            {
                //case "Common":
                //    localizer = factory.Create(strType, GetAssemblyName<Common>().Name);
                //    break;

                default:
                    localizer = factory.Create("DefaultResource", GetAssemblyName<DefaultResource>().Name);
                    break;
            }

            return localizer;
        }

        /// <summary>
        /// AssemblyName 반환 함수 일반화
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>AssemblyName</returns>
        private AssemblyName GetAssemblyName<T>() where T : IResource
        {
            return new AssemblyName(typeof(T).GetTypeInfo().Assembly.FullName);
        }

        #endregion 리소스 값 가져오기

        #region Base64Encode
        /// <summary>
        /// String을 Base64로 Encode한다.
        /// </summary>
        /// <param name="src">src (String) : Encode 할 String</param>
        /// <returns>string</returns>
        public string Base64Encode(string src)
        {
            Byte[] arr;
            UTF8Encoding utf8Enc;

            try
            {
                utf8Enc = new UTF8Encoding();
                arr = utf8Enc.GetBytes(src);
                return Convert.ToBase64String(arr);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region Base64Decode
        /// <summary>
        /// String을 Base64로 Decode한다.
        /// </summary>
        /// <param name="src">src (String) : Decode 할 String</param>
        /// <returns>string</returns>
        public string Base64Decode(string src)
        {
            Byte[] arr;
            UTF8Encoding utf8Enc;

            try
            {
                utf8Enc = new UTF8Encoding();
                arr = Convert.FromBase64String(src);
                return utf8Enc.GetString(arr);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

    }
}
