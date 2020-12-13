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
    public partial class ReservationForm : Form
    {
        HotelContext db;
        Reservation selectedRes;
        public event EventHandler ReservationChanged;
        public ReservationForm()
        {
            db = new HotelContext();
            InitializeComponent();
            dgvCustomer.AutoGenerateColumns = false;
            dgvService.AutoGenerateColumns = false;
            dtpCheckOutDate.Value = dtpCheckInDate.Value.AddDays(1);
        }

        public ReservationForm(HotelContext db, Reservation selectedRes)
        {
            this.db = db;
            this.selectedRes = selectedRes;
            InitializeComponent();
            lblReservation.Text = "EDIT RESERVATION";
            dgvCustomer.AutoGenerateColumns = false;
            dgvService.AutoGenerateColumns = false;
            FillServices();
            FillFields();

        }

        private void CalculatePrice()
        {
            decimal totalServicePrice = 0;
            Room room;
            if (selectedRes!=null)
            {
                List<ReservationService> rsList = selectedRes.ReservationServices.ToList();
                foreach (var item in rsList)
                {
                    totalServicePrice += item.Quantity * item.UnitPrice;
                }
                room = selectedRes.Room == (Room)cboRoom.SelectedItem ? selectedRes.Room : (Room)cboRoom.SelectedItem;
            }
            else
            {
                room= (Room)cboRoom.SelectedItem;
            }
            
            
            DateTime checkInDate = dtpCheckInDate.Value.Date;
            DateTime checkOutDate = dtpCheckOutDate.Value.Date;
            int dayCount = (checkOutDate - checkInDate).Days;
            totalServicePrice += (room.Price * dayCount);
            txtTotalPrice.Text = totalServicePrice.ToString();
        }

        private void FillFields()
        {
            dtpCheckInDate.Value = selectedRes.CheckInDate.Date;
            dtpCheckOutDate.Value = selectedRes.CheckOutDate.Date;

            if (selectedRes.CheckedOutTime != (DateTime?)null)
            {
                chkCheckedOut.Checked = true;
                dtpCheckedOutTime.Value = selectedRes.CheckedOutTime.Value;
                dtpCheckedInTime.Value = selectedRes.CheckedInTime.Value;
            }
            else if (selectedRes.CheckedInTime != (DateTime?)null)
            {
                chkCheckedIn.Checked = true;
                dtpCheckedInTime.Value = selectedRes.CheckedInTime.Value;
            }


        }

        private void FillServices()
        {
            cboService.DataSource = db.Services.ToList();
            dgvService.DataSource = selectedRes.ReservationServices.ToList();
        }

        private void FillRooms()
        {
            //uymayanlar bu listeleye
            //var list = db.Reservations.ToList().Where(x => (x.CheckInDate.Date >= dtpCheckInDate.Value.Date && x.CheckInDate.Date < dtpCheckOutDate.Value.Date)
            //|| (x.CheckOutDate.Date > dtpCheckInDate.Value.Date && x.CheckOutDate.Date <= dtpCheckOutDate.Value.Date)
            //).Select(x => x.Room).ToList();

            var list = db.Reservations.ToList().Where(x => !(x.CheckInDate.Date < dtpCheckInDate.Value.Date && x.CheckOutDate.Date <= dtpCheckInDate.Value.Date)
            && !(x.CheckInDate.Date >= dtpCheckOutDate.Value.Date && x.CheckOutDate.Date > dtpCheckOutDate.Value.Date)
            ).Select(x => x.Room).ToList();
            cboRoom.DataSource = db.Rooms.ToList().Where(x => !list.Contains(x)).ToList();


        }
        private void FillRoomsEditMode()
        {
            var list = db.Reservations.ToList().Where(x => !(x.CheckInDate.Date < dtpCheckInDate.Value.Date && x.CheckOutDate.Date <= dtpCheckInDate.Value.Date)
            && !(x.CheckInDate.Date >= dtpCheckOutDate.Value.Date && x.CheckOutDate.Date > dtpCheckOutDate.Value.Date)
            ).Where(x => x.Id != selectedRes.Id).Select(x => x.Room).ToList();
            cboRoom.DataSource = db.Rooms.ToList().Where(x => !list.Contains(x)).ToList();

            for (int i = 0; i < cboRoom.Items.Count; i++)
            {
                cboRoom.SelectedIndex = i;
                Room room = (Room)cboRoom.SelectedItem;
                if (room.Id == selectedRes.RoomId)
                {
                    cboRoom.SelectedIndex = i;
                    return; ;
                }
            }
        }
        private void FillCustomers()
        {
            var list = db.Customers.ToList().Where(x => x.Reservations.All(y => (y.CheckInDate.Date < dtpCheckInDate.Value.Date && y.CheckOutDate.Date <= dtpCheckInDate.Value.Date)
            || (y.CheckOutDate.Date >= dtpCheckInDate.Value.Date && y.CheckOutDate.Date > dtpCheckOutDate.Value.Date))).ToList();
            dgvCustomer.DataSource = list;
            custList = db.Customers.ToList().Where(x => x.Reservations.All(y => y.CheckOutDate < dtpCheckOutDate.Value.Date)).ToList();

        }

        private void chkCheckedIn_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheckedIn.Checked)
            {
                dtpCheckedInTime.Enabled = true;
            }
            else
            {
                dtpCheckedInTime.Enabled = false;
            }
        }

        private void chkCheckedOut_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCheckedOut.Checked)
            {
                chkCheckedIn.Checked = true;
                chkCheckedIn.Enabled = false;
                dtpCheckedOutTime.Enabled = true;
                dtpCheckedInTime.Enabled = true;

            }
            else
            {
                chkCheckedIn.Enabled = true;
                dtpCheckedOutTime.Enabled = false;
            }
        }

        bool isFirstTime = true;
        List<Customer> custList = new List<Customer>();
        List<Customer> selectedCust = new List<Customer>();
        private void btnAddCustomer_Click(object sender, EventArgs e)
        {

            if (isFirstTime)
            {
                custList = db.Customers.ToList().Where(x => x.Reservations.All(y => (y.CheckInDate.Date < dtpCheckInDate.Value.Date && y.CheckOutDate.Date <= dtpCheckInDate.Value.Date)
            || (y.CheckInDate.Date >= dtpCheckOutDate.Value.Date && y.CheckOutDate.Date > dtpCheckOutDate.Value.Date))).ToList();
                isFirstTime = false;
            }


            if (lblStep2.Text == "Select Customer")
            {
                if (dgvCustomer.SelectedRows.Count < 1)
                {
                    return;
                }

                selectedCust.Add((Customer)dgvCustomer.SelectedRows[0].DataBoundItem);
                custList.Remove((Customer)dgvCustomer.SelectedRows[0].DataBoundItem);
                lblStep2.Text = "Customers";
                dgvCustomer.DataSource = selectedCust;
                btnRemove.Text = "Clear";
                btnAddCustomer.Text = "Add";

            }

            else
            {
                dgvCustomer.DataSource = custList;
                lblStep2.Text = "Select Customer";
                btnRemove.Text = "Cancel";
                btnAddCustomer.Text = "Select";


            }



        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (btnRemove.Text == "Cancel")
            {
                lblStep2.Text = "Customers";
                btnRemove.Text = "Clear";
                btnAddCustomer.Text = "Add";
                dgvCustomer.DataSource = selectedCust;
            }
            else
            {
                if (dgvCustomer.SelectedRows.Count < 1)
                {
                    return;
                }
                if (selectedRes == null)
                {
                    isFirstTime = true;
                }
                selectedCust.Clear();
                dgvCustomer.DataSource = selectedCust.ToList();
            }
        }
        private void btnFinish_Click(object sender, EventArgs e)
        {

            if (cboRoom.Items.Count < 1)
            {
                MessageBox.Show("There is no room selected!");
                return;
            }

            if (selectedCust.Count < 1)
            {
                MessageBox.Show("There is no customer selected!");
                return;
            }
            Room room = (Room)cboRoom.SelectedItem;
            if (room.Capacity < selectedCust.Count)
            {
                MessageBox.Show("Room capacity exceed!");
                return;
            }

            DateTime? checkedIn = chkCheckedIn.Checked ? dtpCheckedInTime.Value : (DateTime?)null;
            DateTime? checkedOut = chkCheckedOut.Checked ? dtpCheckedOutTime.Value : (DateTime?)null;


            DateTime checkInDate = dtpCheckInDate.Value.Date;
            DateTime checkOutDate = dtpCheckOutDate.Value.Date;

            decimal totalServicePrice = 0;
            if (selectedRes!=null)
            {
                List<ReservationService> rsList = selectedRes.ReservationServices.ToList();
                foreach (var item in rsList)
                {
                    totalServicePrice += item.Quantity * item.UnitPrice;
                }
            }
            

            int dayCount = (checkOutDate - checkInDate).Days;
            decimal totalPrice = (room.Price * dayCount)+totalServicePrice;

            if (selectedRes == null)
            {
                db.Reservations.Add(new Reservation { CheckInDate = checkInDate, CheckOutDate = checkOutDate, Room = room, TotalPrice = totalPrice, Customers = selectedCust.ToList(), CheckedInTime = checkedIn, CheckedOutTime = checkedOut });
            }
            else
            {
                selectedRes.CheckInDate = checkInDate;
                selectedRes.CheckOutDate = checkOutDate;
                selectedRes.Room = room;
                selectedRes.TotalPrice = totalPrice;
                selectedRes.Customers = selectedCust.ToList();
                selectedRes.CheckedInTime = checkedIn;
                selectedRes.CheckedOutTime = checkedOut;

            }

            db.SaveChanges();
            WhenReservationChanged(EventArgs.Empty);
            Close();


        }

        private void chkStep1_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStep1.Checked)
            {
                if (dtpCheckOutDate.Value.Date <= dtpCheckInDate.Value.Date)
                {
                    MessageBox.Show("Please enter correct Check-out date.");
                    dtpCheckOutDate.Value = dtpCheckInDate.Value.AddDays(1);
                    chkStep1.Checked = false;
                    return;
                }

                if (selectedRes != null)
                {
                    gboStep1.Enabled = false;
                    gboStep2.Enabled = true;
                    FillRoomsEditMode();
                    CalculatePrice();
                    FillCustomersEditMode();
                    isFirstTime = false;
                    gboReservationsService.Visible = true;

                    return;
                }

                gboStep1.Enabled = false;
                FillRooms();
                gboStep2.Enabled = true;
                dtpCheckedInTime.Value = dtpCheckInDate.Value;
                dtpCheckedOutTime.Value = dtpCheckOutDate.Value;
            }
            else
            {
                gboReservationsService.Visible = false;

                btnRemove.PerformClick();
                gboStep1.Enabled = true;
                gboStep2.Enabled = false;
                isFirstTime = true;
                txtTotalPrice.Clear();
            }
        }

        private void FillCustomersEditMode()
        {
            custList = db.Customers.ToList().Where(x =>
            x.Reservations.All(y => (y.CheckInDate.Date < dtpCheckInDate.Value.Date && y.CheckOutDate.Date <= dtpCheckInDate.Value.Date)
                 || (y.CheckInDate.Date >= dtpCheckOutDate.Value.Date && y.CheckOutDate.Date > dtpCheckOutDate.Value.Date)) || x.Reservations.Contains(selectedRes)).ToList();
            selectedCust = db.Customers.ToList().Where(x => x.Reservations.Contains(selectedRes)).ToList();
            dgvCustomer.DataSource = selectedCust;

        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            gboService.Visible = true;
            gboReservationsService.Visible = false;
            if (cboService.Items.Count < 1)
            {
                MessageBox.Show("No service found.");
                return;
            }

        }
        private void btnEditService_Click(object sender, EventArgs e)
        {
            if (dgvService.Rows.Count < 1)
            {
                return;
            }
            gboService.Visible = true;
            gboReservationsService.Visible = false;
            if (cboService.Items.Count < 1)
            {
                MessageBox.Show("No service found.");
                return;
            }
            ReservationService selectedRS = (ReservationService)dgvService.Rows[0].DataBoundItem;

            for (int i = 0; i < cboService.Items.Count; i++)
            {
                cboService.SelectedIndex = i;
                Service ser = (Service)cboService.SelectedItem;
                if (ser.Id == selectedRS.ServiceId)
                {
                    cboService.SelectedIndex = i;
                    return; ;
                }
            }


        }
        private void btnCancelService_Click(object sender, EventArgs e)
        {
            gboService.Visible = false;
            gboReservationsService.Visible = true;
            nudQuantity.Value = nudQuantity.Minimum;

        }

        List<ReservationService> services = new List<ReservationService>();
        private void btnSaveService_Click(object sender, EventArgs e)
        {
            Service service = (Service)cboService.SelectedItem;

            selectedRes.ReservationServices.Add(new ReservationService { Quantity = (int)nudQuantity.Value, ReservationId = selectedRes.Id, ServiceId = service.Id, ServiceName = service.ServiceName, UnitPrice = service.UnitPrice });

            db.SaveChanges();
            gboService.Visible = false;
            gboReservationsService.Visible = true;
            FillServices();
            CalculatePrice();
        }

        private void cboService_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboService.Items.Count > 1)
            {
                Service service = (Service)cboService.SelectedItem;
                txtServicePrice.Text = service.UnitPrice.ToString();
            }
        }

        private void cboRoom_SelectedIndexChanged(object sender, EventArgs e)
        {

                CalculatePrice();


        }

        protected virtual void WhenReservationChanged(EventArgs args)
        {
            if (ReservationChanged != null)
            {
                ReservationChanged(this, args);
            }
        }

        private void btnRemoveService_Click(object sender, EventArgs e)
        {
            if (dgvService.Rows.Count < 1)
            {
                return;
            }
            ReservationService selectedRS = (ReservationService)dgvService.Rows[0].DataBoundItem;
            //selectedRes.ReservationServices.Remove(selectedRS);
            db.ReservationServices.Remove(selectedRS);
            FillServices();
            CalculatePrice();


        }
    }
}
