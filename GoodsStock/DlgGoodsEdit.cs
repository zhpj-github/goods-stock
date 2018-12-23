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
    public partial class DlgGoodsEdit : Form
    {
        private DataRow row;
        private Goods goods = new Goods();
        public DlgGoodsEdit() {
            InitializeComponent();
        }
        public DlgGoodsEdit(DataRow row) : this() {
            this.row = row;
            goods = CommonHelper.SetModelByDataRow<Goods>(row);
        }

        private void ButtonSave_Click(object sender, EventArgs e) {
            if (!CheckInput()) {
                return;
            }
            if (SaveInfo()) {
                DialogResult = DialogResult.OK;
            }
        }

        private bool SaveInfo() {
            if ((new DatabaseService()).SaveGoods(goods) <= 0) {
                return false;
            }
            return true;
        }

        private bool CheckInput() {
            if (string.IsNullOrWhiteSpace(this.textBoxCode.Text)) {
                MessageBox.Show("编码不能为空");
                this.textBoxCode.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(this.textBoxName.Text)) {
                MessageBox.Show("名称不能为空");
                this.textBoxName.Focus();
                return false;
            }
            return true;
        }

        private void DlgGoodsEdit_Load(object sender, EventArgs e) {
            this.textBoxCode.DataBindings.Add("Text", goods, "Code");
            this.textBoxName.DataBindings.Add("Text", goods, "Name");
            this.textBoxRemark.DataBindings.Add("Text", goods, "Remark");
            this.textBoxUnit.DataBindings.Add("Text", goods, "Unit");
            DataTable dt = (new DatabaseService()).GetGoodsType();
            this.comboBoxSpec.DataSource = dt;
            this.comboBoxSpec.DisplayMember = "name";
            this.comboBoxSpec.ValueMember = "id";
            this.comboBoxSpec.DataBindings.Add("SelectedValue", goods, "Spec_id");
            this.checkBoxDisable.DataBindings.Add("Checked", goods, "Disable");
        }
    }
}
