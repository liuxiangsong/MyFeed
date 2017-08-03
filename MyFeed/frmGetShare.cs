using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyFeed.Entity;
using Newtonsoft.Json.Linq;
using SpiderUtils;

namespace MyFeed
{
    public partial class frmGetShare : Form
    {
        public frmGetShare()
        {
            InitializeComponent();
        }

        private void frmGetShare_Load(object sender, EventArgs e)
        {
            txtSaveFileDir.Text = Path.Combine(Application.StartupPath, "DownLoad");
            if (!Directory.Exists(txtSaveFileDir.Text))
            {
                Directory.CreateDirectory(txtSaveFileDir.Text);
            }
        }


        #region 树节点相关方法
        private void btnLoadRootNodes_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Add("订阅");
            AddNodesToTree(treeView1.TopNode, GetDir());
            treeView1.ExpandAll();
        }

        private JArray GetDir(string path = "chenwei")
        {
            string url = string.Format(
               @"https://device4119087-e7f931fd.wd2go.com:9444/api/2.7/rest/dir/{0}/?device_user_id=26360557&device_user_auth_code={1}&path=/{0}/&show_is_linked=true&include_dir_count=true&format=json&_=1494654426860 ",
              Uri.EscapeDataString(path.Trim('/')), txtAuth.Text);
            var jobj = HttpUtil.Get(url);
            if (jobj == null) return null;
            return jobj["dir"]["entry"].ToObject<JArray>();
        }

        private void AddNodesToTree(TreeNode rootNode, JArray datas)
        {
            if (datas == null) return;
            foreach (JToken jToken in datas)
            {
                var node = new TreeNode(jToken["name"] + "");
                node.Tag = jToken;
                rootNode.Nodes.Add(node);
            }
        }

        private void RecursionAddNodesToTree(TreeNode rootNode, JArray datas)
        {
            if (datas == null) return;
            foreach (JToken jToken in datas)
            {
                var node = new TreeNode(jToken["name"] + "");
                node.Tag = jToken;
                rootNode.Nodes.Add(node);

                string path = jToken["path"] + "/" + node.Text;
                if (Convert.ToBoolean(jToken["is_dir"]))
                {
                    RecursionAddNodesToTree(node, GetDir(path));
                }
                else
                {
                    string fileName = jToken["name"] + "";
                    if (Path.GetExtension(fileName) != ".mp3")
                    {
                        SaveToDB(path, fileName);
                    }
                }
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Nodes.Count > 0 || !(e.Node.Tag is JToken)) return;
            JToken tag = (JToken)e.Node.Tag;
            if (!Convert.ToBoolean(tag["is_dir"])) return; ;
            string path = tag["path"] + "/" + e.Node.Text;
            AddNodesToTree(e.Node, GetDir(path));
            e.Node.Expand();
        }

