namespace MyFeed
{
    partial class frmGetShare
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.btnLoadNodes = new System.Windows.Forms.Button();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.btnLoadRootNodes = new System.Windows.Forms.Button();
            this.dgvMain = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtAuth = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDonwLoadAll = new System.Windows.Forms.Button();
            this.btnDownLoadSingle = new System.Windows.Forms.Button();
            this.txtSaveFileDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtColumnName = new System.Windows.Forms.TextBox();
            this.chkIsDonwLoad = new System.Windows.Forms.CheckBox();
            this.btnSelected = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(-1, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(342, 628);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // btnLoadNodes
            // 
            this.btnLoadNodes.Location = new System.Drawing.Point(9, 71);
            this.btnLoadNodes.Name = "btnLoadNodes";
            this.btnLoadNodes.Size = new System.Drawing.Size(107, 23);
            this.btnLoadNodes.TabIndex = 1;
            this.btnLoadNodes.Text = "加载全部子节点";
            this.btnLoadNodes.UseVisualStyleBackColor = true;
            this.btnLoadNodes.Click += new System.EventHandler(this.btnLoadNodes_Click);
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point(9, 100);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(107, 23);
            this.btnDownLoad.TabIndex = 2;
            this.btnDownLoad.Text = "下载图片";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // btnLoadRootNodes
            // 
            this.btnLoadRootNodes.Location = new System.Drawing.Point(9, 42);
            this.btnLoadRootNodes.Name = "btnLoadRootNodes";
            this.btnLoadRootNodes.Size = new System.Drawing.Size(107, 23);
            this.btnLoadRootNodes.TabIndex = 3;
            this.btnLoadRootNodes.Text = "加载根节点";
            this.btnLoadRootNodes.UseVisualStyleBackColor = true;
            this.btnLoadRootNodes.Click += new System.EventHandler(this.btnLoadRootNodes_Click);
            // 
            // dgvMain
            // 
            this.dgvMain.AllowUserToAddRows = false;
            this.dgvMain.AllowUserToDeleteRows = false;
            this.dgvMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMain.Location = new System.Drawing.Point(472, 69);
            this.dgvMain.MultiSelect = false;
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMain.Size = new System.Drawing.Size(774, 559);
            this.dgvMain.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtAuth);
            this.panel1.Controls.Add(this.btnLoadRootNodes);
            this.panel1.Controls.Add(this.btnLoadNodes);
            this.panel1.Controls.Add(this.btnDownLoad);
            this.panel1.Location = new System.Drawing.Point(344, 149);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 135);
            this.panel1.TabIndex = 5;
            // 
            // txtAuth
            // 
            this.txtAuth.Location = new System.Drawing.Point(9, 15);
            this.txtAuth.Name = "txtAuth";
            this.txtAuth.Size = new System.Drawing.Size(100, 21);
            this.txtAuth.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDonwLoadAll);
            this.panel2.Controls.Add(this.btnDownLoadSingle);
            this.panel2.Location = new System.Drawing.Point(344, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(125, 100);
            this.panel2.TabIndex = 6;
            // 
            // btnDonwLoadAll
            // 
            this.btnDonwLoadAll.Location = new System.Drawing.Point(10, 56);
            this.btnDonwLoadAll.Name = "btnDonwLoadAll";
            this.btnDonwLoadAll.Size = new System.Drawing.Size(75, 23);
            this.btnDonwLoadAll.TabIndex = 0;
            this.btnDonwLoadAll.Text = "下载所有行";
            this.btnDonwLoadAll.UseVisualStyleBackColor = true;
            this.btnDonwLoadAll.Click += new System.EventHandler(this.btnDonwLoadAll_Click);
            // 
            // btnDownLoadSingle
            // 
            this.btnDownLoadSingle.Location = new System.Drawing.Point(10, 17);
            this.btnDownLoadSingle.Name = "btnDownLoadSingle";
            this.btnDownLoadSingle.Size = new System.Drawing.Size(75, 23);
            this.btnDownLoadSingle.TabIndex = 0;
            this.btnDownLoadSingle.Text = "下载选中行";
            this.btnDownLoadSingle.UseVisualStyleBackColor = true;
            this.btnDownLoadSingle.Click += new System.EventHandler(this.btnDownLoadSingle_Click);
            // 
            // txtSaveFileDir
            // 
            this.txtSaveFileDir.Location = new System.Drawing.Point(558, 3);
            this.txtSaveFileDir.Name = "txtSaveFileDir";
            this.txtSaveFileDir.Size = new System.Drawing.Size(676, 21);
            this.txtSaveFileDir.TabIndex = 7;
            this.txtSaveFileDir.DoubleClick += new System.EventHandler(this.txtSaveFileDir_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(475, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "文件保存目录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(497, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 8;
            this.label2.Text = "ColumnName";
            // 
            // txtColumnName
            // 
            this.txtColumnName.Location = new System.Drawing.Point(568, 38);
            this.txtColumnName.Name = "txtColumnName";
            this.txtColumnName.Size = new System.Drawing.Size(100, 21);
            this.txtColumnName.TabIndex = 9;
            // 
            // chkIsDonwLoad
            // 
            this.chkIsDonwLoad.AutoSize = true;
            this.chkIsDonwLoad.Checked = true;
            this.chkIsDonwLoad.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkIsDonwLoad.Location = new System.Drawing.Point(696, 42);
            this.chkIsDonwLoad.Name = "chkIsDonwLoad";
            this.chkIsDonwLoad.Size = new System.Drawing.Size(84, 16);
            this.chkIsDonwLoad.TabIndex = 10;
            this.chkIsDonwLoad.Text = "IsDonwLoad";
            this.chkIsDonwLoad.ThreeState = true;
            this.chkIsDonwLoad.UseVisualStyleBackColor = true;
            // 
            // btnSelected
            // 
            this.btnSelected.Location = new System.Drawing.Point(814, 40);
            this.btnSelected.Name = "btnSelected";
            this.btnSelected.Size = new System.Drawing.Size(75, 23);
            this.btnSelected.TabIndex = 11;
            this.btnSelected.Text = "查询";
            this.btnSelected.UseVisualStyleBackColor = true;
            this.btnSelected.Click += new System.EventHandler(this.btnSelected_Click);
            // 
            // frmGetShare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1246, 629);
            this.Controls.Add(this.btnSelected);
            this.Controls.Add(this.chkIsDonwLoad);
            this.Controls.Add(this.txtColumnName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSaveFileDir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgvMain);
            this.Controls.Add(this.treeView1);
            this.Name = "frmGetShare";
            this.Text = "frmGetShare";
            this.Load += new System.EventHandler(this.frmGetShare_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMain)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button btnLoadNodes;
        private System.Windows.Forms.Button btnDownLoad;
        private System.Windows.Forms.Button btnLoadRootNodes;
        private System.Windows.Forms.DataGridView dgvMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDownLoadSingle;
        private System.Windows.Forms.TextBox txtSaveFileDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAuth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtColumnName;
        private System.Windows.Forms.CheckBox chkIsDonwLoad;
        private System.Windows.Forms.Button btnSelected;
        private System.Windows.Forms.Button btnDonwLoadAll;
    }
}