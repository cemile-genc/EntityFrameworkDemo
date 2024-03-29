﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFrameworkDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ProductDal _productDal= new ProductDal();
        private void Form1_Load(object sender, EventArgs e)
        {
            //verileri çekme işlemi. refactör ile method haline getirildi.
            LoadProduct();

        }

        //Veri çekme metodu
        private void LoadProduct()
        {
            dgwProducts.DataSource = _productDal.GetAll();
        }
        private void SearchProduct(string key)
        {
           //var result =  dgwProducts.DataSource = _productDal.GetAll().Where(p=>p.Name.Contains(key)).ToList();
           var result = _productDal.GetByName(key);
            dgwProducts.DataSource = result;
        }

        //veri ekleme kodları
        private void btnAdd_Click(object sender, EventArgs e)
        {
            _productDal.Add(new ADONetDemo.Product
            {
                Name = tbxName.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPrice.Text),
                StockAmount = Convert.ToInt32(tbxStockAmount.Text),
            });
            LoadProduct();
            MessageBox.Show("Added!");
        }
        //Güncelleme işlemi.
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _productDal.Update(new ADONetDemo.Product
            {
                ID = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
                Name = tbxNameUpdate.Text,
                UnitPrice = Convert.ToDecimal(tbxUnitPriceUpdate.Text) ,
                StockAmount = Convert.ToInt32(tbxStockAmountUpdate.Text),
            });
            LoadProduct();
            MessageBox.Show("Updated!");
          

        }

        private void dgwProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
            //verileri update tablosuna aktarır.
            tbxNameUpdate.Text = dgwProducts.CurrentRow.Cells[1].Value.ToString();
            tbxUnitPriceUpdate.Text = dgwProducts.CurrentRow.Cells[2].Value.ToString();
            tbxStockAmountUpdate.Text = dgwProducts.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _productDal.Delete(new ADONetDemo.Product
            {
                ID = Convert.ToInt32(dgwProducts.CurrentRow.Cells[0].Value),
            });
            LoadProduct();
            MessageBox.Show("Deleted!");
        }

        private void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            SearchProduct(tbxSearch.Text);   
        }
    }
}
