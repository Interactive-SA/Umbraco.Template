using System.Data;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.ComponentModel;
using System.Globalization;
using System.Text.RegularExpressions;
using Umbraco.Cms.Core.Models;
using System.Reflection;
using Umbraco.Cms.Core.Models.PublishedContent;
using System.Net;
using System.Net.Mail;
using System.Text;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.Common;
using System.Web;
using Umbraco.Cms.Core.Strings;
using Umbraco.Cms.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using File = System.IO.File;

namespace NetCore.Models
{
    public static class SharedHelper
    {
        #region keys
        public static bool IsArabic
        {
            get
            {
                return System.Globalization.CultureInfo.CurrentUICulture.Name.ToLower().Contains("ar");
            }
        }
        public static string Lang { get { return IsArabic ? "ar" : "en"; } }
        public static string LangURL { get { return IsArabic ? "" : "/en"; } }
        public static string Culture
        {
            get
            {
                return System.Globalization.CultureInfo.CurrentUICulture.Name;
            }
        }
        public static string SharedIcon { get { return "/css/assets/images/shared/palm-swords-4.png"; } }
        public static string SharedLogo { get { return "/css/assets/images/shared/palm-swords-4.png"; } }
        public static string smtpLocation { get { return "Umbraco:CMS:Global:Smtp:"; } }
        public static string PortalPath { get { return ConfigurationManager.AppSetting[smtpLocation + "PortalPath"].ToStringNull(); } }
        internal static string PathDirectory
        {
            get
            {
                try
                {
                    var PathDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    return PathDirectory + @"\Files\";
                }
                catch (Exception ex)
                {

                }
                return "";
            }
        }

        #endregion

        #region localization

