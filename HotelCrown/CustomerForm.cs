using HotelCrown.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCrown
{
    public partial class CustomerForm : Form
    {
        HotelContext db;
        public CustomerForm()
        {
            db = new HotelContext();
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            FillCustomers();
        }

        private void FillCustomers()
        {
            dgv.DataSource = db.Customers.ToList();
            cbo.DataSource = Enum.GetValues(typeof(Gender));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gbo.Enabled = true;
            gbo.Text = "New Customer";
            btnSave.Visible = true;
            btnCancel.Visible = true;

            ClearProperties();

        }

        private void ClearProperties()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtIdNo.Clear();
            txtDesc.Clear();
            dtp.Value = DateTime.Now;
            cbo.SelectedIndex = 0;
        }

        private void FillProperties()
        {
            Customer customer = (Customer)dgv.SelectedRows[0].DataBoundItem;
            txtName.Text = customer.FullName;
            txtPhone.Text = customer.PhoneNumber;
            txtIdNo.Text = customer.IdentityNumber.ToString();
            txtDesc.Text = customer.Description;
            dtp.Value = customer.BirthDate;
            cbo.SelectedItem = customer.Gender;
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count < 1)
            {
                return;
            }

            if (gbo.Text == "New Customer")
            {
                return;
            }

            FillProperties();

        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count < 1)
            {
                return;
            }
            gbo.Enabled = true;
            gbo.Text = "Edit Customer";
            btnSave.Visible = true;
            btnCancel.Visible = true;
            FillProperties();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int index;
            long idNo;
            if (txtName.Text.Trim() == "" || txtIdNo.Text.Length > 15)
            {
                MessageBox.Show("Please fill Name and Identity fields properly!");
                return;
            }

            try
            {
                idNo = Convert.ToInt64(txtIdNo.Text.Trim());
            }
            catch (Exception)
            {

                MessageBox.Show("Please provide only number on Identity Number!");
                return;
            }

            if (gbo.Text == "New Customer")
            {

                if (db.Customers.Any(x => x.IdentityNumber == idNo))
                {
                    MessageBox.Show("This customer with same ID number is already exists.");
                    return;
                }

                db.Customers.Add(new Customer { FullName = txtName.Text.Trim(), IdentityNumber = idNo, BirthDate = dtp.Value, PhoneNumber = txtPhone.Text.Trim(), Description = txtDesc.Text.Trim(), Gender = (Gender)cbo.SelectedItem });
                index = dgv.Rows.Count;
            }

            else
            {
                Customer customer = (Customer)dgv.SelectedRows[0].DataBoundItem;
                if (db.Customers.Any(x=>x.Id!=customer.Id && x.IdentityNumber==idNo))
                {
                    MessageBox.Show("This customer with same ID number is already exists.");
                    return;
                }

                customer.FullName = txtName.Text.Trim();
                customer.IdentityNumber = idNo;
                customer.BirthDate = dtp.Value;
                customer.PhoneNumber = txtPhone.Text.Trim();
                customer.Description = txtDesc.Text.Trim();
                customer.Gender = (Gender)cbo.SelectedItem;
                index = dgv.SelectedRows[0].Index;

            }

            db.SaveChanges();
            btnCancel.PerformClick();
            FillCustomers();
            dgv.Rows[index].Selected = true;


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbo.Enabled = false;
            gbo.Text = "Customer";
            btnSave.Visible = false;
            btnCancel.Visible = false;
            ClearProperties();
            FillProperties();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
            if (dgv.SelectedRows.Count < 1)
            {
                return;
            }

            Customer customer= (Customer)dgv.SelectedRows[0].DataBoundItem;
            int index = dgv.SelectedRows[0].Index;

            DialogResult dr = MessageBox.Show("Are you sure?", "Delete Customer", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr.ToString() == "No")
            {
                return;
            }

            if (db.Reservations.ToList().Any(x => x.Customers.Contains(customer)))
            {
                MessageBox.Show("This customer can't be deleted! It is relative with at least one reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                db.Customers.Remove(customer);
                db.SaveChanges();
            }
            ClearProperties();
            FillCustomers();
            if (dgv.SelectedRows.Count < 1)
                return;
            else if (index > dgv.Rows.Count - 1)
                dgv.Rows[index - 1].Selected = true;
            else
                dgv.Rows[index].Selected = true;


        }
    }
}
