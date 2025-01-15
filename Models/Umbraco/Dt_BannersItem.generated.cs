//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder.Embedded v13.2.0+7dff3a3
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Linq.Expressions;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Core.PublishedCache;
using Umbraco.Cms.Infrastructure.ModelsBuilder;
using Umbraco.Cms.Core;
using Umbraco.Extensions;

namespace Umbraco.Cms.Web.Common.PublishedModels
{
	/// <summary>Banners Item</summary>
	[PublishedModel("DT_BannersItem")]
	public partial class Dt_BannersItem : PublishedContentModel, IPageProperties, IPageSeo
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public new const string ModelTypeAlias = "DT_BannersItem";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<Dt_BannersItem, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public Dt_BannersItem(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// Details
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("details")]
		public virtual global::Umbraco.Cms.Core.Strings.IHtmlEncodedString Details => this.Value<global::Umbraco.Cms.Core.Strings.IHtmlEncodedString>(_publishedValueFallback, "details");

		///<summary>
		/// Icon / Image
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("image")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops Image => this.Value<global::Umbraco.Cms.Core.Models.MediaWithCrops>(_publishedValueFallback, "image");

		///<summary>
		/// URL
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("url")]
		public virtual global::Umbraco.Cms.Core.Models.Link Url => this.Value<global::Umbraco.Cms.Core.Models.Link>(_publishedValueFallback, "url");

		///<summary>
		/// CssClass
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("cssClass")]
		public virtual string CssClass => global::Umbraco.Cms.Web.Common.PublishedModels.PageProperties.GetCssClass(this, _publishedValueFallback);

		///<summary>
		/// Redirect URL
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("redirectURL")]
		public virtual global::Umbraco.Cms.Core.Models.Link RedirectUrl => global::Umbraco.Cms.Web.Common.PublishedModels.PageProperties.GetRedirectUrl(this, _publishedValueFallback);

		///<summary>
		/// Show breadcrumb
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showBreadcrumb")]
		public virtual bool ShowBreadcrumb => global::Umbraco.Cms.Web.Common.PublishedModels.PageProperties.GetShowBreadcrumb(this, _publishedValueFallback);

		///<summary>
		/// Show Coming Soon
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showComingSoon")]
		public virtual bool ShowComingSoon => global::Umbraco.Cms.Web.Common.PublishedModels.PageProperties.GetShowComingSoon(this, _publishedValueFallback);

		///<summary>
		/// Show in main menu
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showInMainMenu")]
		public virtual bool ShowInMainMenu => global::Umbraco.Cms.Web.Common.PublishedModels.PageProperties.GetShowInMainMenu(this, _publishedValueFallback);

		///<summary>
		/// Show in site map
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showInSiteMap")]
		public virtual bool ShowInSiteMap => global::Umbraco.Cms.Web.Common.PublishedModels.PageProperties.GetShowInSiteMap(this, _publishedValueFallback);

		///<summary>
		/// Show Page Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showPageTitle")]
		public virtual bool ShowPageTitle => global::Umbraco.Cms.Web.Common.PublishedModels.PageProperties.GetShowPageTitle(this, _publishedValueFallback);

		///<summary>
		/// Show sharing icons
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showSharingIcons")]
		public virtual bool ShowSharingIcons => global::Umbraco.Cms.Web.Common.PublishedModels.PageProperties.GetShowSharingIcons(this, _publishedValueFallback);

		///<summary>
		/// Canonical: Used in SEO, see: http://googlewebmastercentral.blogspot.com/2009/02/specify-your-canonical.html
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("Canonical")]
		public virtual string Canonical => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetCanonical(this, _publishedValueFallback);

		///<summary>
		/// Excluded Document Types
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("excludedDocumentTypes")]
		public virtual string ExcludedDocumentTypes => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetExcludedDocumentTypes(this, _publishedValueFallback);

		///<summary>
		/// Facebook App ID: In order to use Facebook Insights you must add the app ID to your page. Insights lets you view analytics for traffic to your site from Facebook. Find the app ID in your App Dashboard.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("FBAppID")]
		public virtual string FbappID => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetFbappID(this, _publishedValueFallback);

		///<summary>
		/// Hide From Xml Sitemap: whether to show this page on the XML sitemap
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("hideFromXmlSitemap")]
		public virtual bool HideFromXmlSitemap => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetHideFromXmlSitemap(this, _publishedValueFallback);

		///<summary>
		/// Menu Display Image
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("menuDisplayImage")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops MenuDisplayImage => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetMenuDisplayImage(this, _publishedValueFallback);

		///<summary>
		/// Menu Display Name
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("menuDisplayName")]
		public virtual string MenuDisplayName => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetMenuDisplayName(this, _publishedValueFallback);

		///<summary>
		/// Author: The name of the page’s author.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("metaAuthor")]
		public virtual string MetaAuthor => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetMetaAuthor(this, _publishedValueFallback);

		///<summary>
		/// Meta Description: A brief description of the content on your page. This text is shown below the title in a google search result The ideal length is between 130 and 155 characters.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("metaDescription")]
		public virtual string MetaDescription => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetMetaDescription(this, _publishedValueFallback);

		///<summary>
		/// Meta keywords: Keywords that describe the content of the page. This is considered optional since most modern search engines don't use this anymore.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("metaKeywords")]
		public virtual global::System.Collections.Generic.IEnumerable<string> MetaKeywords => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetMetaKeywords(this, _publishedValueFallback);

		///<summary>
		/// Meta Tag Block: Can input any text what you want to render in the HTML HEAD. For example:  {meta name="keywords" content="{Title}"}{meta http-equiv="charset" content="{Charset}"}
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("metaTagBlock")]
		public virtual string MetaTagBlock => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetMetaTagBlock(this, _publishedValueFallback);

		///<summary>
		/// Description: A brief description of the content, usually between 2 and 4 sentences. This will displayed below the title of the post on Facebook.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("OGDescription")]
		public virtual string Ogdescription => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetOgdescription(this, _publishedValueFallback);

		///<summary>
		/// Image: The URL of the image that appears when someone shares the content to Facebook.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("OGImage")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops Ogimage => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetOgimage(this, _publishedValueFallback);

		///<summary>
		/// Locale: The locale of the resource. Defaults to en_US.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("OGLocale")]
		public virtual string Oglocale => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetOglocale(this, _publishedValueFallback);

		///<summary>
		/// Title: The title of your article without any branding such as your site name.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("OGTitle")]
		public virtual string Ogtitle => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetOgtitle(this, _publishedValueFallback);

		///<summary>
		/// Type: The type of media of your content. This tag impacts how your content shows up in News Feed. If you don't specify a type,the default is website. Each URL should be a single object, so multiple og:type values are not possible.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("OGType")]
		public virtual string Ogtype => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetOgtype(this, _publishedValueFallback);

		///<summary>
		/// URL: The canonical URL for your page. This should be the undecorated URL, without session variables, user identifying parameters, or counters. Likes and Shares for this URL will aggregate at this URL. For example, mobile domain URLs should point to the desktop version of the URL as the canonical URL to aggregate Likes and Shares across different versions of the page.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("OGURL")]
		public virtual string Ogurl => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetOgurl(this, _publishedValueFallback);

		///<summary>
		/// Page Title: The title of the page, this is also the first text in a google search result.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("pageTitle2")]
		public virtual string PageTitle2 => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetPageTitle2(this, _publishedValueFallback);

		///<summary>
		/// Search Engine Change Frequency: How often will the content of this page change?
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("searchEngineChangeFrequency")]
		public virtual string SearchEngineChangeFrequency => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetSearchEngineChangeFrequency(this, _publishedValueFallback);

		///<summary>
		/// Search Engine Relative Priority: Indicate the relative priority of this page compared to the rest of the site
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("searchEngineRelativePriority")]
		public virtual decimal SearchEngineRelativePriority => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetSearchEngineRelativePriority(this, _publishedValueFallback);

		///<summary>
		/// Card Type: Select the twitter card type you need to use.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("TwitterCardType")]
		public virtual string TwitterCardType => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetTwitterCardType(this, _publishedValueFallback);

		///<summary>
		/// Description: A description that concisely summarizes the content as appropriate for presentation within a Tweet. You should not re-use the title as the description or use this field to describe the general services provided by the website.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("TwitterDescription")]
		public virtual string TwitterDescription => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetTwitterDescription(this, _publishedValueFallback);

		///<summary>
		/// Image: A URL to a unique image representing the content of the page. You should not use a generic image such as your website logo, author photo, or other image that spans multiple pages. Images for this Card support an aspect ratio of 2:1 with minimum dimensions of 300x157 or maximum of 4096x4096 pixels. Images must be less than 5MB in size. JPG, PNG, WEBP and GIF formats are supported. Only the first frame of an animated GIF will be used. SVG is not supported.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("TwitterImage")]
		public virtual global::Umbraco.Cms.Core.Models.MediaWithCrops TwitterImage => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetTwitterImage(this, _publishedValueFallback);

		///<summary>
		/// Image Alt: A text description of the image conveying the essential nature of an image to users who are visually impaired. Maximum 420 characters.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("TwitterImageAlt")]
		public virtual string TwitterImageAlt => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetTwitterImageAlt(this, _publishedValueFallback);

		///<summary>
		/// Site: The Twitter @username the card should be attributed to.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("TwitterSite")]
		public virtual string TwitterSite => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetTwitterSite(this, _publishedValueFallback);

		///<summary>
		/// Title: A concise title for the related content.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("TwitterTitle")]
		public virtual string TwitterTitle => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetTwitterTitle(this, _publishedValueFallback);

		///<summary>
		/// Hide From Navigation: Hide From Navigation Main Menu
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("umbracoNaviHide77")]
		public virtual bool UmbracoNaviHide77 => global::Umbraco.Cms.Web.Common.PublishedModels.PageSeo.GetUmbracoNaviHide77(this, _publishedValueFallback);
	}
}
