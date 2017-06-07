using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeed.Entity
{
   public class Hrefs
    {
       public Int64? Id { get; set; }

       public string CategoryA { get; set; }
       public string CategoryB { get; set; }

       public string PageHref { get; set; }
       public string ArticleHref { get; set; }
       public int Flag { get; set; }
       public string Remark { get; set; }
       public DateTime? CreateDate { get; set; }
    }
}
