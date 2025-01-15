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
	// Mixin Content Type with alias "pageProperties"
	/// <summary>Page Properties</summary>
	public partial interface IPageProperties : IPublishedContent
	{
		/// <summary>CssClass</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		string CssClass { get; }

		/// <summary>Redirect URL</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		global::Umbraco.Cms.Core.Models.Link RedirectUrl { get; }

		/// <summary>Show breadcrumb</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		bool ShowBreadcrumb { get; }

		/// <summary>Show Coming Soon</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		bool ShowComingSoon { get; }

		/// <summary>Show in main menu</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		bool ShowInMainMenu { get; }

		/// <summary>Show in site map</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		bool ShowInSiteMap { get; }

		/// <summary>Show Page Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		bool ShowPageTitle { get; }

		/// <summary>Show sharing icons</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		bool ShowSharingIcons { get; }
	}

	/// <summary>Page Properties</summary>
	[PublishedModel("pageProperties")]
	public partial class PageProperties : PublishedContentModel, IPageProperties
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public new const string ModelTypeAlias = "pageProperties";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<PageProperties, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public PageProperties(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
			: base(content, publishedValueFallback)
		{
			_publishedValueFallback = publishedValueFallback;
		}

		// properties

		///<summary>
		/// CssClass
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("cssClass")]
		public virtual string CssClass => GetCssClass(this, _publishedValueFallback);

		/// <summary>Static getter for CssClass</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static string GetCssClass(IPageProperties that, IPublishedValueFallback publishedValueFallback) => that.Value<string>(publishedValueFallback, "cssClass");

		///<summary>
		/// Redirect URL
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[global::System.Diagnostics.CodeAnalysis.MaybeNull]
		[ImplementPropertyType("redirectURL")]
		public virtual global::Umbraco.Cms.Core.Models.Link RedirectUrl => GetRedirectUrl(this, _publishedValueFallback);

		/// <summary>Static getter for Redirect URL</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static global::Umbraco.Cms.Core.Models.Link GetRedirectUrl(IPageProperties that, IPublishedValueFallback publishedValueFallback) => that.Value<global::Umbraco.Cms.Core.Models.Link>(publishedValueFallback, "redirectURL");

		///<summary>
		/// Show breadcrumb
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showBreadcrumb")]
		public virtual bool ShowBreadcrumb => GetShowBreadcrumb(this, _publishedValueFallback);

		/// <summary>Static getter for Show breadcrumb</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public static bool GetShowBreadcrumb(IPageProperties that, IPublishedValueFallback publishedValueFallback) => that.Value<bool>(publishedValueFallback, "showBreadcrumb");

		///<summary>
		/// Show Coming Soon
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showComingSoon")]
		public virtual bool ShowComingSoon => GetShowComingSoon(this, _publishedValueFallback);

		/// <summary>Static getter for Show Coming Soon</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public static bool GetShowComingSoon(IPageProperties that, IPublishedValueFallback publishedValueFallback) => that.Value<bool>(publishedValueFallback, "showComingSoon");

		///<summary>
		/// Show in main menu
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showInMainMenu")]
		public virtual bool ShowInMainMenu => GetShowInMainMenu(this, _publishedValueFallback);

		/// <summary>Static getter for Show in main menu</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public static bool GetShowInMainMenu(IPageProperties that, IPublishedValueFallback publishedValueFallback) => that.Value<bool>(publishedValueFallback, "showInMainMenu");

		///<summary>
		/// Show in site map
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showInSiteMap")]
		public virtual bool ShowInSiteMap => GetShowInSiteMap(this, _publishedValueFallback);

		/// <summary>Static getter for Show in site map</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public static bool GetShowInSiteMap(IPageProperties that, IPublishedValueFallback publishedValueFallback) => that.Value<bool>(publishedValueFallback, "showInSiteMap");

		///<summary>
		/// Show Page Title
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showPageTitle")]
		public virtual bool ShowPageTitle => GetShowPageTitle(this, _publishedValueFallback);

		/// <summary>Static getter for Show Page Title</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public static bool GetShowPageTitle(IPageProperties that, IPublishedValueFallback publishedValueFallback) => that.Value<bool>(publishedValueFallback, "showPageTitle");

		///<summary>
		/// Show sharing icons
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[ImplementPropertyType("showSharingIcons")]
		public virtual bool ShowSharingIcons => GetShowSharingIcons(this, _publishedValueFallback);

		/// <summary>Static getter for Show sharing icons</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public static bool GetShowSharingIcons(IPageProperties that, IPublishedValueFallback publishedValueFallback) => that.Value<bool>(publishedValueFallback, "showSharingIcons");
	}
}
