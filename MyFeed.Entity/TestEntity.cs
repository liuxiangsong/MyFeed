using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFeed.Entity
{
    public class TestEntity
    {
        //public TestEntity(Int64 id, string title, string content, DateTime createDate)
        //{
        //    this.Id = id;
        //    this.Title = title;
        //    this.Content = content;
        //    this.CreateDate = createDate;
        //} 
        public Int64 Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime? CreateDate { get; set; }
    }
}
