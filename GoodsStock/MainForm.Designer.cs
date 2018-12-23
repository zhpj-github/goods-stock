namespace GoodsStock
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.基本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem商品清单 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem规格型号 = new System.Windows.Forms.ToolStripMenuItem();
            this.报表查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem库存查询 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem盘点单查询 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem层叠 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem横向平铺 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem纵向平铺 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基本信息ToolStripMenuItem,
            this.报表查询ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.关于ToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 基本信息ToolStripMenuItem
            // 
            this.基本信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem商品清单,
            this.menuItem规格型号});
            this.基本信息ToolStripMenuItem.Name = "基本信息ToolStripMenuItem";
            this.基本信息ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.基本信息ToolStripMenuItem.Text = "基本信息";
            // 
            // menuItem商品清单
            // 
            this.menuItem商品清单.Name = "menuItem商品清单";
            this.menuItem商品清单.Size = new System.Drawing.Size(124, 22);
            this.menuItem商品清单.Text = "商品清单";
            this.menuItem商品清单.Click += new System.EventHandler(this.MenuItem商品清单_Click);
            // 
            // menuItem规格型号
            // 
            this.menuItem规格型号.Name = "menuItem规格型号";
            this.menuItem规格型号.Size = new System.Drawing.Size(124, 22);
            this.menuItem规格型号.Text = "规格型号";
            this.menuItem规格型号.Click += new System.EventHandler(this.MenuItem规格型号_Click);
            // 
            // 报表查询ToolStripMenuItem
            // 
            this.报表查询ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem库存查询,
            this.menuItem盘点单查询});
            this.报表查询ToolStripMenuItem.Name = "报表查询ToolStripMenuItem";
            this.报表查询ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.报表查询ToolStripMenuItem.Text = "报表查询";
            // 
            // menuItem库存查询
            // 
            this.menuItem库存查询.Name = "menuItem库存查询";
            this.menuItem库存查询.Size = new System.Drawing.Size(136, 22);
            this.menuItem库存查询.Text = "库存查询";
            this.menuItem库存查询.Click += new System.EventHandler(this.MenuItem库存查询_Click);
            // 
            // menuItem盘点单查询
            // 
            this.menuItem盘点单查询.Name = "menuItem盘点单查询";
            this.menuItem盘点单查询.Size = new System.Drawing.Size(136, 22);
            this.menuItem盘点单查询.Text = "盘点单查询";
            this.menuItem盘点单查询.Click += new System.EventHandler(this.MenuItem盘点单查询_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem层叠,
            this.menuItem横向平铺,
            this.menuItem纵向平铺});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "窗口";
            // 
            // menuItem层叠
            // 
            this.menuItem层叠.Name = "menuItem层叠";
            this.menuItem层叠.Size = new System.Drawing.Size(180, 22);
            this.menuItem层叠.Text = "层叠";
            this.menuItem层叠.Click += new System.EventHandler(this.MenuItem层叠_Click);
            // 
            // menuItem横向平铺
            // 
            this.menuItem横向平铺.Name = "menuItem横向平铺";
            this.menuItem横向平铺.Size = new System.Drawing.Size(180, 22);
            this.menuItem横向平铺.Text = "水平平铺";
            this.menuItem横向平铺.Click += new System.EventHandler(this.MenuItem横向平铺_Click);
            // 
            // menuItem纵向平铺
            // 
            this.menuItem纵向平铺.Name = "menuItem纵向平铺";
            this.menuItem纵向平铺.Size = new System.Drawing.Size(180, 22);
            this.menuItem纵向平铺.Text = "垂直平铺";
            this.menuItem纵向平铺.Click += new System.EventHandler(this.MenuItem纵向平铺_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 419);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(800, 31);
            this.panel3.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "库存管理";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 基本信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 报表查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem库存查询;
        private System.Windows.Forms.ToolStripMenuItem menuItem盘点单查询;
        private System.Windows.Forms.ToolStripMenuItem menuItem商品清单;
        private System.Windows.Forms.ToolStripMenuItem menuItem规格型号;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuItem层叠;
        private System.Windows.Forms.ToolStripMenuItem menuItem横向平铺;
        private System.Windows.Forms.ToolStripMenuItem menuItem纵向平铺;
    }
}

