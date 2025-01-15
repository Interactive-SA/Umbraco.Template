using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.Routing;
using Umbraco.Cms.Core.Web;

namespace DGA;

public class Error404Page : IContentLastChanceFinder
{
    private readonly IUmbracoContextAccessor _contextAccessor;

    public Error404Page(IUmbracoContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public Task<bool> TryFindContent(IPublishedRequestBuilder request)
    {
        // In the rare case that an umbracoContext cannot be built from the request,
        // we will not be able to find the page
        if (_contextAccessor.TryGetUmbracoContext(out var umbracoContext) == false)
        {
            return Task.FromResult(false);
        }

        // Find the first notFound page at the root level through the published content cache by its documentTypeAlias
        // You can make this search as complex as you want, you can return different pages based on anything in the original request
        var notFoundPage = umbracoContext.Content?.GetAtRoot().FirstOrDefault(c => c.ContentType.Alias == "Page404");
        if (notFoundPage == null)
        {
            return Task.FromResult(false);
        }

        //Set the content on the request and mark our search as successful
        request.SetPublishedContent(notFoundPage);
        request.SetResponseStatus(404);
        return Task.FromResult(true);
    }
}

// ContentFinders need to be registered into the DI container through a composer
public class Mycomposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.SetContentLastChanceFinder<Error404Page>();
    }
}
