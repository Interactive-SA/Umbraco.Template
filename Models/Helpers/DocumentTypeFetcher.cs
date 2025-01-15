using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common;

public class DocumentTypeFetcher
{
    private readonly UmbracoHelper _umbracoHelper;

    public DocumentTypeFetcher(UmbracoHelper umbracoHelper)
    {
        _umbracoHelper = umbracoHelper;
    }

    public IEnumerable<IPublishedContent> GetContentByAlias(string alias)
    {
        var rootContent = _umbracoHelper.ContentAtRoot(); // Get all root content
        var matchedContent = new List<IPublishedContent>();

        foreach (var content in rootContent)
        {
            matchedContent.AddRange(FindContentByAlias(content, alias));
        }

        return matchedContent;
    }

    private IEnumerable<IPublishedContent> FindContentByAlias(IPublishedContent content, string alias)
    {
        var matchedItems = new List<IPublishedContent>();

        // Check if the current content matches the alias
        if (content.ContentType.Alias.Equals(alias, StringComparison.OrdinalIgnoreCase))
        {
            matchedItems.Add(content);
        }

        // Recursively check the children
        if (content.Children != null && content.Children.Any())
        {
            foreach (var child in content.Children)
            {
                matchedItems.AddRange(FindContentByAlias(child, alias));
            }
        }

        return matchedItems;
    }
}