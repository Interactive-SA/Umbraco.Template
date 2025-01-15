using Umbraco.Cms.Core.Cache;
using Umbraco.Cms.Core.Logging;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Web;
using Umbraco.Cms.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core.Models;
using Umbraco.Cms.Web.Website.Controllers;
using NetCore.Models;
using Umbraco.Cms.Web.Common.PublishedModels;
using System.Globalization;
using Umbraco.Cms.Web.Common;

namespace NetCore.Controllers
{
    public class FormsController : SurfaceController
    {
        private readonly IConfiguration _Configuration;
        private readonly ServiceContext _ServiceContext;
        private readonly DocumentTypeFetcher _documentTypeFetcher;

        public FormsController(IConfiguration configuration,
           IUmbracoContextAccessor umbracoContextAccessor,
           IUmbracoDatabaseFactory databaseFactory,
           ServiceContext ServiceContext,
           AppCaches appCaches,
           IProfilingLogger profilingLogger,
           IPublishedUrlProvider publishedUrlProvider,
           UmbracoHelper umbracoHelper)
           : base(umbracoContextAccessor, databaseFactory, ServiceContext, appCaches, profilingLogger, publishedUrlProvider)
        {

            _Configuration = configuration;
            _ServiceContext = ServiceContext;
            _documentTypeFetcher = new DocumentTypeFetcher(umbracoHelper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ContactUs(ContactUsViewModel viewModel)
        {
            CultureInfo culture = new CultureInfo(viewModel.Culture);

            try
            {
                if (!this.ModelState.IsValid)
                {
                    viewModel.Success = false;
                    viewModel.ResultMessage = SharedHelper.GetDictionaryValue("InvalidForm", _ServiceContext, culture).ToShowMessage();
                    return Content(viewModel.ResultMessage);
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
                viewModel.Success = false;
                viewModel.ResultMessage = SharedHelper.GetDictionaryValue("InvalidForm", _ServiceContext, culture).ToShowMessage();
                return Content(viewModel.ResultMessage);
            }

            try
            {
                var form = _documentTypeFetcher.GetContentByAlias(Dt_FormContactUs.ModelTypeAlias).FirstOrDefault();
                if (form != null)
                {
                    int formID = form.Id;
                    string formAlias = Dt_FormContactUsItem.ModelTypeAlias;

                    IContentService contentService = this.Services.ContentService;
                    IContent byId = contentService.GetById(formID);
                    IContent content = contentService.Create(viewModel.FullName, byId, formAlias);

                    content.SetValue("fullName", viewModel.FullName);
                    content.SetValue("email", (object)viewModel.Email);
                    content.SetValue("mobile", (object)viewModel.Mobile);
                    content.SetValue("message", (object)viewModel.Message);

                    bool valid = contentService.SaveAndPublish(content).Success;
                    if (valid)
                    {
                        viewModel.Success = true;

                        bool SendEmails = _Configuration[SharedHelper.smtpLocation + "SendEmails"].ToBoolean();
                        if (SendEmails)
                        {
                            string domain = _Configuration[SharedHelper.smtpLocation + "PortalPath"];
                            string toEmail = viewModel.SendToEmail;

                            bool isArabic = SharedHelper.IsArabic;
                            string subject = viewModel.Subject;

                            string link = "&nbsp;<br/><br/><a href='#link#'>" + "تفاصيل الطلب" + "</a>";
                            string requestURL = domain +
                                "/umbraco#/content/content/edit/" + content?.Id + $"?list={formID}"
                                ;
                            link = link.Replace("#link#", requestURL.Replace("//", "/"));

                            string body = SharedHelper.EmailBody(domain + SharedHelper.SharedLogo);

                            body = body.Replace("#Message#",
                                                        "يوجد طلب جديد في نموذج اتصل بنا."
                                                        + link
                                                        + "<br/><br/>"
                                                        + "سعدنا بخدمتكم ونسعى لرضاكم");

                            new EmailUtility(this._Configuration).SendEmail(subject, body, toEmail);
                        }

                        viewModel.ResultMessage = SharedHelper.GetDictionaryValue("ContactUS_Success", _ServiceContext, culture).ToShowMessage(msgType: ReturnMessages.Success, hideDivID: $"#form_contactus{viewModel.FormName}");

                        viewModel.FullName = string.Empty;
                        viewModel.Email = string.Empty;
                        viewModel.Mobile = string.Empty;
                        viewModel.Message = string.Empty;

                        return Content(viewModel.ResultMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            viewModel.Success = false;
            viewModel.ResultMessage = SharedHelper.GetDictionaryValue("InvalidFormInsert", _ServiceContext, culture).ToShowMessage();

            return Content(viewModel.ResultMessage);
        }

    }

}
