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
    public partial class FormGoodsStock : Form
    {
        DatabaseService service = new DatabaseService();
        public FormGoodsStock() {
            InitializeComponent();
        }

        private void ButtonRefresh_Click(object sender, EventArgs e) {
            RefreshData();
        }

        private void RefreshData() {
            DataTable dt = service.GetGoodsStock();
            this.dataGridView1.DataSource = dt;
            CommonHelper.SetHideIdColumnByDataTable(this.dataGridView1, dt);
        }

        private void GoodsStock_Load(object sender, EventArgs e) {
            RefreshData();
        }
    }
}
