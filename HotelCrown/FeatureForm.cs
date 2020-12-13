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
    public partial class FeatureForm : Form
    {
        public FeatureForm()
        {
            InitializeComponent();
            FillFeatures();
        }

        private void FillFeatures()
        {
            using (var db = new HotelContext())
            {
                lst.DataSource = db.Features.ToList();
                lst.IntegralHeight = false;

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
            gbo.Text = "New Feature";
            txtName.Clear();
            gbo.Visible = true;
            lst.Height = 243;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
            if (lst.SelectedItems.Count < 1)
                return;
            gbo.Text = "Edit Feature";
            Feature feature = ((Feature)lst.SelectedItem);
            txtName.Text = feature.FeatureName;
            gbo.Visible = true;
            lst.Height = 243; //I know it's not a good solution
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
                string ftrName = txtName.Text.Trim();
                if (ftrName == "")
                {
                    MessageBox.Show("Feature name can't be empty");
                    return;
                }


                if (gbo.Text == "New Feature")
                {

                    if (db.Features.Any(x => x.FeatureName == ftrName))
                    {
                        MessageBox.Show("This feature already exists.");
                        return;
                    }
                    db.Features.Add(new Feature { FeatureName = ftrName });
                    index = lst.Items.Count;
                }

                else
                {

                    Feature feature = db.Features.Find(lst.SelectedValue);

                    if (db.Features.Any(x => x.FeatureName == ftrName && x.Id != feature.Id))
                    {
                        MessageBox.Show("This feature already exists.");
                        return;
                    }

                    feature.FeatureName = ftrName;
                    index = lst.SelectedIndex;
                    btnCancel.PerformClick();
                }

                txtName.Clear();
                db.SaveChanges();
                FillFeatures();
                lst.SelectedIndex = index;
            }

        }

        private void lst_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (gbo.Text == "Edit Feature")
            {
                if (lst.SelectedItems.Count < 1)
                    return;
                Feature feature = ((Feature)lst.SelectedItem);
                txtName.Text = feature.FeatureName;
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

            DialogResult dr = MessageBox.Show("Are you sure?", "Delete Feature", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr.ToString() == "No")
            {
                return;
            }
            using (var db = new HotelContext())
            {
                Feature feature = db.Features.Find(lst.SelectedValue);
                db.Features.Remove(feature);
                db.SaveChanges();
                int index = lst.SelectedIndex;
                FillFeatures();
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
