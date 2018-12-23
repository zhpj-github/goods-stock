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
    public partial class DlgGoodsTypeEdit : Form
    {
        private DataRow row;
        private GoodsType goodsType = new GoodsType();
        public DlgGoodsTypeEdit() {
            InitializeComponent();
        }
        public DlgGoodsTypeEdit(DataRow row):this() {
            this.row = row;
        }

        private void DlgGoodsTypeEdit_Load(object sender, EventArgs e) {
            if (row != null) {
                this.goodsType = CommonHelper.SetModelByDataRow<GoodsType>(row);

                this.textBoxName.Text = goodsType.Name;
                this.textBoxSpec.Text = goodsType.Spec;
                this.checkBoxDisable.Checked = goodsType.Disable;
            }
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
            goodsType.Name = this.textBoxName.Text.Trim();
            goodsType.Spec = this.textBoxSpec.Text.Trim();
            goodsType.Disable = this.checkBoxDisable.Checked;
            if((new DatabaseService()).SaveGoodsType(goodsType) <= 0) {
                return false;
            }
            return true;
        }

        private bool CheckInput() {
            if (string.IsNullOrWhiteSpace(this.textBoxName.Text)) {
                MessageBox.Show("名称不能为空");
                this.textBoxName.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(this.textBoxSpec.Text)) {
                MessageBox.Show("规格不能为空");
                this.textBoxSpec.Focus();
                return false;
            }
            return true;
        }
    }
}
