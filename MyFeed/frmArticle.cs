using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpiderUtils;
using System.Xml;
using MyFeed.Entity;

namespace MyFeed
{
    public partial class frmArticle : Form
    {
        public frmArticle()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        { 
            //string url = "http://successfulenglish.com/2009/10/how-hard-do-you-have-to-work/";
            //var art = util.GetArticle(url); 
        }

        void Save()
        {
            SuccessfulUtil util = new SuccessfulUtil();
            var hrefs = SqliteHelper.Select<Hrefs>();
            foreach (var entity in hrefs)
            {
                var art = util.GetArticleByUrl(entity.ArticleHref);
                SqliteHelper.Insert(art);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var entity = SqliteHelper.GetAArticle();
            this.txtTitle.Text = entity.Title;
            txtHref.Text = entity.Href;
            string content = entity.Content + entity.Note;
            this.rxtContent.Text = content;
            Clipboard.SetDataObject(content);
        }
    }
}

