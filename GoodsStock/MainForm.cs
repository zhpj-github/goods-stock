using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GoodsStock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MenuItem库存查询_Click(object sender, EventArgs e) {
            if (ShowChildrenForm("GoodsStock")) {
                return;
            }
            FormGoodsStock goodsStock = new FormGoodsStock {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            goodsStock.Show();
        }

        private void MenuItem商品清单_Click(object sender, EventArgs e) {
            if (ShowChildrenForm("GoodsList")) {
                return;
            }
            FormGoodsList goodsList = new FormGoodsList() {
                MdiParent = this,
                WindowState= FormWindowState.Maximized
            };
            goodsList.Show();
        }

        private void MenuItem规格型号_Click(object sender, EventArgs e) {
            if (ShowChildrenForm("GoodsType")) {
                return;
            }
            FormGoodsType goodsType = new FormGoodsType() {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            goodsType.Show();
        }

        private void MenuItem盘点单查询_Click(object sender, EventArgs e) {
            if (ShowChildrenForm("CheckBillList")) {
                return;
            }
            FormCheckBillList checkBillList = new FormCheckBillList() {
                MdiParent = this,
                WindowState = FormWindowState.Maximized
            };
            checkBillList.Show();
        }


        private void MenuItem层叠_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void MenuItem横向平铺_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void MenuItem纵向平铺_Click(object sender, EventArgs e) {
            this.LayoutMdi(MdiLayout.TileVertical);
        }
        private bool ShowChildrenForm(string p_ChildrenFormText) {
            //依次检测当前窗体的子窗体
            for (int i = 0; i < this.MdiChildren.Length; i++) {
                //判断当前子窗体的Text属性值是否与传入的字符串值相同
                if (this.MdiChildren[i].Name == p_ChildrenFormText) {
                    //如果值相同则表示此子窗体为想要调用的子窗体，激活此子窗体并返回true值
                    this.MdiChildren[i].Activate();
                    return true;
                }
            }
            //如果没有相同的值则表示要调用的子窗体还没有被打开，返回false值
            return false;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            menuItem库存查询.PerformClick();
        }
    }
}
