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
    public partial class RoomForm : Form
    {
        HotelContext db;
        public RoomForm()
        {
            db = new HotelContext();
            InitializeComponent();
            dgv.AutoGenerateColumns = false;
            FillRooms();
        }

        private void FillRooms()
        {
            dgv.DataSource = db.Rooms.ToList();
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            FillFeatures();
            if (gbo.Text=="Edit Room")
            {
                Room room = (Room)dgv.SelectedRows[0].DataBoundItem;
                txtName.Text = room.RoomName;
                nudCapacity.Value = room.Capacity;
                nudPrice.Value = room.Price;
            }
        }

        private void FillFeatures()
        {
            if (dgv.SelectedRows.Count < 1)
            {
                gboRoom.Text = "Room";
                return;
            }

            Room room = (Room)dgv.SelectedRows[0].DataBoundItem;
            gboRoom.Text = room.RoomName;
            var list = room.Features.ToList();
            lst.DataSource = list;
            var cboList= db.Features.ToList().Where(x => !list.Contains(x)).ToList();
            if (cboList.Count<1)
            {
                cbo.Enabled = false;
            }
            else
            {
                cbo.Enabled = true;
                cbo.DataSource = cboList;
            }
            
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            gbo.Text = "New Room";
            txtName.Clear();
            nudCapacity.Value = nudCapacity.Minimum;
            nudPrice.Value = nudPrice.Minimum;
            dgv.Height = 234;
            gbo.Visible = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            gbo.Visible = false;
            dgv.Height = 382;

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count < 1)
            {
                return;
            }
            gbo.Text = "Edit Room";
            Room room = (Room)dgv.SelectedRows[0].DataBoundItem;
            txtName.Text = room.RoomName;
            nudCapacity.Value = room.Capacity;
            nudPrice.Value = room.Price;
            gbo.Visible = true;
            dgv.Height = 234;


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int index;
            string roomName = txtName.Text.Trim();
            
            if (roomName == "")
            {
                MessageBox.Show("Room name can't be empty");
                return;
            }

            if (gbo.Text == "New Room")
            {

                if (db.Rooms.Any(x => x.RoomName == roomName))
                {
                    MessageBox.Show("This room already exists.");
                    return;
                }

                db.Rooms.Add(new Room { RoomName = roomName, Capacity = Convert.ToInt32(nudCapacity.Value), Price = nudPrice.Value });
                index = dgv.Rows.Count;
            }
            else
            {
                Room room = (Room)dgv.SelectedRows[0].DataBoundItem;
                if (db.Rooms.Any(x => x.RoomName == roomName && x.Id!=room.Id))
                {
                    MessageBox.Show("This room already exists.");
                    return;
                }
                room.RoomName = roomName;
                room.Capacity = Convert.ToInt32(nudCapacity.Value);
                room.Price = nudPrice.Value;
                index = dgv.SelectedRows[0].Index;
                gbo.Text = "New Room";
            

            }
            btnCancel.PerformClick();

            db.SaveChanges();
            txtName.Clear();
            nudCapacity.Value = nudCapacity.Minimum;
            nudPrice.Value = nudPrice.Minimum;

            FillRooms();
            dgv.Rows[index].Selected = true;
            FillFeatures();
        }

        private void btnAddFeature_Click(object sender, EventArgs e)
        {
            if (cbo.SelectedIndex<0 || dgv.SelectedRows.Count < 1)
            {
                return;
            }
            Room room = (Room)dgv.SelectedRows[0].DataBoundItem;
            Feature feature = (Feature)cbo.SelectedItem;
            room.Features.Add(feature);
            db.SaveChanges();
            
            FillFeatures();
            lst.SelectedIndex = lst.Items.Count-1;
        }

        private void btnRemoveFeature_Click(object sender, EventArgs e)
        {
            if (lst.SelectedItems.Count < 1 || dgv.SelectedRows.Count < 1)
            {
                return;
            }
            Room room = (Room)dgv.SelectedRows[0].DataBoundItem;
            Feature feature = (Feature)lst.SelectedItem;

            room.Features.Remove(feature);
            db.SaveChanges();
            int index = lst.SelectedIndex;
            FillFeatures();
            if (lst.SelectedIndex < 0)
                return;
            else if (index > lst.Items.Count - 1)
                lst.SelectedIndex = index - 1;
            else
                lst.SelectedIndex = index;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            btnCancel.PerformClick();
            gbo.Text = "New Room";
            if (dgv.SelectedRows.Count < 1)
            {
                return;
            }
            Room room = (Room)dgv.SelectedRows[0].DataBoundItem;
            int index = dgv.SelectedRows[0].Index;
            DialogResult dr = MessageBox.Show("Are you sure?", "Delete Room", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dr.ToString() == "No")
            {
                return;
            }

            if (db.Reservations.Any(x=>x.RoomId==room.Id))
            {
                MessageBox.Show("This room can't be deleted! It is relative with at least one reservation.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                db.Rooms.Remove(room);
                db.SaveChanges();
            }
            FillRooms();

            if (dgv.SelectedRows.Count < 1)
                return;
            else if (index > dgv.Rows.Count - 1)
                dgv.Rows[index - 1].Selected = true;
            else
                dgv.Rows[index].Selected = true;


        }
    }
}
