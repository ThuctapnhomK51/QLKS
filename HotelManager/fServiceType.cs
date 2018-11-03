﻿using System.Data;
using System.Windows.Forms;
using HotelManager.DAO;
using HotelManager.DTO;
using System;

namespace HotelManager
{
    public partial class fServiceType : Form
    {
        #region Properties
        DataTable _tableSerViceType;
        public DataTable TableSerViceType
        {
            get => _tableSerViceType;
            private set
            {
                _tableSerViceType = value;
                BindingSource source = new BindingSource();
                source.DataSource = _tableSerViceType;
                dataGridViewServiceType.DataSource = source;
                bindingServiceType.BindingSource = source;
                comboboxID.DataSource = source;
            }
        }

        #endregion

        #region Constructor
        public fServiceType()
        {
            InitializeComponent();
        }
        public fServiceType(DataTable table)
        {
            InitializeComponent();
            this.TableSerViceType = table;
            this.comboboxID.DisplayMember = "id";
            dataGridViewServiceType.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9.75F);
        }
        #endregion

        #region Load
        private void LoadFullServiceType(DataTable table)
        {
            this.TableSerViceType = table;
        }
        #endregion

        #region Click
        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BtnUpdateServiceType_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có muốn cập nhật loại dịch vụ này không?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (result == DialogResult.OK)
                UpdateServiceType();
            comboboxID.Focus();
        }
        private void BtnCLose1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void BtnInsert_Click(object sender, EventArgs e)
        {
            new fAddServiceType().ShowDialog();
            if (btnCancel.Visible == false)
                LoadFullServiceType(GetFullServiceType());
            else
                BtnCancel_Click(null, null);
            comboboxID.SelectedIndex = dataGridViewServiceType.RowCount - 1;
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            txbName.Text = string.Empty;
        }
        private void ToolStripLabel1_Click(object sender, EventArgs e)
        {
            bool check;
            if (saveServiceType.ShowDialog() == DialogResult.Cancel)
                return;
            try
            {
                switch (saveServiceType.FilterIndex)
                {
                    case 2:
                        check = ExportToExcel.Instance.Export(dataGridViewServiceType, saveServiceType.FileName, ModeExportToExcel.XLSX);
                        break;
                    case 3:
                        check = ExportToExcel.Instance.Export(dataGridViewServiceType, saveServiceType.FileName, ModeExportToExcel.PDF);
                        break;
                    default:
                        check = ExportToExcel.Instance.Export(dataGridViewServiceType, saveServiceType.FileName, ModeExportToExcel.XLS);
                        break;
                }
                if (check)
                    MessageBox.Show("Xuất thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Lỗi xuất thất bại", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Lỗi (Cần cài đặt Office)", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            txbSearch.Text = txbSearch.Text.Trim();
            if (txbSearch.Text != string.Empty)
            {
                txbName.Text = string.Empty;
                Search();
                btnSearch.Visible = false;
                btnCancel.Visible = true;
            }
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            LoadFullServiceType(GetFullServiceType());
            btnCancel.Visible = false;
            btnSearch.Visible = true;
        }

        #endregion

        #region GetData
        private DataTable GetFullServiceType()
        {
            return ServiceTypeDAO.Instance.LoadFullServiceType();
        }
        private ServiceType GetServiceTypeNow()
        {
            ServiceType serviceType = new ServiceType();
            if (comboboxID.Text == string.Empty)
                serviceType.Id = 0;
            else
                serviceType.Id = int.Parse(comboboxID.Text);
            txbName.Text = txbName.Text.Trim();
            serviceType.Name = txbName.Text;
            return serviceType;
        }
        private DataTable GetSearchServiceType(string text)
        {
            if (int.TryParse(text, out int id))
                return ServiceTypeDAO.Instance.Search(text, id);
            else
                return ServiceTypeDAO.Instance.Search(text, 0);
        }

        #endregion

        #region Method
        
        private void UpdateServiceType()
        {
           
        }
        private void ChangeText(DataGridViewRow row)
        {
            if (row.IsNewRow)
            {
                bindingNavigatorMoveFirstItem.Enabled = false;
                bindingNavigatorMovePreviousItem.Enabled = false;
                txbName.Text = string.Empty;
            }
            else
            {
                txbName.Text = row.Cells["colName"].Value.ToString();
                ServiceType roomType = new ServiceType(((DataRowView)row.DataBoundItem).Row);
                groupServiceType.Tag = roomType;
                bindingNavigatorMoveFirstItem.Enabled = true;
                bindingNavigatorMovePreviousItem.Enabled = true;
            }
        }
        private void Search()
        {
            LoadFullServiceType(GetSearchServiceType(txbSearch.Text));
        }
        #endregion

        #region Change
        private void DataGridViewServiceType_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewServiceType.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridViewServiceType.SelectedRows[0];
                ChangeText(row);
            }
        }

        #endregion

        #region Key
        private void fServiceType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnUpdateServiceType_Click(sender, e);
            }
        }
        private void TxbSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                BtnSearch_Click(sender, null);
            else
                if (e.KeyChar == 27 && btnCancel.Visible == true)
                BtnCancel_Click(sender, null);
        }

        #endregion

        #region Close
        private void FServiceType_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.BtnCancel_Click(sender, null);
            this.txbSearch.Text = string.Empty;
        }

        #endregion
    }
}