        private void btnLoadNodes_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView1.SelectedNode;
            if (selectedNode == null) return;
            if (selectedNode.Nodes.Count > 0 || !(selectedNode.Tag is JToken)) return;
            JToken tag = (JToken)selectedNode.Tag;
            if (!Convert.ToBoolean(tag["is_dir"])) return;
            string path = tag["path"] + "/" + selectedNode.Text;
            RecursionAddNodesToTree(selectedNode, GetDir(path));
            MessageBox.Show("加载完成");
        }

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            var selectedNode = treeView1.SelectedNode;
            if (!(selectedNode.Tag is JToken))
            {
                MessageBox.Show("该节点不是文件");
                return;
            };
            JToken tag = (JToken)selectedNode.Tag;
            if (Convert.ToBoolean(tag["is_dir"]))
            {
                MessageBox.Show("该节点不是文件");
                return;
            };
            string path = tag["path"] + "/" + selectedNode.Text;
            bool flag = DownLoadFile(path, "C://1", selectedNode.Text);
            //string url =
            //    @"https://device4119087-e7f931fd.wd2go.com:9444/api/2.7/rest/file_contents/chenwei/%E5%BE%97%E5%88%B0%E8%AE%A2%E9%98%85/Dr.%E9%AD%8F/3%E6%9C%88/3.16/Dr.%E9%AD%8F%E7%9A%84%E5%AE%B6%E5%BA%AD%E6%95%99%E8%82%B2%E5%AE%9D%E5%85%B8-03-16-%E6%83%85%E7%BB%AA%E8%84%91%EF%BD%9C%E5%9D%9A%E6%8C%81%E8%BF%99%E4%B8%89%E6%AD%A5%EF%BC%8C%E6%90%9E%E5%AE%9A%E5%8F%91%E8%84%BE%E6%B0%94%E7%9A%84%E5%A8%832.jpg?tn_type=i1024s1&device_user_id=26360557&device_user_auth_code=e2d16e0e31267e390a58152b8222dd70";
            //bool flag = HttpUtil.DownLoadFile(url, "C://1//2323.jpg");
            MessageBox.Show(flag ? "成功" : "失败");
        }
        #endregion

        private bool DownLoadFile(string relativePath, string saveFileDir, string fileName)
        {
            string url = string.Format(@"https://device4119087-e7f931fd.wd2go.com:9444/api/2.7/rest/file_contents/{0}?device_user_id=26360557&device_user_auth_code=e2d16e0e31267e390a58152b8222dd70 ",
             Uri.EscapeDataString(relativePath.Trim('/')));
            return HttpUtil.DownLoadFile(url, Path.Combine(saveFileDir, fileName));
        }

        #region 操作数据库

        private void SaveToDB(string relativePath, string resourceName)
        {
            string sql = string.Format("select * from Subscription where ResourceName='{0}'", resourceName);
            if (SqliteHelper.Exists(sql)) return;
            var entity = new Subscription
            {
                ColumnName = relativePath.Split('/')[3],
                RelativePath = relativePath,
                Category = "Get",
                ResourceName = resourceName
            };
            SqliteHelper.Insert(entity);
        }

        private void UpdateDownLoaded(string resourceName)
        {
            string sql = string.Format("update Subscription set IsDownLoad=1 where ResourceName='{0}'", resourceName);
            SqliteHelper.ExecuteNonQuery(sql);
        }

        private DataTable GetDataTable()
        {
            string sql = "select * from Subscription ";
            string order = " order by ColumnName,ResourceName";
            if (!string.IsNullOrEmpty(txtColumnName.Text.Trim()) && chkIsDonwLoad.CheckState != CheckState.Indeterminate)
            {
                sql = string.Format("{0} where ColumnName like '%{1}%' and IsDownLoad={2}", sql, txtColumnName.Text.Trim(), Convert.ToInt16(chkIsDonwLoad.Checked));
            }
            else if (!string.IsNullOrEmpty(txtColumnName.Text.Trim()))
            {
                sql = string.Format("{0} where ColumnName like '%{1}%' ", sql, txtColumnName.Text.Trim());
            }
            else if (chkIsDonwLoad.CheckState != CheckState.Indeterminate)
            {
                sql = string.Format("{0} where   IsDownLoad={1}", sql, Convert.ToInt16(chkIsDonwLoad.Checked));
            }
            sql = sql + order;
            var dataSet = SqliteHelper.ExcuteDataSet(sql);
            if (dataSet != null && dataSet.Tables.Count > 0)
                return dataSet.Tables[0];
            return null;
        }
        #endregion



        private void txtSaveFileDir_DoubleClick(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() != DialogResult.OK) return;
            txtSaveFileDir.Text = dialog.SelectedPath;
        }

        private void btnSelected_Click(object sender, EventArgs e)
        {
            dgvMain.DataSource = GetDataTable();
        }
        private void btnDownLoadSingle_Click(object sender, EventArgs e)
        {
            DownLoadFile(dgvMain.SelectedRows[0]);
        }

        private void DownLoadFile(DataGridViewRow row)
        {
            if(Convert.ToBoolean( row.Cells[6].Value))return;;
            Thread thread = new Thread((() =>
            {
                string relativePath = row.Cells[3].Value + "";
                string fileName = row.Cells[2].Value + ""; 
                UpdateDownLoaded(fileName);
                DownLoadFile(relativePath, txtSaveFileDir.Text, fileName);
            })) { IsBackground = true };
            thread.Start();
        }

        private void btnDonwLoadAll_Click(object sender, EventArgs e)
        {
            if (dgvMain.RowCount > 50)
            {
                var dialog = MessageBox.Show("一次最多下载50行，是否继续？", "提示", MessageBoxButtons.YesNo);
                if (dialog != DialogResult.Yes) return;
            }
            for (int i = 0; i < dgvMain.RowCount; i++)
            {
                if (i >= 50) return;
                DownLoadFile(dgvMain.Rows[i]);
            }
        }

        private void btnOpenDirectory_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(txtSaveFileDir.Text))
            {
                MessageBox.Show("文件保存目录文件夹不存在");
                return;
            }
            System.Diagnostics.Process.Start("Explorer.exe", txtSaveFileDir.Text);
        }
    }
}