        public static string GetString(string v)
        {
            return v;
        }
        public static string GetDictionaryValue(string key, UmbracoHelper? serviceContext)
        {
            try
            {
                if (serviceContext != null)
                {
                    var val = serviceContext.GetDictionaryValue(key);
                    return string.IsNullOrEmpty(val) ? key : val;
                }
            }
            catch (Exception ex)
            {

            }
            return key;
        }
        public static string GetDictionaryValue(string key, ServiceContext? serviceContext, CultureInfo culture)
        {
            try
            {
                if (serviceContext != null)
                {
                    var dictionaryItem = serviceContext.LocalizationService.GetDictionaryItemByKey(key);
                    if (dictionaryItem != null)
                    {
                        var translation = dictionaryItem.Translations.SingleOrDefault(x => x.Language.CultureInfo.Equals(culture));
                        if (translation != null)
                        {
                            return translation.Value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return key;
        }

        #endregion

        #region log

        public static void LogException(Exception ex = null, string info = "", string MethodName = "", string ClassName = "")
        {
            #region latest log errors in c drive

            string filePath = string.Empty;
            string InnerException = string.Empty;
            string error = string.Empty;

            try
            {
                #region create the log file

                var directory = @"c:\_ErrorLogs\";
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                string date = DateTime.Now.Date.ToString("dd-MM-yyyy", new CultureInfo("en-US"));
                filePath = directory + date + ".txt";
                if (!System.IO.File.Exists(filePath))
                {
                    string content = "";
                    System.IO.File.WriteAllText(filePath, content);
                }

                #endregion

                #region error date

                try
                {
                    date = DateTime.Now.ToString("dd-MM-yyyy HH:mm", new CultureInfo("en-US"));
                    if (ex != null)
                    {
                        InnerException += "\n" + ex.InnerException ?? string.Empty;
                    }
                }
                catch
                {

                }

                if (ex == null)
                {
                    error = info;
                }
                else
                {
                    error = ex.ToString();
                }

                #endregion

                #region add the Exception

                var exceptionContent = "";

                exceptionContent += "====================================================================";
                exceptionContent += "\n" + "====================================================================";
                exceptionContent += "\n" + "Date: " + date;
                if (!string.IsNullOrEmpty(MethodName))
                {
                    exceptionContent += "\n" + "MethodName: " + "\n" + MethodName;
                }
                if (!string.IsNullOrEmpty(ClassName))
                {
                    exceptionContent += "\n" + "LocationURL: " + "\n" + ClassName;
                }
                exceptionContent += "\n" + "Error: " + "\n" + error;

                var allText = File.ReadAllLines(filePath).ToList();
                allText.Insert(0, exceptionContent);
                File.WriteAllLines(filePath, allText.ToArray());

                #endregion
            }
            catch
            {

            }

            #endregion
        }
        public static void LogInformation(string info, string MethodName = "", string LocationURL = "")
        {
            #region log to txt file

            string path = SharedHelper.PathDirectory + @"\logfile.txt";

            // This text is added only once to the file.
            if (!System.IO.File.Exists(path))
            {
                Directory.CreateDirectory(SharedHelper.PathDirectory);

                // Create a file to write to.
                using (StreamWriter sw = System.IO.File.CreateText(path))
                {
                    sw.WriteLine("logfile.txt");
                    sw.WriteLine("---------------------------------");
                }
            }

            try
            {
                if (string.IsNullOrEmpty(MethodName))
                {
                    MethodName = "K2_Tools_Assembly";
                }
                if (string.IsNullOrEmpty(LocationURL))
                {
                    LocationURL = "";
                }
            }
            catch (Exception exx)
            {

            }

            // This text is always added, making the file longer over time
            // if it is not deleted.
            using (StreamWriter sw = System.IO.File.AppendText(path))
            {
                sw.WriteLine("Date: " + DateTime.Now.ToString());
                sw.WriteLine("MethodName: " + MethodName);
                sw.WriteLine("LocationURL: " + LocationURL);
                sw.WriteLine("Error: ");
                sw.WriteLine(info);
                sw.WriteLine("---------------------------------");
            }

            #endregion
        }

        #endregion

        #region umbraco
        public static string EmailBody(string logo = "") // , bool IsDevelopment = false
        {
            string body = string.Empty;

            try
            {
                string color = "#80057C";
                color = "#7A6AF7";

                body = "<table cellpadding='0' cellspacing='0' dir='rtl' width='100%'> <tbody> <tr> <td style='padding:10px 5px;text-align: center;background:" + color + ";'><img alt='' src='" + logo + "' style='width: 130px;'></td> </tr> <tr> <td> <hr border='0' style='height:3px;background-color: " + color + ";border:0px'></td> </tr> <tr> <td style='padding:10px 20px;text-align: center;'> " +
                    //"<h3 style='font:20px arial;color: " + color + ";'> #Title# </h3> " +
                    "<div style='font:bold 15px arial;color:#666'> #Message# </div> </td> </tr> <tr> <td align='center'> <hr style='background-color: " + color + ";height:1px;border:0px'> <p style='font:12px tahoma;color:#666;text-align:center;margin-top:4px'> #Footer# </p> </td> </tr> </tbody> </table>";

                body = body
                    .Replace("#Title#", "عزيزي،")
                    .Replace("#Footer#", "كافة الحقوق محفوظة ©")
                    ;
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            return body;
        }

        public static List<SelectListItem> GetList(int pageID, string ModelTypeAlias, UmbracoHelper Umbraco)
        {
            var list = new List<SelectListItem>();

            try
            {
                var items = Umbraco.Content(pageID)?
                                .ChildrenOfType(ModelTypeAlias)?
                                .Where(x => x.IsVisible())
                                .OrderBy(p => p.Value<int>("Order"))
                                ;

                if (items?.Count() > 0)
                {
                    foreach (var item in items)
                    {
                        list.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToStringNull() });
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }

        public static List<SelectListItem> GetOrderList(UmbracoHelper Umbraco)
        {
            var list = new List<SelectListItem>();

            try
            {
                list.Add(new SelectListItem() { Text = SharedHelper.GetDictionaryValue("OrderDesc", Umbraco), Value = "1" });
                list.Add(new SelectListItem() { Text = SharedHelper.GetDictionaryValue("OrderAsc", Umbraco), Value = "2" });
            }
            catch (Exception ex)
            {

            }

            return list;
        }


        #endregion
    }

    public static class CustomExtensions
    {
        #region custom

        public static int ToInt32(this object text)
        {
            int val = 0;

            try
            {
                if (text != null)
                {
                    val = Convert.ToInt32(text);
                }
            }
            catch (Exception ex)
            {

            }

            return val;
        }
        public static int ToInt32_Count(this object? text, int maxRecords_default = 50)
        {
            var maxRecords = 0;

            try
            {
                if (text != null)
                {
                    maxRecords = Convert.ToInt32(text);
                    //return Convert.ToInt32(text);
                }
            }
            catch (Exception ex)
            {
                //SharedHelper.LogException(ex);
            }

            //if (maxRecords <= 0)
            //{
            //    maxRecords = 50;
            //}

            return maxRecords;
        }
        public static int ToInt32_Count2(this object? text, int pageSize_default = 6)
        {
            int pageSize = 0;

            try
            {
                if (text != null)
                {
                    pageSize = Convert.ToInt32(text);
                    //return Convert.ToInt32(str);
                }
            }
            catch (Exception ex)
            {
                //SharedHelper.LogException(ex);
            }

            //if (pageSize <= 0)
            //{
            //    pageSize = 0;// 9;
            //}

            return pageSize;
        }
        public static int? ToInt32Null(this String str)
        {
            try
            {
                if (!string.IsNullOrEmpty(str))
                {
                    return Convert.ToInt32(str);
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }
        public static string ToStringNull(this object? text, string default_value = "")
        {
            string val = "";

            try
            {
                if (text != null)
                {
                    val = Convert.ToString(text);
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            if (string.IsNullOrEmpty(val) && !string.IsNullOrEmpty(default_value))
            {
                val = default_value;
            }

            return val;
        }
        public static string ToStringNull2(this object? text, string default_value = "")
        {
            string val = string.Empty;

            try
            {
                if (text != null)
                {
                    var aa = (Microsoft.Extensions.Primitives.StringValues)text;
                    if (aa.Count > 0)
                    {
                        val = Convert.ToString(aa[0]);
                    }
                    else
                    {
                        val = Convert.ToString(text);
                    }
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            if (string.IsNullOrEmpty(val) && !string.IsNullOrEmpty(default_value))
            {
                val = default_value;
            }

            return val;
        }
        public static string ToHTML(this object? text)
        {
            try
            {
                if (text != null)
                {
                    //string html = Regex.Replace(text.ToString(), @"\r\n?|\n", @"<br/>");
                    //return html;
                    return text.ToString().Replace("\n", "<br/>");
                }
            }
            catch (Exception ex)
            {

            }

            return text.ToStringNull();
        }
        public static string ToHtmlDecode(this string? text)
        {
            try
            {
                if (text != null)
                {
                    return HttpUtility.HtmlDecode(text);
                }
            }
            catch (Exception ex)
            {

            }

            return text.ToStringNull();
        }
        public static string ToSplit(this string text, int index)
        {
            try
            {
                if (!string.IsNullOrEmpty(text))
                {
                    return text.Split(" ")[index];
                }
            }
            catch (Exception ex)
            {

            }

            return String.Empty;
        }
        public static string ToTitleCase(this string text)
        {
            try
            {
                // Creates a TextInfo based on the "en-US" culture.
                TextInfo textInfo = new System.Globalization.CultureInfo("en-US", false).TextInfo;

                // Changes a string to titlecase.
                return textInfo.ToTitleCase(text);
            }
            catch (Exception ex)
            {

            }
            return text;
        }
        public static decimal ToDecimal(this object str)
        {
            try
            {
                return Convert.ToDecimal(str);
            }
            catch (Exception ex)
            {

            }

            return 0;
        }
        public static Guid ToGuid(this object str)
        {
            try
            {
                if (str != null)
                {
                    return new Guid(str.ToString());
                }
            }
            catch (Exception ex)
            {

            }
            return Guid.Empty;
        }
        public static bool ToBoolean2(this bool? str)
        {
            try
            {
                if (str != null)
                {
                    if (str.ToString() == "1")
                    {
                        return true;
                    }
                    if (str.ToString() == "0")
                    {
                        return false;
                    }
                    if (str.ToString().ToLower() == "True".ToLower())
                    {
                        return true;
                    }
                    if (str.ToString().ToLower() == "False".ToLower())
                    {
                        return false;
                    }
                    return Convert.ToBoolean(str);
                }
            }
            catch (Exception ex)
            {

            }

            return false;
        }
        public static bool ToBoolean(this object str)
        {
            try
            {
                if (str != null)
                {
                    if (str.ToString() == "1")
                    {
                        return true;
                    }
                    if (str.ToString() == "0")
                    {
                        return false;
                    }
                    if (str.ToString().ToLower() == "True".ToLower())
                    {
                        return true;
                    }
                    if (str.ToString().ToLower() == "False".ToLower())
                    {
                        return false;
                    }
                    return Convert.ToBoolean(str);
                }
            }
            catch (Exception ex)
            {

            }

            return false;
        }
        public static int toIntEnum(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }
        public static string toStringEnum(this Enum enumValue)
        {
            return enumValue.ToString();
        }
        public static string ToDescriptionString(this Enum val)
        {
            //Description enum to ID type string
            DescriptionAttribute[] attributes = (DescriptionAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length > 0 ? attributes[0].Description : string.Empty;
        }
        public static string ToRemoveJsonProperty(this string text, string property)
        {
            try
            {
                var o = (JObject)JsonConvert.DeserializeObject(text);
                if (o.Property(property) != null)
                {
                    o.Property(property).Remove();
                }
                return o.ToString();
            }
            catch (Exception ex)
            {

            }

            return text;
        }
        public static int ToWordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }
        public static string ToEnglishNumber(this string input)
        {
            try
            {
                string EnglishNumbers = "";

                for (int i = 0; i < input.Length; i++)
                {
                    if (Char.IsDigit(input[i]))
                    {
                        EnglishNumbers += char.GetNumericValue(input, i);
                    }
                    else
                    {
                        EnglishNumbers += input[i].ToString();
                    }
                }

                return EnglishNumbers;
            }
            catch (Exception ex)
            {

            }

            return input;
        }
        public static string ToTranslateText(this string text)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }

            return text;
        }
        public static List<int> ToListIntger(this object? str, string comma = ",")
        {
            var list = new List<int>();
            try
            {
                if (str != null)
                {
                    var data = (List<IPublishedContent>)str;
                    return data.Select(p => p.Id).Distinct().ToList();
                }
            }
            catch (Exception ex)
            {
                try
                {
                    var data = (IPublishedContent)str;
                    list.Add(data.Id);
                }
                catch (Exception ex2)
                {

                }
            }
            return list;
            //try
            //{
            //    if (str != null)
            //    {
            //        var data = str.ToString();

            //        if (!string.IsNullOrEmpty(data))
            //        {
            //            return data.Split(comma).Select(Int32.Parse).ToList();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{

            //}
            //return new List<int>();
        }
        public static List<IPublishedContent> ToListIntger2(this object? str, string comma = ",")
        {
            List<IPublishedContent> list = new List<IPublishedContent>();
            try
            {
                if (str != null)
                {
                    list = (List<IPublishedContent>)str;
                }
            }
            catch (Exception ex)
            {
                try
                {
                    list.Add((IPublishedContent)str);
                }
                catch (Exception ex2)
                {

                }
            }
            return list;
        }
        public static List<string> ToListString(this object? str, string comma = ",")
        {
            try
            {
                if (str != null)
                {
                    if (!string.IsNullOrEmpty(str.ToStringNull()))
                    {
                        return str.ToString().Split(comma).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return new List<string>();
        }
        public static string ToListJoin(this List<string> selected)
        {
            try
            {
                if (selected != null && selected.Count > 0)
                {
                    return string.Join(",", selected);
                }
            }
            catch (Exception ex)
            {

            }

            return string.Empty;
        }
        public static string ToListJoin(this List<int> selected)
        {
            try
            {
                if (selected != null && selected.Count > 0)
                {
                    return string.Join(",", selected);
                }
            }
            catch (Exception ex)
            {

            }

            return string.Empty;
        }
        public static List<int> ToListIntger(this IEnumerable<string> str)
        {
            var list = new List<int>();

            try
            {
                foreach (var item in str)
                {
                    list.AddRange(item.ToListIntger());
                }
            }
            catch (Exception ex)
            {

            }

            return list;
        }
        public static string ToSplit(this String input, string split = ".", int index = 1)
        {
            try
            {
                return SharedHelper.GetString(input.Split(split)[index]);
            }
            catch (Exception ex)
            {

            }

            return input;
        }
        public static string ToGetQueryValue(this IQueryCollection Query, string key)
        {
            try
            {
                if (Query != null)
                {
                    if (Query.ContainsKey(key) && !string.IsNullOrEmpty(Query[key][0]))
                    {
                        return Query[key][0];
                    }
                }
            }
            catch (System.Exception ex)
            {

            }

            return string.Empty;
        }
        public static string ToShowMessage(this string text, ReturnMessages msgType = ReturnMessages.Error, string linkURL = "", string linkText = "Link", string hideDivID = "")
        {
            try
            {
                //text = SharedHelper.GetString(text);

                string script = "";
                string url = "";

                if (!string.IsNullOrEmpty(linkURL) && !string.IsNullOrEmpty(linkText))
                {
                    url = "&nbsp;&nbsp;<a href='" + linkURL + "'>" + SharedHelper.GetString(linkText) + "</a>";
                }

                if (!string.IsNullOrEmpty(hideDivID))
                {
                    hideDivID = "<script>$('" + hideDivID + "').hide();</script>";
                }

                if (msgType == ReturnMessages.Error)
                {
                    script = "<div class='alert alert-danger'>" + text + url + "</div>";
                }

                else if (msgType == ReturnMessages.Success)
                {
                    script = "<div class='alert alert-success'>" + text + url + "</div>";
                }

                else if (msgType == ReturnMessages.Warning)
                {
                    script = "<div class='alert alert-warning'>" + text + url + "</div>";
                }

                return script + hideDivID;
            }
            catch (Exception ex)
            {

            }

            return text;
        }

        #endregion

        #region html

        public static string ToTrimLetters(this IHtmlEncodedString? stringValue, int length)
        {
            return stringValue.ToStringNull().ToStripHTML(0, length);

            //return ToTrimLetters(stringValue.ToStringNull(), length);
        }
        public static string ToTrimLetters(this string stringValue, int length)
        {
            if (!string.IsNullOrEmpty(stringValue))
            {
                return stringValue.ToTurncateString(0, length);
            }
            return stringValue;

            try
            {
                if (!string.IsNullOrEmpty(stringValue))
                {
                    var regexAllTags = new Regex(@"<[^>]*>");
                    var regexIsTag = new Regex(@"<|>");
                    var regexOpen = new Regex(@"<[^/][^>]*>");
                    var regexClose = new Regex(@"</[^>]*>");
                    var regexAttribute = new Regex(@"<[^ ]*");

                    int necessaryCount = 0;

                    if (regexAllTags.Replace(stringValue, "").Length <= length)
                    {
                        return stringValue;
                    }

                    stringValue = stringValue.Trim();

                    string[] split = regexAllTags.Split(stringValue);
                    string counter = "";
                    foreach (string item in split)
                    {
                        if (counter.Length < length && counter.Length + item.Length >= length)
                        {
                            necessaryCount = stringValue.IndexOf(item, counter.Length) + item.Substring(0, length - counter.Length).Length;
                            break;
                        }
                        counter += item;
                    }

                    var x = regexIsTag.Match(stringValue, necessaryCount);
                    if (x.Value == ">")
                    {
                        necessaryCount = x.Index + 1;
                    }

                    string subs = stringValue.Substring(0, necessaryCount);
                    var openTags = regexOpen.Matches(subs);
                    var closeTags = regexClose.Matches(subs);

                    List<string> OpenTags = new List<string>();
                    foreach (var item in openTags)
                    {
                        string trans = regexAttribute.Match(item.ToString()).Value;

                        if (trans.Last() == '>')
                        {
                            trans = "</" + trans.Substring(1, trans.Length - 1);
                        }
                        else
                        {
                            trans = "</" + trans.Substring(1, trans.Length - 1) + ">";
                        }

                        OpenTags.Add(trans);
                    }

                    foreach (System.Text.RegularExpressions.Match close in closeTags)
                    {
                        OpenTags.Remove(close.Value);
                    }

                    for (int i = OpenTags.Count - 1; i >= 0; i--)
                    {
                        subs += OpenTags[i];
                    }

                    subs = Regex.Replace(subs, "<.*?>", String.Empty);

                    if (subs.Contains("</p>"))
                    {
                        return subs.Replace("</p>", "<span>...</span></p>");
                    }

                    return subs.Trim() + "<span>...</span>";
                }
            }
            catch (Exception ex)
            {

            }

            return "";
        }

        private static string ToStripHTML(this string stringInput, int MinLength, int MaxLength)
        {
            try
            {
                var html = string.IsNullOrEmpty(stringInput) is false ? Regex.Replace(stringInput, "<.*?>", string.Empty) : "";
                return html.ToTurncateString(MinLength, MaxLength);
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }
            return stringInput;
        }
        private static string ToTurncateString(this string stringInput, int MinLength, int MaxLength)
        {
            try
            {
                var html = stringInput.Length > MaxLength ? stringInput.Substring(MinLength, MaxLength) + "..." : stringInput;
                return html;
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }
            return stringInput;
        }

        #endregion

        #region To date time

        public static DateTime? ToDateTime(this string all)
        {
            try
            {
                if (!string.IsNullOrEmpty(all))
                {
                    all = all.Trim();

                    if (all.Contains(' '))
                    {
                        #region date with time

                        string dateOld = all.ToString().Split(' ')[0].Trim();
                        string time = all.ToString().Split(' ')[1].Trim();

                        string tt = "م";

                        if (all.ToString().Split(' ').Count() == 3)
                        {
                            tt = all.ToString().Split(' ')[2].Trim();
                        }

                        var date = dateOld.Split('-');

                        int day = 0;
                        int month = 0;
                        int year = date[2].ToInt32();

                        if (year.ToString().Length == 4)
                        {
                            day = date[0].ToInt32();
                            month = date[1].ToInt32();
                            year = date[2].ToInt32();
                        }
                        else
                        {
                            day = date[2].ToInt32();
                            month = date[1].ToInt32();
                            year = date[0].ToInt32();
                        }

                        int hour = time.ToString().Split(':')[0].ToInt32();
                        int mintue = time.ToString().Split(':')[1].ToInt32();

                        if (tt == "م")
                        {
                            hour = hour + 12;
                        }
                        if (hour >= 24)
                        {
                            hour = hour - 12;
                        }
                        if (tt == "ص" && hour == 12)
                        {
                            hour = 0;
                        }

                        return new DateTime(year, month, day, hour, mintue, 0);

                        #endregion
                    }
                    else
                    {
                        #region date only

                        var date = all.ToString().Trim().Split('-');

                        int day = 0;
                        int month = 0;
                        int year = date[2].ToInt32();

                        if (year.ToString().Length == 4)
                        {
                            day = date[0].ToInt32();
                            month = date[1].ToInt32();
                            year = date[2].ToInt32();
                        }
                        else
                        {
                            day = date[2].ToInt32();
                            month = date[1].ToInt32();
                            year = date[0].ToInt32();
                        }

                        return new DateTime(year, month, day, 0, 0, 0);

                        #endregion
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }
       
        /// <summary>
        /// convert datetime to picker full
        /// </summary>
        /// <param name="str"></param>
        /// <returns>datetime</returns>
        public static string ToDateTime(this DateTime date)
        {
            try
            {
                var culture = "ar-EG";

                if (!SharedHelper.IsArabic)
                {
                    culture = "en-US";
                }

                var converted =
                                  date.ToString("dd", System.Globalization.CultureInfo.GetCultureInfo("en-US")) + " "
                                + date.ToString("MMMM", System.Globalization.CultureInfo.GetCultureInfo(culture)) + " "
                                + date.ToString("yyyy", System.Globalization.CultureInfo.GetCultureInfo("en-US"))
                                //+ " "
                                //+ date.ToString("hh:mm tt", System.Globalization.CultureInfo.GetCultureInfo(culture))
                                ;
                return converted;
            }
            catch (Exception ex)
            {
                return date.ToShortDateString();
            }
        }

        #endregion

        #region umbraco

        public static string ToPageTitle(this IPublishedContent? page)
        {
            var pageTitle = "";

            try
            {
                if (page != null)
                {
                    pageTitle = page.Value("pageTitle").ToStringNull();
                    if (!string.IsNullOrEmpty(pageTitle))
                    {
                        return pageTitle;
                    }
                    else
                    {
                        return page.Name;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return pageTitle;
        }

        public static string ToIconURL(this IPublishedContent? image, string default_image = "")
        {
            try
            {
                if (image != null)
                {
                    var file = image; // ((IPublishedContent)image);
                    if (file != null && !string.IsNullOrEmpty(file.GetCropUrl()))
                    {
                        return file.GetCropUrl() ?? (string.IsNullOrEmpty(default_image) ? SharedHelper.SharedIcon : default_image);
                    }

                    //return ((MediaWithCrops)image).GetCropUrl();
                    //return ((Umbraco.Cms.Web.Common.PublishedModels.Image)image).GetCropUrl();
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            return string.IsNullOrEmpty(default_image) ? SharedHelper.SharedIcon : default_image;
        }

        public static string ToLinkURL(this object? link, string default_url = "#?")
        {
            try
            {
                if (link != null)
                {
                    var url = (Link)link;
                    if (!string.IsNullOrEmpty(url.Url))
                    {
                        return url.Url;
                    }
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            return default_url;
        }

        public static string ToLinkURL(this Link? link, string default_url = "#?")
        {
            try
            {
                if (link != null && !string.IsNullOrEmpty(link.Url))
                {
                    return link.Url;
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            return default_url;
        }

        public static string ToLinkTarget(this Link? link, bool newTab = false)
        {
            string default_target = newTab ? "_blank" : "_self";

            try
            {
                if (link != null && !string.IsNullOrEmpty(link.Target))
                {
                    default_target = link.Target;
                }

                if (link == null || (link != null && string.IsNullOrEmpty(link.Url)))
                {
                    default_target = "_self";
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            return default_target;
        }

        public static string ToLinkTitle(this object? link, string default_url = "")
        {
            try
            {
                if (link != null)
                {
                    var url = (Link)link;
                    if (!string.IsNullOrEmpty(url.Name))
                    {
                        return url.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            return default_url;
        }

        #endregion

        #region Website

        public static string ToLinkHTML(this string linkType, string linkTitle, Link linkURL, MediaWithCrops linkIcon, string linkCssClass)
        {
            string link = string.Empty;

            try
            {
                string url = "#?"; // linkURL
                string img = "/css/assets/images/home/twet.jpg"; //linkIcon

                if (linkURL != null)
                {
                    url = linkURL.Url;
                }

                if (linkIcon != null)
                {
                    img = linkIcon.GetCropUrl();
                }

                string direction = "";
                if (linkCssClass.Contains("ltr"))
                {
                    direction = "dir='ltr'";
                }
                if (linkCssClass.Contains("rtl"))
                {
                    direction = "dir='rtl'";
                }

                LinkType type = linkType.ToLinkType();

                if (type == LinkType.Title)
                {
                    link = "<li class='" + linkCssClass + " headLink' >" + "<h6 class='headLink'>" + linkTitle + "</h6>" + "</li>";
                }
                else if (type == LinkType.Link)
                {
                    link = "<li class='" + linkCssClass + "' >" + "<a href='" + url + "' target='" + linkURL.ToLinkTarget() + "'>" + linkTitle + "</a>" + "</li>";
                }
                else if (type == LinkType.SocialLink)
                {
                    link = "<li class='" + linkCssClass + "' >" + "<a href='" + url + "' target='" + linkURL.ToLinkTarget() + "'><img src='" + img + "' ></a>" + "</li>";
                }
                else if (type == LinkType.ImageBeforeLink)
                {
                    if (!string.IsNullOrEmpty(url) && !url.Contains("#"))
                    {
                        link = "<li class='" + linkCssClass + "' >" + "<a href='" + url + "' target='" + linkURL.ToLinkTarget() + "' class='withLogo'> <img src='" + img + "' > <span " + direction + " >" + linkTitle + "</span> </a>" + "</li>";
                    }
                    else
                    {
                        link = "<li class='" + linkCssClass + "' >" + "<div class='withLogo'> <img src='" + img + "' > <span " + direction + " >" + linkTitle + "</span> </div>" + "</li>";
                    }
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            return link;
        }

        public static LinkType ToLinkType(this string linkType)
        {
            try
            {
                string type = linkType.ToStringNull();

                if (!string.IsNullOrEmpty(type))
                {
                    if (type == "Title")
                    {
                        return LinkType.Title;
                    }
                    else if (type == "Link")
                    {
                        return LinkType.Link;
                    }
                    else if (type == "Social Link")
                    {
                        return LinkType.SocialLink;
                    }
                    else if (type == "Image before link")
                    {
                        return LinkType.ImageBeforeLink;
                    }
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            return LinkType.Title;
        }

        #endregion
    }

    #region send emails

    public class EmailUtility
    {
        private readonly IConfiguration _Configuration;
        public EmailUtility(IConfiguration configuration) => this._Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        public bool SendEmail(
          string ToEmail,
          string CC,
          string Subject,
          string Body,
          bool isArabic,
          string From_Email,
          string From_Name)
        {
            string str1 = this._Configuration.GetValue<string>("PortalPath");

            try
            {
                using (SmtpClient smtpClient = new SmtpClient())
                {
                    MailMessage message = new MailMessage(new MailAddress(this._Configuration.GetValue<string>("FromEmail"), From_Name, Encoding.UTF8), new MailAddress(ToEmail));

                    if (!string.IsNullOrEmpty(CC))
                    {
                        message.CC.Add(new MailAddress(CC));
                    }

                    Body = Body.Replace("src=\"/", "src=\"" + str1 + "/").Replace("src='/", "src='" + str1 + "/").Replace("href=\"/", "href=\"" + str1 + "/").Replace("href='/", "href='" + str1 + "/");

                    string str2 = isArabic ? "dir='rtl'" : "dir='ltr'";

                    message.Body = "<div " + str2 + " >" + Body + "</div>";
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;
                    message.SubjectEncoding = Encoding.UTF8;
                    message.Subject = Subject;

                    string str3 = this._Configuration.GetValue<string>("SMTPHost");

                    if (!string.IsNullOrEmpty(this._Configuration.GetValue<string>("SMTP_Port")))
                    {
                        string str4 = this._Configuration.GetValue<string>("SMTP_Port");
                        smtpClient.Port = Convert.ToInt32(str4);
                    }
                    if (!string.IsNullOrEmpty(this._Configuration.GetValue<string>("SMTP_SSL")))
                    {
                        bool boolean = Convert.ToBoolean(this._Configuration.GetValue<string>("SMTP_SSL"));
                        smtpClient.EnableSsl = boolean;
                    }
                    if (!string.IsNullOrEmpty(this._Configuration.GetValue<string>("SMTPUsername")) && !string.IsNullOrEmpty(this._Configuration.GetValue<string>("SMTPPassword")))
                    {
                        string userName = this._Configuration.GetValue<string>("SMTPUsername");
                        this._Configuration.GetValue<string>("SMTPUsername");
                        string password = this._Configuration.GetValue<string>("SMTPPassword");
                        smtpClient.Credentials = (ICredentialsByHost)new NetworkCredential(userName, password);
                    }

                    smtpClient.Host = str3;
                    smtpClient.Send(message);

                    return true;
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            return false;
        }

        public bool SendEmail(string subject, string body, string emailTo, string CC = "", string BCC = "")
        {
            try
            {
                string smtpLocation = SharedHelper.smtpLocation;

                string fromName = _Configuration.GetValue<string>(smtpLocation + "FromName");
                string emailFrom = _Configuration.GetValue<string>(smtpLocation + "From");

                string _SMTPHost = _Configuration.GetValue<string>(smtpLocation + "Host");
                string userName = _Configuration.GetValue<string>(smtpLocation + "Username");
                string password = _Configuration.GetValue<string>(smtpLocation + "Password");
                string _SMTP_Port = _Configuration.GetValue<string>(smtpLocation + "Port");
                bool _SMTP_SSL = Convert.ToBoolean(_Configuration.GetValue<string>(smtpLocation + "SMTPSSL"));

                using (SmtpClient smtpClient = new SmtpClient())
                {
                    MailMessage message = new MailMessage(new MailAddress(emailFrom, fromName, Encoding.UTF8), new MailAddress(emailTo));

                    if (!string.IsNullOrEmpty(CC))
                    {
                        //message.CC.Add(new MailAddress(CC));
                        foreach (var item in CC.Split(';'))
                        {
                            message.CC.Add(item);
                        }
                    }

                    if (!string.IsNullOrEmpty(BCC))
                    {
                        foreach (var item in BCC.Split(';'))
                        {
                            message.Bcc.Add(item);
                        }
                    }

                    message.Subject = subject;
                    message.SubjectEncoding = Encoding.UTF8;

                    message.Body = body;
                    message.BodyEncoding = Encoding.UTF8;
                    message.IsBodyHtml = true;

                    smtpClient.Host = _SMTPHost;
                    smtpClient.Credentials = new NetworkCredential(userName, password);
                    smtpClient.Port = Convert.ToInt32(_SMTP_Port);
                    smtpClient.EnableSsl = _SMTP_SSL;

                    smtpClient.Send(message);
                }

                return true;
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }

            return false;
        }
    }

    #endregion
}

static class ConfigurationManager
{
    public static IConfiguration AppSetting { get; }
    static ConfigurationManager()
    {
        AppSetting = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
    }
}
