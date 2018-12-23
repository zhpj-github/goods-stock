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
    public partial class FormGoodsList : Form
    {
        public FormGoodsList() {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, EventArgs e) {
            DlgGoodsEdit dlg = new DlgGoodsEdit();
            if(dlg.ShowDialog()== DialogResult.OK) {
                RefreshData();
            }
        }

        private void RefreshData() {
            DataTable dt = (new DatabaseService()).GetGoods();
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
            DlgGoodsEdit dlg = new DlgGoodsEdit(row_view.Row);
            if (dlg.ShowDialog() == DialogResult.OK) {
                RefreshData();
            }
        }

        private void FormGoodsList_Load(object sender, EventArgs e) {
            RefreshData();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e) {
            RefreshData();
        }
    }
}
