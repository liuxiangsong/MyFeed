using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeed.Entity
{
   public class Subscription
    {
        public Int64? Id { get; set; }

        public string ColumnName { get; set; }

        public string ResourceName { get; set; } 
        public string RelativePath { get; set; }
        public string Category { get; set; } 
        public DateTime? CreateDate { get; set; } 
        public int IsDownLoad { get; set; }
        public int Flag { get; set; }
    }
}
