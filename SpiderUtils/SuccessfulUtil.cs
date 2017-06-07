using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using MyFeed.Entity;

namespace SpiderUtils
{
    /// <summary>
    /// SuccessfulEnglish
    /// </summary>
    public class SuccessfulUtil
    {
        /// <summary>
        /// 判断页面是否存在
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        private bool ExistsPage(string pageUrl)
        {
            HtmlNode rootNode = Common.GetRootNode(pageUrl);
            string title = rootNode.SelectSingleNode("//title").InnerText.ToLower();
            return !title.Contains("page not found");
        }

        private int GetPageCount()
        {
            string url;
            string pageUrlFormatString = "http://successfulenglish.com/learn/successful-english-blog/page/{0}/";
            for (int i = 7; i < 15; i++)
            {
                url = string.Format(pageUrlFormatString, i);
                if (!ExistsPage(url))
                    return i - 1;
            }
            return 0;
        }

        /// <summary>
        /// 取得指定页面中的文章链接
        /// </summary>
        /// <param name="pageUrl"></param>
        /// <returns></returns>
        private List<string> GetPageUrlList(string pageUrl)
        {
            List<string> urlList = new List<string>();
            HtmlNode rootNode = Common.GetRootNode(pageUrl);
            var aNodes = rootNode.QuerySelectorAll(".entry-title a");
            foreach (var node in aNodes)
            {
                string url = node.Attributes["href"].Value;
                urlList.Add(url);
            }
            return urlList;
        }

        /// <summary>
        /// 取得所有的文章链接
        /// </summary>
        /// <returns></returns>
        private List<string> GetArticlesUrl()
        {
            List<string> urlList = new List<string>();
            string pageUrlFormatString = "http://successfulenglish.com/learn/successful-english-blog/page/{0}/";
            string pageUrl;
            for (int index = 1; index < 8; index++)
            {
                pageUrl = string.Format(pageUrlFormatString, index);
                urlList.AddRange(GetPageUrlList(pageUrl));
            }
            return urlList;
        }


        public Article GetArticleByUrl(string articleUrl)
        {
            Article entity = new Article()
            {
                Href = articleUrl,
                CategoryA = "Successful English",
                CategoryB = "Blog",
                Note ="<p style=\"text-align: left;\">~ Warren Ediger – ESL coach/tutor and creator of the <a href=\"http://successfulenglish.com\">Successful English</a> website.</p>"
            };

            HtmlNode rootNode = Common.GetRootNode(articleUrl);
            HtmlNode contentNode = rootNode.QuerySelector(".entry-content div.pf-content"); 
            if (contentNode != null)
            {
                contentNode.RemoveChild(contentNode.QuerySelector(".printfriendly"));
                entity.Content = contentNode.OuterHtml;
            }
            HtmlNode titleNode = rootNode.QuerySelector(".entry-title");
            
            if (titleNode != null)
            {
                entity.Title = titleNode.InnerText;
            }
            return entity;
        }

        public List<Article> GetArticles()
        {
            List<string> articleUrlList = GetArticlesUrl();

            return null;
        }

        public List<Hrefs> GetHrefListFromURL()
        {
            List<Hrefs> list = new List<Hrefs>();
            string pageUrlFormatString = "http://successfulenglish.com/learn/successful-english-blog/page/{0}/";
            string pageUrl;
            for (int index = 1; index < 8; index++)
            {
                pageUrl = string.Format(pageUrlFormatString, index);

                HtmlNode rootNode = Common.GetRootNode(pageUrl);
                var aNodes = rootNode.QuerySelectorAll(".entry-title a");
                foreach (var node in aNodes)
                {
                    Hrefs entity = new Hrefs()
                    {
                        PageHref = pageUrl,
                        CategoryA = "Successful English",
                        CategoryB = "Blog"
                    };
                    entity.ArticleHref = node.Attributes["href"].Value;
                    list.Add(entity);
                }
            }
            return list;
        }


    }
}
