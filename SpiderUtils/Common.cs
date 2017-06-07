using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace SpiderUtils
{
  public static class Common
    {
      /// <summary>
      /// 取得页面根节点
      /// </summary>
      /// <param name="pageUrl"></param>
      /// <returns></returns>
      public static HtmlNode GetRootNode(string pageUrl)
      {
          HtmlWeb web = new HtmlWeb();
          HtmlDocument doc = web.Load(pageUrl);
          HtmlNode rootNode = doc.DocumentNode;
          return rootNode;
      }
    }
}
