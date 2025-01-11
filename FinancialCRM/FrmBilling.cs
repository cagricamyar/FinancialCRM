using FinancialCRM.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialCRM
{
	public partial class FrmBilling : Form
	{
		public FrmBilling()
		{
			InitializeComponent();
		}

		FinancialCrmDbEntities db = new FinancialCrmDbEntities();

		private void FrmBilling_Load(object sender, EventArgs e)
		{
			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void btnBillList_Click(object sender, EventArgs e)
		{
			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void btnCreateBill_Click(object sender, EventArgs e)
		{
			string title = txtBillTitle.Text;
			decimal amount = decimal.Parse(txtBillAmount.Text);
			string period = txtBillPeriod.Text;

			Bill bills = new Bill();
			bills.BillTitle = title;
			bills.BillAmount = amount;
			bills.BillPeriod = period;
			db.Bills.Add(bills);
			db.SaveChanges();
			MessageBox.Show("Ödeme Oluşturuldu", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void btnDeleteBill_Click(object sender, EventArgs e)
		{
			int id = int.Parse(txtBillId.Text);
			var removeValue = db.Bills.Find(id);
			db.Bills.Remove(removeValue);
			db.SaveChanges();
			MessageBox.Show("Ödeme Silindi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void btnUpdateBill_Click(object sender, EventArgs e)
		{
			string title = txtBillTitle.Text;
			decimal amount = decimal.Parse(txtBillAmount.Text);
			string period = txtBillPeriod.Text;
			int id = int.Parse(txtBillId.Text);
			var updateValue = db.Bills.Find(id);

 			updateValue.BillTitle = title;
			updateValue.BillAmount = amount;
			updateValue.BillPeriod = period;
			db.SaveChanges();
			MessageBox.Show("Ödeme Güncellendi", "Ödeme & Faturalar", MessageBoxButtons.OK, MessageBoxIcon.Information);

			var values = db.Bills.ToList();
			dataGridView1.DataSource = values;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			FrmBanks frmBanks = new FrmBanks();
			frmBanks.Show();
			this.Hide();
		}
	}
}
