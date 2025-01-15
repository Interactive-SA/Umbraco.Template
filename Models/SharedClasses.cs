using Examine;
//using reCAPTCHA.AspNetCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;
using Umbraco.Cms.Core.Models.Blocks;
using System.Dynamic;
using DGA.Resources;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

namespace NetCore.Models
{
    
    public class ContactUsViewModel
    {

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationRSS))]
        [RegularExpression("^[a-zA-Z \\n \\r ء-ي]+$", ErrorMessageResourceName = "OnlyAlphabetic", ErrorMessageResourceType = typeof(ValidationRSS))]
        public string FullName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationRSS))]
        [RegularExpression("^([a-zA-Z0-9_\\-\\.]+)@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.)|(([a-zA-Z0-9\\-]+\\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\\]?)$", ErrorMessageResourceName = "invalidEmail", ErrorMessageResourceType = typeof(ValidationRSS))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationRSS))]
        [RegularExpression(@"^\+\d{1,3}\s?\d{3,14}$", ErrorMessageResourceName = "InvalidMobile", ErrorMessageResourceType = typeof(ValidationRSS))]
        public string Mobile { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(ValidationRSS))]
        public string Message { get; set; }
       
        public bool Success { get; set; }
        public string? ResultMessage { get; set; }

        public string Culture { get; set; } = "ar-SA";
        public UmbracoHelper? Umbraco { get; set; }
        public bool IsHome { get; set; }
        public int FormID { get; set; }
        public string FormName { get; set; }
        public string SendToEmail { get; set; }
        public string Subject { get; set; }
    }
    
    public class Pager
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 9;
        public int TotalPages { get; set; }
        public int MaxRecords { get; set; }

        public string Query { get; set; }
        public string Keyword { get; set; }
        public string Date { get; set; }
        public string OrderByDesc { get; set; } = "1";        
        public List<int> Paths { get; set; }
        public List<SelectListItem> OrderList { get; set; }

        public string PageUdi { get; set; }
        public string PagerName { get; set; } = "umbPagerLink";
    }

    public enum LinkType
    {
        Title,
        Link,
        SocialLink,
        ImageBeforeLink
    }

    public enum ReturnMessages
    {
        Error,
        Success,
        Warning
    }

}
