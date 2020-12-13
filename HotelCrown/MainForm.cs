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
    public partial class MainForm : Form
    {
        HotelContext db;
        private List<Reservation> reserv;

        string filterByCheckIn = "All";
        string filterByCheckOut = "All";
        public MainForm()
        {
            this.db = new HotelContext();
            InitializeComponent();
            dtpCheckInDate.Value = dtpCheckInDate.Value.AddDays(-15);
            dtpCheckOutDate.Value = dtpCheckOutDate.Value.AddDays(15);

            FillReservations();
        }


        private void FillReservations()
        {
            reserv = db.Reservations.OrderByDescending(x => x.CheckInDate).ToList().Where(x => x.CheckInDate.Date >= dtpCheckInDate.Value.Date && x.CheckOutDate.Date <= dtpCheckOutDate.Value.Date).ToList();

            if (filterByCheckIn == "All" && filterByCheckOut == "All")
            {
                dgvReservations.DataSource = reserv.Select(x => new
                {
                    Id = x.Id,
                    Room = x.Room.RoomName,
                    CheckInDate = x.CheckInDate.Date,
                    CheckOutDate = x.CheckOutDate.Date,
                    CheckedIn = x.CheckedInTime != (DateTime?)null ? "Yes" : "No",
                    CheckedOut = x.CheckedOutTime != (DateTime?)null ? "Yes" : "No",
                    Customers = x.CustWithComma
                }).ToList().Where(x => x.Customers.ToLower().Contains(txtSearch.Text.Trim().ToLower())).ToList();
            }

            else if (filterByCheckIn == "All" && filterByCheckOut != "All")
            {
                dgvReservations.DataSource = reserv.Select(x => new
                {
                    Id = x.Id,
                    Room = x.Room.RoomName,
                    CheckInDate = x.CheckInDate.Date,
                    CheckOutDate = x.CheckOutDate.Date,
                    CheckedIn = x.CheckedInTime != (DateTime?)null ? "Yes" : "No",
                    CheckedOut = x.CheckedOutTime != (DateTime?)null ? "Yes" : "No",
                    Customers = x.CustWithComma
                }).ToList().Where(x => x.Customers.ToLower().Contains(txtSearch.Text.Trim().ToLower())).Where(x => x.CheckedOut == filterByCheckOut).ToList();
            }

            else if (filterByCheckIn != "All" && filterByCheckOut == "All")
            {
                dgvReservations.DataSource = reserv.Select(x => new
                {
                    Id = x.Id,
                    Room = x.Room.RoomName,
                    CheckInDate = x.CheckInDate.Date,
                    CheckOutDate = x.CheckOutDate.Date,
                    CheckedIn = x.CheckedInTime != (DateTime?)null ? "Yes" : "No",
                    CheckedOut = x.CheckedOutTime != (DateTime?)null ? "Yes" : "No",
                    Customers = x.CustWithComma
                }).ToList().Where(x => x.Customers.ToLower().Contains(txtSearch.Text.Trim().ToLower())).Where(x => x.CheckedIn == filterByCheckIn).ToList();
            }

            else
            {
                dgvReservations.DataSource = reserv.Select(x => new
                {
                    Id = x.Id,
                    Room = x.Room.RoomName,
                    CheckInDate = x.CheckInDate.Date,
                    CheckOutDate = x.CheckOutDate.Date,
                    CheckedIn = x.CheckedInTime != (DateTime?)null ? "Yes" : "No",
                    CheckedOut = x.CheckedOutTime != (DateTime?)null ? "Yes" : "No",
                    Customers = x.CustWithComma
                }).ToList().Where(x => x.Customers.ToLower().Contains(txtSearch.Text.Trim().ToLower())).Where(x => x.CheckedIn == filterByCheckIn && x.CheckedOut==filterByCheckOut).ToList();
            }


        }

        private void FillTxtFilteredReservations()
        {
            //dgvReservations.DataSource = db.Reservations.OrderByDescending(x => x.CheckInDate).ToList().Where(x => x.CheckInDate.Date >= dtpCheckInDate.Value.Date && x.CheckOutDate.Date <= dtpCheckOutDate.Value.Date)
            //    .Select(x => new
            //    {
            //        Id = x.Id,
            //        Room = x.Room.RoomName,
            //        CheckInDate = x.CheckInDate.Date,
            //        CheckOutDate = x.CheckOutDate.Date,
            //        CheckedIn = x.CheckedInTime != (DateTime?)null ? "Yes" : "No",
            //        CheckedOut = x.CheckedOutTime != (DateTime?)null ? "Yes" : "No",
            //        Customers = x.CustWithComma
            //    }).ToList().Where(x => x.Customers.ToLower().Contains(txtSearch.Text.Trim().ToLower())).ToList();
        }



        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RoomForm roomForm = new RoomForm();
            roomForm.ShowDialog();
        }

        private void featuresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FeatureForm featureForm = new FeatureForm();
            featureForm.ShowDialog();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceForm serviceForm = new ServiceForm();
            serviceForm.ShowDialog();
        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.ShowDialog();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ReservationForm reservationForm = new ReservationForm();
            reservationForm.ReservationChanged += ReservationForm_ReservationChanged;
            reservationForm.ShowDialog();
        }

        private void ReservationForm_ReservationChanged(object sender, EventArgs e)
        {
            FillReservations();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvReservations.Rows.Count < 1)
            {
                return;
            }

            Reservation reservation = db.Reservations.Find(dgvReservations.SelectedRows[0].Cells[0].Value);
            int index = dgvReservations.SelectedRows[0].Index;
            ReservationForm reservationForm = new ReservationForm(db, reservation);
            reservationForm.ReservationChanged += ReservationForm_ReservationChanged;
            reservationForm.ShowDialog();
            dgvReservations.Rows[index].Selected = true;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvReservations.Rows.Count < 1)
            {
                return;
            }
            int index = dgvReservations.SelectedRows[0].Index;

            Reservation reservation = db.Reservations.Find(dgvReservations.SelectedRows[0].Cells[0].Value);
            db.ReservationServices.RemoveRange(reservation.ReservationServices);
            db.Reservations.Remove(reservation);
            db.SaveChanges();
            FillReservations();

            if (dgvReservations.SelectedRows.Count < 1)
                return;
            else if (index > dgvReservations.Rows.Count - 1)
                dgvReservations.Rows[index - 1].Selected = true;
            else
                dgvReservations.Rows[index].Selected = true;

        }

        private void dtpCheckInDate_ValueChanged(object sender, EventArgs e)
        {

            FillReservations();

        }

        private void dtpCheckOutDate_ValueChanged(object sender, EventArgs e)
        {

            FillReservations();


        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillReservations();

        }

        private void lblCheckedInYes_Click(object sender, EventArgs e)
        {
            lblCheckedInAll.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            lblCheckedInYes.Font = new Font(gboFilterBy.Font, FontStyle.Bold);
            lblCheckedInNo.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            filterByCheckIn = "Yes";
            FillReservations();
        }

        private void lblCheckedInNo_Click(object sender, EventArgs e)
        {
            lblCheckedInAll.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            lblCheckedInYes.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            lblCheckedInNo.Font = new Font(gboFilterBy.Font, FontStyle.Bold);
            filterByCheckIn = "No";
            FillReservations();
        }

        private void lblCheckedInAll_Click(object sender, EventArgs e)
        {
            lblCheckedInAll.Font = new Font(gboFilterBy.Font, FontStyle.Bold);
            lblCheckedInYes.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            lblCheckedInNo.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            filterByCheckIn = "All";
            FillReservations();
        }

        private void lblCheckedOutAll_Click(object sender, EventArgs e)
        {
            lblCheckedOutAll.Font = new Font(gboFilterBy.Font, FontStyle.Bold);
            lblCheckedOutYes.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            lblCheckedOutNo.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            filterByCheckOut = "All";
            FillReservations();
        }

        private void lblCheckedOutYes_Click(object sender, EventArgs e)
        {
            lblCheckedOutAll.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            lblCheckedOutYes.Font = new Font(gboFilterBy.Font, FontStyle.Bold);
            lblCheckedOutNo.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            filterByCheckOut = "Yes";
            FillReservations();
        }
        

        private void lblCheckedOutNo_Click(object sender, EventArgs e)
        {
            lblCheckedOutAll.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            lblCheckedOutYes.Font = new Font(gboFilterBy.Font, FontStyle.Regular);
            lblCheckedOutNo.Font = new Font(gboFilterBy.Font, FontStyle.Bold);
            filterByCheckOut = "No";
            FillReservations();
        }
    }
}
