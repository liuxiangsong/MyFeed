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
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSaveFileDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.treeView1.Size = new System.Drawing.Size(342, 597);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseDoubleClick);
            // 
            // btnLoadNodes
            // 
            this.btnLoadNodes.Location = new System.Drawing.Point(9, 35);
            this.btnLoadNodes.Name = "btnLoadNodes";
            this.btnLoadNodes.Size = new System.Drawing.Size(107, 23);
            this.btnLoadNodes.TabIndex = 1;
            this.btnLoadNodes.Text = "加载全部子节点";
            this.btnLoadNodes.UseVisualStyleBackColor = true;
            this.btnLoadNodes.Click += new System.EventHandler(this.btnLoadNodes_Click);
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Location = new System.Drawing.Point(9, 64);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(107, 23);
            this.btnDownLoad.TabIndex = 2;
            this.btnDownLoad.Text = "下载图片";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // btnLoadRootNodes
            // 
            this.btnLoadRootNodes.Location = new System.Drawing.Point(9, 6);
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
            this.dgvMain.Location = new System.Drawing.Point(472, 30);
            this.dgvMain.Name = "dgvMain";
            this.dgvMain.ReadOnly = true;
            this.dgvMain.RowTemplate.Height = 23;
            this.dgvMain.Size = new System.Drawing.Size(436, 567);
            this.dgvMain.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLoadRootNodes);
            this.panel1.Controls.Add(this.btnLoadNodes);
            this.panel1.Controls.Add(this.btnDownLoad);
            this.panel1.Location = new System.Drawing.Point(344, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 100);
            this.panel1.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(344, 13);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(125, 100);
            this.panel2.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(10, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSaveFileDir
            // 
            this.txtSaveFileDir.Location = new System.Drawing.Point(539, 3);
            this.txtSaveFileDir.Name = "txtSaveFileDir";
            this.txtSaveFileDir.Size = new System.Drawing.Size(357, 21);
            this.txtSaveFileDir.TabIndex = 7; 
            this.txtSaveFileDir.DoubleClick += new System.EventHandler(this.txtSaveFileDir_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(492, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "目录";
            // 
            // frmGetShare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 598);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtSaveFileDir;
        private System.Windows.Forms.Label label1;
    }
}