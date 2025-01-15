using NetCore.Models;
using Umbraco.Cms.Core.Models.Blocks;
using Umbraco.Cms.Core.Models.PublishedContent;
using Umbraco.Cms.Web.Common.PublishedModels;
using Umbraco.Cms.Web.Common;

namespace Custom.ViewModel
{
    public class BlockGridViewModel<T>
    {
        public BlockGridViewModel(BlockGridItem Model, UmbracoHelper Umbraco, string ModelTypeAlias, IQueryCollection query)
        {
            try
            {
                Pager = new Pager();

                #region query string

                if (query != null)
                {
                    Pager.Keyword = query["Keyword"].ToStringNull();

                    var rpage = query["Page"].ToStringNull().ToInt32();
                    Pager.Page = rpage == 0 ? 1 : rpage;
                }

                #endregion

                if (Model != null)
                {
                    #region widget paramters
                    
                    var maxRecords = 0;
                    var pageSize = 9;
                    var paths = new List<int>();

                    try
                    {
                        Pager.PagerName = ModelTypeAlias;

                        maxRecords = Model.Content.Value("maxRecords").ToInt32_Count();
                        pageSize = Model.Content.Value("pageSize").ToInt32_Count2();
                        paths = Model.Content.Value("listPaths").ToListIntger();

                        Pager.MaxRecords = maxRecords;
                        Pager.PageSize = pageSize;
                        Pager.Paths = paths;

                        Pager.PageUdi = Model?.ContentUdi?.ToStringNull();
                        
                        Title = Model.Content.Value("Title").ToStringNull();
                        Details = Model.Content.Value("Details").ToStringNull();
                        URL = Model.Content.Value("URL").ToLinkURL("");
                        URL_Title = Model.Content.Value("URL").ToLinkTitle("");
                        LayoutName = Model.Content.Value("LayoutName").ToStringNull();
                        HideWidget = Model.Content.Value("HideWidget").ToBoolean();
                    }
                    catch (Exception ex)
                    {
                        SharedHelper.LogException(ex);
                    }

                    #endregion

                    #region get list

                    List = new List<T>();

                    if (!string.IsNullOrEmpty(ModelTypeAlias) && paths?.Count > 0)
                    {
                        foreach (var item in paths)
                        {
                            try
                            {
                                var items = Umbraco.Content(item)?
                                                                    .ChildrenOfType(ModelTypeAlias)?
                                                                    .Where(x => x.IsVisible())
                                                                    .OrderBy(p => p.Value<int>("Order"))
                                                                    ;

                                if (items?.Count() > 0)
                                {
                                    foreach (var item2 in items)
                                    {
                                        List.Add((T)item2);
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                SharedHelper.LogException(ex);
                            }
                        } 
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }
        }
        public void SetPager()
        {
            try
            {
                if (List != null)
                {
                    if (Pager.PageSize > 0)
                    {
                        var totalPages = (int)Math.Ceiling((double)(List?.Count() ?? 0) / (double)Pager.PageSize);

                        if (Pager.Page > totalPages)
                        {
                            Pager.Page = totalPages;
                        }
                        else if (Pager.Page < 1)
                        {
                            Pager.Page = 1;
                        }

                        Pager.TotalPages = totalPages;

                        List = List?.Skip((Pager.Page - 1) * Pager.PageSize).Take(Pager.PageSize).ToList();
                    }

                    if (Pager.MaxRecords > 0)
                    {
                        List = List?.Take(Pager.MaxRecords).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }
        }
        public void GetChildren(UmbracoHelper Umbraco, IPublishedValueFallback PublishedValueFallback)
        {
            try
            {
                #region get list

                foreach (var item in Pager.Paths)
                {
                    try
                    {
                        List<string> types =
                        [
                            Dt_PageContent.ModelTypeAlias,
                            Dt_Folder.ModelTypeAlias,
                            Dt_News.ModelTypeAlias,
                            Dt_NewsItem.ModelTypeAlias,
                            Dt_Services.ModelTypeAlias,
                            Dt_ServicesItem.ModelTypeAlias,
                        ];

                        #region MyRegion

                        string keyword = Pager.Keyword.ToLower();

                        var items = Umbraco.Content(item)?.Children()
                                    .Where(x => x.IsVisible(PublishedValueFallback)
                                    && types.Contains(x.ContentType.Alias)
                                    )
                                    .ToArray();

                        if (items?.Count() > 0)
                        {
                            GetChildrenDetails(items, types, keyword, PublishedValueFallback);
                        }

                        #endregion

                        if (items_All?.Count() > 0)
                        {
                            IEnumerable<IPublishedContent> result = items_All
                                .Where(x => WhereCustom(x, keyword))
                                .OrderByDescending(x => Fitness(x.Name, keyword))
                                ;

                            if (items_All?.Count() > 0)
                            {
                                List.AddRange((IEnumerable<T>)result);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        SharedHelper.LogException(ex);
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }
        }
        private void GetChildrenDetails(IPublishedContent[] items, List<string> types, string keyword, IPublishedValueFallback PublishedValueFallback)
        {
            try
            {
                if (items?.Count() > 0)
                {
                    if (items_All == null)
                    {
                        items_All = new List<IPublishedContent>();
                    }

                    foreach (var level1 in items)
                    {
                        items_All.Add(level1);

                        var children = level1.Children
                                        .Where(x => x.IsVisible(PublishedValueFallback)
                                        && types.Contains(x.ContentType.Alias)
                                        )
                                        .ToArray();

                        if (children.Length > 0)
                        {
                            GetChildrenDetails(children, types, keyword, PublishedValueFallback);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }
        }
        static bool WhereCustom(IPublishedContent x, string keyword)
        {
            try
            {
                return
                        x.Name.ToLower().StartsWith(keyword, StringComparison.InvariantCultureIgnoreCase)
                    || x.Name.ToLower().Contains(keyword, StringComparison.InvariantCultureIgnoreCase)
                    || x.Name.ToLower().Equals(keyword, StringComparison.InvariantCultureIgnoreCase)
                    || x.ValueOrDefault("pageTitle", defaultValue: "mxmxmx").Contains(keyword, StringComparison.InvariantCultureIgnoreCase)
                    || x.ValueOrDefault("details", defaultValue: "mxmxmx").Contains(keyword, StringComparison.InvariantCultureIgnoreCase);

            }
            catch (Exception ex)
            {
                SharedHelper.LogException(ex);
            }
            return false;
        }
        static int Fitness(string individual, string target)
        {
            try
            {
                return Enumerable.Range(0, Math.Min(individual.Length, target.Length))
                             .Count(i => individual[i] == target[i]);
            }
            catch (Exception ex)
            {

            }
            return 0;
        }
        public List<IPublishedContent> items_All { get; set; }
        public List<T> List { get; set; }
        public Pager Pager { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string URL { get; set; }
        public string URL_Title { get; set; }
        public string LayoutName { get; set; }
        public bool HideWidget { get; set; }
    }
}
