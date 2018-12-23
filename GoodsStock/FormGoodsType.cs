using GoodsStock.DatabaseManager;
using GoodsStock.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoodsStock
{
    public partial class FormGoodsType : Form
    {
        public FormGoodsType() {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e) {
            DlgGoodsTypeEdit dlg = new DlgGoodsTypeEdit();
            if(dlg.ShowDialog()== DialogResult.OK) {
                RefreshData();
            }
        }

        private void RefreshData() {
            DataTable dt = (new DatabaseService()).GetGoodsType();
            this.dataGridView1.DataSource = dt;
            CommonHelper.SetHideIdColumnByDataTable(this.dataGridView1, dt);
            
        }

        private void ButtonEdit_Click(object sender, EventArgs e) {
            if (this.dataGridView1.SelectedRows.Count <= 0) {
                MessageBox.Show("请选择一行再操作");
                return;
            }
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            DataRowView row_view = (DataRowView)row.DataBoundItem;
            DlgGoodsTypeEdit dlg = new DlgGoodsTypeEdit(row_view.Row);
            if (dlg.ShowDialog() == DialogResult.OK) {
                RefreshData();
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e) {
            if (this.dataGridView1.SelectedRows.Count <= 0) {
                MessageBox.Show("请选择一行再操作");
                return;
            }
            if(MessageBox.Show("确定要删除吗？","提醒",MessageBoxButtons.OKCancel)!= DialogResult.OK) {
                return;
            }
            DataGridViewRow row = this.dataGridView1.SelectedRows[0];
            object id = row.Cells["id"].Value;
        }

        private void GoodsType_Load(object sender, EventArgs e) {
            RefreshData();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e) {
            RefreshData();
        }
    }
}
