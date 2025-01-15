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
	/// <summary>Lookup</summary>
	[PublishedModel("DT_Lookup")]
	public partial class Dt_Lookup : PublishedContentModel, IPageProperties
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public new const string ModelTypeAlias = "DT_Lookup";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public new static IPublishedContentType GetModelContentType(IPublishedSnapshotAccessor publishedSnapshotAccessor)
			=> PublishedModelUtility.GetModelContentType(publishedSnapshotAccessor, ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder.Embedded", "13.2.0+7dff3a3")]
		[return: global::System.Diagnostics.CodeAnalysis.MaybeNull]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(IPublishedSnapshotAccessor publishedSnapshotAccessor, Expression<Func<Dt_Lookup, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(publishedSnapshotAccessor), selector);
#pragma warning restore 0109

		private IPublishedValueFallback _publishedValueFallback;

		// ctor
		public Dt_Lookup(IPublishedContent content, IPublishedValueFallback publishedValueFallback)
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
	}
}
