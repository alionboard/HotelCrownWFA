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
    public partial class ServiceForm : Form
    {
        public ServiceForm()
        {
            InitializeComponent();
            FillServices();
        }

        private void FillServices()
        {
            using (var db = new HotelContext())
            {
                lst.DataSource = db.Services.ToList();
                lst.IntegralHeight = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
            gbo.Text = "New Service";
            txtName.Clear();
            nud.Value = 0;
            gbo.Visible = true;
            lst.Height = 216;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
            if (lst.SelectedItems.Count < 1)
                return;
            gbo.Text = "Edit Service";
            Service service = ((Service)lst.SelectedItem);
            txtName.Text = service.ServiceName;
            nud.Value = service.UnitPrice;
            gbo.Visible = true;
            lst.Height = 216;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbo.Visible = false;
            lst.Height = 324;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var db = new HotelContext())
            {
                int index;
                string svcName = txtName.Text.Trim();
                if (svcName == "")
                {
                    MessageBox.Show("Service name can't be empty");
                    return;
                }


                if (gbo.Text == "New Service")
                {

                    if (db.Services.Any(x => x.ServiceName == svcName))
                    {
                        MessageBox.Show("This service already exists.");
                        return;
                    }
                    db.Services.Add(new Service { ServiceName = svcName,UnitPrice=nud.Value });
                    index = lst.Items.Count;
                }

                else
                {

                    Service service = db.Services.Find(lst.SelectedValue);

                    if (db.Services.Any(x => x.ServiceName == svcName && x.Id != service.Id))
                    {
                        MessageBox.Show("This service already exists.");
                        return;
                    }

                    service.ServiceName = svcName;
                    service.UnitPrice = nud.Value;
                    index = lst.SelectedIndex;
                    btnCancel.PerformClick();
                }

                txtName.Clear();
                nud.Value = 0;
                db.SaveChanges();
                FillServices();
                lst.SelectedIndex = index;
            }
        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gbo.Text == "Edit Service")
            {
                if (lst.SelectedItems.Count < 1)
                    return;
                Service service = ((Service)lst.SelectedItem);
                txtName.Text = service.ServiceName;
                nud.Value = service.UnitPrice;
            }
            else
            {
                btnCancel.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
            if (lst.SelectedItems.Count < 1)
                return;

            DialogResult dr=MessageBox.Show("Are you sure?","Delete Service",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (dr.ToString()=="No")
            {
                return;
            }

            using (var db = new HotelContext())
            {
                Service service = db.Services.Find(lst.SelectedValue);
                db.Services.Remove(service);
                db.SaveChanges();
                int index = lst.SelectedIndex;
                FillServices();
                btnCancel.PerformClick();

                if (lst.SelectedIndex < 0)
                    return;
                else if (index > lst.Items.Count - 1)
                    lst.SelectedIndex = index - 1;
                else
                    lst.SelectedIndex = index;
            }
        }
    }
}
