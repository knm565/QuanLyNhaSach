﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.DAO;

namespace WindowsFormsApp1
{
    public partial class FormCreateBill : Form
    {
        private int idBook;
        private int idInfoBill;
        public FormCreateBill()
        {
            InitializeComponent();
            txtSoHoaDon.Text = "";
            txtSoTienTra.Text = "";
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            btnInBill.Enabled = false;
            
        }

        private void FormCreateBill_Load(object sender, EventArgs e)
        {
            dataGridViewBook.DataSource = CreateBillDAO.Instance.selectCreateBill();
            dataGridViewBook.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewBook.Columns[0].Width = 20;
            dataGridViewBook.ClearSelection();

            cbbKhach.DataSource = CreateBillDAO.Instance.getKhach();
            cbbKhach.DisplayMember = "TenKhachHang";
            cbbKhach.ValueMember = "CapBac";

            cbbKhach.Text = "Không Có";

        }

        private void txtTenSach_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenSach.Text))
            {
                (dataGridViewBook.DataSource as DataTable).DefaultView.RowFilter = string.Empty;
                dataGridViewBook.ClearSelection();
            }
            else
            {
                (dataGridViewBook.DataSource as DataTable).DefaultView.RowFilter = string.Format("TenSach LIKE '{0}%'", txtTenSach.Text);
                dataGridViewBook.ClearSelection();
            }
        }

        private void cbbKhach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbKhach.SelectedValue.ToString() == "Dong")
            {
                txtGiamGia.Text = "5%";
            }else if(cbbKhach.SelectedValue.ToString() == "Bac")
            {
                txtGiamGia.Text = "10%";
            }else if(cbbKhach.SelectedValue.ToString() == "Vang")
            {
                txtGiamGia.Text = "15%";
            }else if(cbbKhach.SelectedValue.ToString() == "Kim Cuong")
            {
                txtGiamGia.Text = "25%";
            }
          
        }

        private void txtSoHoaDon_TextChanged(object sender, EventArgs e)
        {
            if (txtSoHoaDon.Text != "")
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
            }
        }

        private void txtSoTienTra_TextChanged(object sender, EventArgs e)
        {
            if (txtSoHoaDon.Text != "")
            {
                btnInBill.Enabled = true;
            }
        }

        private void btnTaoHoaDon_Click(object sender, EventArgs e)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string date = DateTime.Now.ToString("yyyy/MM/dd");
            CreateBillDAO.Instance.createBill(date, time, LoginDAO.Instance.getId());
            txtSoHoaDon.Text = CreateBillDAO.Instance.getIdBill().ToString();
            btnTaoHoaDon.Enabled = false;

            dataGridViewInfoBill.DataSource = CreateBillDAO.Instance.selectInfoBill(int.Parse(txtSoHoaDon.Text));
            dataGridViewInfoBill.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewInfoBill.Columns[0].Width = 20;
            dataGridViewInfoBill.ClearSelection();
        }

        private void dataGridViewBook_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridViewBook.Rows[e.RowIndex];
                    idBook = int.Parse(row.Cells[0].Value.ToString());
                    btnThem.Enabled = true;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            CreateBillDAO.Instance.addBook(int.Parse(txtSoHoaDon.Text), idBook);
            btnThem.Enabled = false;
            dataGridViewInfoBill.DataSource = CreateBillDAO.Instance.selectInfoBill(int.Parse(txtSoHoaDon.Text));
            dataGridViewInfoBill.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewInfoBill.Columns[0].Width = 20;
            dataGridViewInfoBill.ClearSelection();
        }

        private void dataGridViewInfoBill_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridViewBook.Rows[e.RowIndex];
                    idInfoBill = int.Parse(row.Cells[0].Value.ToString());
                    btnXoa.Enabled = true;
                }
            }
            catch (Exception)
            {

            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            CreateBillDAO.Instance.deleteBook(idInfoBill);
            btnXoa.Enabled = false;
            dataGridViewInfoBill.DataSource = CreateBillDAO.Instance.selectInfoBill(int.Parse(txtSoHoaDon.Text));
            dataGridViewInfoBill.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewInfoBill.Columns[0].Width = 20;
            dataGridViewInfoBill.ClearSelection();
        }
    }
}
