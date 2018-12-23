using GoodsStock.DatabaseManager;
using GoodsStock.Helper;
using GoodsStock.Model;
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
    public partial class DlgCheckBillEdit : Form
    {
        private DataRow row;
        private CheckListBill checkListBill = new CheckListBill();
        public DlgCheckBillEdit() {
            InitializeComponent();
        }
        public DlgCheckBillEdit(DataRow row) : this() {
            this.row = row;
            checkListBill = CommonHelper.SetModelByDataRow<CheckListBill>(row);
        }
        
        private void TextBoxCode_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                SetGoodsStock(textBoxCode.Text.Trim());
                textBoxCode.Text = "";
                textBoxCode.Focus();
            }
        }

        private void SetGoodsStock(string code) {
            DataTable dt = this.dataGridView1.DataSource as DataTable;
            foreach (DataRow dr in dt.Rows) {
                if (string.Equals(code, dr["code"].ToString(), StringComparison.OrdinalIgnoreCase)) {
                    int.TryParse(dr["quantity"].ToString(), out int count);
                    count+=1;
                    dr["quantity"] = count;
                    break;
                }
            }
        }

        private void DlgCheckBillEdit_Load(object sender, EventArgs e) {
            this.dateTimePicker1.DataBindings.Add("Value", checkListBill, "Check_time");
            this.textBoxRemark.DataBindings.Add("Text", checkListBill, "Remark");
            if (row == null) {
                DataTable dt= (new DatabaseService()).GetInitCheckDetail();
                this.dataGridView1.DataSource = dt;
                CommonHelper.SetHideIdColumnByDataTable(this.dataGridView1, dt);
            } else {
                this.buttonSave.Visible = false;
                DataTable dt = (new DatabaseService()).GetCheckBillDetail(checkListBill.Id);
                this.dataGridView1.DataSource = dt;
                CommonHelper.SetHideIdColumnByDataTable(this.dataGridView1, dt);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e) {
            checkListBill.BillDetail = this.dataGridView1.DataSource as DataTable;
            if (SaveBill()) {
                DialogResult = DialogResult.OK;
            }
        }
        private bool SaveBill() {
            if ((new DatabaseService()).SaveCheckBill(checkListBill) <= 0) {
                return false;
            }
            return true;
        }
    }
}
