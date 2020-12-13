namespace HotelCrown
{
    partial class ReservationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboRoom = new System.Windows.Forms.ComboBox();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpCheckInDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckedInTime = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckOutDate = new System.Windows.Forms.DateTimePicker();
            this.dtpCheckedOutTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cboService = new System.Windows.Forms.ComboBox();
            this.lblStep2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveService = new System.Windows.Forms.Button();
            this.gboService = new System.Windows.Forms.GroupBox();
            this.btnCancelService = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtServicePrice = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gboReservationsService = new System.Windows.Forms.GroupBox();
            this.dgvService = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRemoveService = new System.Windows.Forms.Button();
            this.btnAddService = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.chkCheckedIn = new System.Windows.Forms.CheckBox();
            this.chkCheckedOut = new System.Windows.Forms.CheckBox();
            this.txtTotalPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gboStep2 = new System.Windows.Forms.GroupBox();
            this.gboStep1 = new System.Windows.Forms.GroupBox();
            this.gboStep3 = new System.Windows.Forms.GroupBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.chkStep1 = new System.Windows.Forms.CheckBox();
            this.lblReservation = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.gboService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.gboReservationsService.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).BeginInit();
            this.gboStep2.SuspendLayout();
            this.gboStep1.SuspendLayout();
            this.gboStep3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboRoom
            // 
            this.cboRoom.DisplayMember = "RoomName";
            this.cboRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoom.FormattingEnabled = true;
            this.cboRoom.Location = new System.Drawing.Point(314, 198);
            this.cboRoom.Name = "cboRoom";
            this.cboRoom.Size = new System.Drawing.Size(153, 24);
            this.cboRoom.TabIndex = 1;
            this.cboRoom.SelectedIndexChanged += new System.EventHandler(this.cboRoom_SelectedIndexChanged);
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.AllowUserToAddRows = false;
            this.dgvCustomer.AllowUserToDeleteRows = false;
            this.dgvCustomer.AllowUserToResizeColumns = false;
            this.dgvCustomer.AllowUserToResizeRows = false;
            this.dgvCustomer.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCustomer.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCustomer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column4});
            this.dgvCustomer.Location = new System.Drawing.Point(15, 42);
            this.dgvCustomer.MultiSelect = false;
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.ReadOnly = true;
            this.dgvCustomer.RowHeadersVisible = false;
            this.dgvCustomer.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCustomer.Size = new System.Drawing.Size(452, 147);
            this.dgvCustomer.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "FullName";
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "IdentityNumber";
            this.Column4.HeaderText = "Id Number";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // dtpCheckInDate
            // 
            this.dtpCheckInDate.CustomFormat = "dd/MM/yyyy ";
            this.dtpCheckInDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckInDate.Location = new System.Drawing.Point(21, 49);
            this.dtpCheckInDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpCheckInDate.Name = "dtpCheckInDate";
            this.dtpCheckInDate.Size = new System.Drawing.Size(212, 23);
            this.dtpCheckInDate.TabIndex = 26;
            // 
            // dtpCheckedInTime
            // 
            this.dtpCheckedInTime.CustomFormat = "dd/MM/yyyy  HH:mm:ss";
            this.dtpCheckedInTime.Enabled = false;
            this.dtpCheckedInTime.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckedInTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckedInTime.Location = new System.Drawing.Point(50, 65);
            this.dtpCheckedInTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpCheckedInTime.Name = "dtpCheckedInTime";
            this.dtpCheckedInTime.Size = new System.Drawing.Size(183, 23);
            this.dtpCheckedInTime.TabIndex = 27;
            // 
            // dtpCheckOutDate
            // 
            this.dtpCheckOutDate.CustomFormat = "dd/MM/yyyy ";
            this.dtpCheckOutDate.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckOutDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckOutDate.Location = new System.Drawing.Point(249, 49);
            this.dtpCheckOutDate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpCheckOutDate.Name = "dtpCheckOutDate";
            this.dtpCheckOutDate.Size = new System.Drawing.Size(212, 23);
            this.dtpCheckOutDate.TabIndex = 28;
            // 
            // dtpCheckedOutTime
            // 
            this.dtpCheckedOutTime.CustomFormat = "dd/MM/yyyy  HH:mm:ss";
            this.dtpCheckedOutTime.Enabled = false;
            this.dtpCheckedOutTime.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCheckedOutTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpCheckedOutTime.Location = new System.Drawing.Point(49, 134);
            this.dtpCheckedOutTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dtpCheckedOutTime.Name = "dtpCheckedOutTime";
            this.dtpCheckedOutTime.Size = new System.Drawing.Size(184, 23);
            this.dtpCheckedOutTime.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 16);
            this.label1.TabIndex = 30;
            this.label1.Text = "Available Rooms";
            // 
            // cboService
            // 
            this.cboService.DisplayMember = "ServiceName";
            this.cboService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboService.FormattingEnabled = true;
            this.cboService.Location = new System.Drawing.Point(33, 39);
            this.cboService.Name = "cboService";
            this.cboService.Size = new System.Drawing.Size(163, 24);
            this.cboService.TabIndex = 32;
            this.cboService.ValueMember = "Id";
            this.cboService.SelectedIndexChanged += new System.EventHandler(this.cboService_SelectedIndexChanged);
            // 
            // lblStep2
            // 
            this.lblStep2.AutoSize = true;
            this.lblStep2.Location = new System.Drawing.Point(12, 23);
            this.lblStep2.Name = "lblStep2";
            this.lblStep2.Size = new System.Drawing.Size(77, 16);
            this.lblStep2.TabIndex = 34;
            this.lblStep2.Text = "Customers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 16);
            this.label3.TabIndex = 35;
            this.label3.Text = "Check-in Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(246, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 16);
            this.label4.TabIndex = 36;
            this.label4.Text = "Check-out Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "Time";
            // 
            // btnSaveService
            // 
            this.btnSaveService.Location = new System.Drawing.Point(70, 141);
            this.btnSaveService.Name = "btnSaveService";
            this.btnSaveService.Size = new System.Drawing.Size(62, 29);
            this.btnSaveService.TabIndex = 40;
            this.btnSaveService.Text = "Save";
            this.btnSaveService.UseVisualStyleBackColor = true;
            this.btnSaveService.Click += new System.EventHandler(this.btnSaveService_Click);
            // 
            // gboService
            // 
            this.gboService.Controls.Add(this.btnSaveService);
            this.gboService.Controls.Add(this.btnCancelService);
            this.gboService.Controls.Add(this.label9);
            this.gboService.Controls.Add(this.nudQuantity);
            this.gboService.Controls.Add(this.cboService);
            this.gboService.Controls.Add(this.txtServicePrice);
            this.gboService.Controls.Add(this.label2);
            this.gboService.Location = new System.Drawing.Point(278, 437);
            this.gboService.Name = "gboService";
            this.gboService.Size = new System.Drawing.Size(231, 196);
            this.gboService.TabIndex = 41;
            this.gboService.TabStop = false;
            this.gboService.Text = "Service";
            this.gboService.Visible = false;
            // 
            // btnCancelService
            // 
            this.btnCancelService.Location = new System.Drawing.Point(134, 141);
            this.btnCancelService.Name = "btnCancelService";
            this.btnCancelService.Size = new System.Drawing.Size(62, 29);
            this.btnCancelService.TabIndex = 42;
            this.btnCancelService.Text = "Cancel";
            this.btnCancelService.UseVisualStyleBackColor = true;
            this.btnCancelService.Click += new System.EventHandler(this.btnCancelService_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(40, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 16);
            this.label9.TabIndex = 55;
            this.label9.Text = "Quantity";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(106, 104);
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(90, 23);
            this.nudQuantity.TabIndex = 41;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtServicePrice
            // 
            this.txtServicePrice.Location = new System.Drawing.Point(106, 73);
            this.txtServicePrice.Name = "txtServicePrice";
            this.txtServicePrice.ReadOnly = true;
            this.txtServicePrice.Size = new System.Drawing.Size(90, 23);
            this.txtServicePrice.TabIndex = 39;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "Price(€)";
            // 
            // gboReservationsService
            // 
            this.gboReservationsService.Controls.Add(this.dgvService);
            this.gboReservationsService.Controls.Add(this.btnRemoveService);
            this.gboReservationsService.Controls.Add(this.btnAddService);
            this.gboReservationsService.Location = new System.Drawing.Point(278, 437);
            this.gboReservationsService.Name = "gboReservationsService";
            this.gboReservationsService.Size = new System.Drawing.Size(231, 196);
            this.gboReservationsService.TabIndex = 59;
            this.gboReservationsService.TabStop = false;
            this.gboReservationsService.Text = "Reservation\'s Service List";
            this.gboReservationsService.Visible = false;
            // 
            // dgvService
            // 
            this.dgvService.AllowUserToAddRows = false;
            this.dgvService.AllowUserToDeleteRows = false;
            this.dgvService.AllowUserToResizeColumns = false;
            this.dgvService.AllowUserToResizeRows = false;
            this.dgvService.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvService.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvService.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvService.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvService.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column2,
            this.Column3});
            this.dgvService.Location = new System.Drawing.Point(11, 26);
            this.dgvService.MultiSelect = false;
            this.dgvService.Name = "dgvService";
            this.dgvService.ReadOnly = true;
            this.dgvService.RowHeadersVisible = false;
            this.dgvService.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvService.Size = new System.Drawing.Size(212, 125);
            this.dgvService.TabIndex = 42;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ServiceName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "UnitPrice";
            this.Column2.HeaderText = "Price";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Quantity";
            this.Column3.HeaderText = "Quantity";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // btnRemoveService
            // 
            this.btnRemoveService.Location = new System.Drawing.Point(156, 157);
            this.btnRemoveService.Name = "btnRemoveService";
            this.btnRemoveService.Size = new System.Drawing.Size(67, 30);
            this.btnRemoveService.TabIndex = 44;
            this.btnRemoveService.Text = "Remove";
            this.btnRemoveService.UseVisualStyleBackColor = true;
            this.btnRemoveService.Click += new System.EventHandler(this.btnRemoveService_Click);
            // 
            // btnAddService
            // 
            this.btnAddService.Location = new System.Drawing.Point(11, 157);
            this.btnAddService.Name = "btnAddService";
            this.btnAddService.Size = new System.Drawing.Size(67, 30);
            this.btnAddService.TabIndex = 42;
            this.btnAddService.Text = "Add";
            this.btnAddService.UseVisualStyleBackColor = true;
            this.btnAddService.Click += new System.EventHandler(this.btnAddService_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(96, 195);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(78, 28);
            this.btnRemove.TabIndex = 48;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(15, 195);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(74, 28);
            this.btnAddCustomer.TabIndex = 46;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // chkCheckedIn
            // 
            this.chkCheckedIn.AutoSize = true;
            this.chkCheckedIn.Location = new System.Drawing.Point(8, 39);
            this.chkCheckedIn.Name = "chkCheckedIn";
            this.chkCheckedIn.Size = new System.Drawing.Size(101, 20);
            this.chkCheckedIn.TabIndex = 49;
            this.chkCheckedIn.Text = "Checked-in";
            this.chkCheckedIn.UseVisualStyleBackColor = true;
            this.chkCheckedIn.CheckedChanged += new System.EventHandler(this.chkCheckedIn_CheckedChanged);
            // 
            // chkCheckedOut
            // 
            this.chkCheckedOut.AutoSize = true;
            this.chkCheckedOut.Location = new System.Drawing.Point(8, 108);
            this.chkCheckedOut.Name = "chkCheckedOut";
            this.chkCheckedOut.Size = new System.Drawing.Size(112, 20);
            this.chkCheckedOut.TabIndex = 50;
            this.chkCheckedOut.Text = "Checked-out\r\n";
            this.chkCheckedOut.UseVisualStyleBackColor = true;
            this.chkCheckedOut.CheckedChanged += new System.EventHandler(this.chkCheckedOut_CheckedChanged);
            // 
            // txtTotalPrice
            // 
            this.txtTotalPrice.Location = new System.Drawing.Point(308, 675);
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            this.txtTotalPrice.Size = new System.Drawing.Size(120, 23);
            this.txtTotalPrice.TabIndex = 51;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(204, 673);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 27);
            this.label8.TabIndex = 52;
            this.label8.Text = "Total Price(€)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 53;
            this.label6.Text = "Time";
            // 
            // gboStep2
            // 
            this.gboStep2.Controls.Add(this.dgvCustomer);
            this.gboStep2.Controls.Add(this.cboRoom);
            this.gboStep2.Controls.Add(this.label1);
            this.gboStep2.Controls.Add(this.lblStep2);
            this.gboStep2.Controls.Add(this.btnAddCustomer);
            this.gboStep2.Controls.Add(this.btnRemove);
            this.gboStep2.Enabled = false;
            this.gboStep2.Location = new System.Drawing.Point(29, 162);
            this.gboStep2.Name = "gboStep2";
            this.gboStep2.Size = new System.Drawing.Size(480, 237);
            this.gboStep2.TabIndex = 55;
            this.gboStep2.TabStop = false;
            this.gboStep2.Text = "Step 2";
            // 
            // gboStep1
            // 
            this.gboStep1.Controls.Add(this.dtpCheckOutDate);
            this.gboStep1.Controls.Add(this.dtpCheckInDate);
            this.gboStep1.Controls.Add(this.label3);
            this.gboStep1.Controls.Add(this.label4);
            this.gboStep1.Location = new System.Drawing.Point(29, 36);
            this.gboStep1.Name = "gboStep1";
            this.gboStep1.Size = new System.Drawing.Size(480, 94);
            this.gboStep1.TabIndex = 56;
            this.gboStep1.TabStop = false;
            this.gboStep1.Text = "Step 1";
            // 
            // gboStep3
            // 
            this.gboStep3.Controls.Add(this.dtpCheckedInTime);
            this.gboStep3.Controls.Add(this.dtpCheckedOutTime);
            this.gboStep3.Controls.Add(this.label5);
            this.gboStep3.Controls.Add(this.label6);
            this.gboStep3.Controls.Add(this.chkCheckedIn);
            this.gboStep3.Controls.Add(this.chkCheckedOut);
            this.gboStep3.Location = new System.Drawing.Point(29, 437);
            this.gboStep3.Name = "gboStep3";
            this.gboStep3.Size = new System.Drawing.Size(243, 196);
            this.gboStep3.TabIndex = 57;
            this.gboStep3.TabStop = false;
            this.gboStep3.Text = "Step 3";
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(435, 672);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(74, 28);
            this.btnFinish.TabIndex = 56;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // chkStep1
            // 
            this.chkStep1.AutoSize = true;
            this.chkStep1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkStep1.Location = new System.Drawing.Point(435, 134);
            this.chkStep1.Name = "chkStep1";
            this.chkStep1.Size = new System.Drawing.Size(57, 20);
            this.chkStep1.TabIndex = 58;
            this.chkStep1.Text = "Next";
            this.chkStep1.UseVisualStyleBackColor = true;
            this.chkStep1.CheckedChanged += new System.EventHandler(this.chkStep1_CheckedChanged);
            // 
            // lblReservation
            // 
            this.lblReservation.AutoSize = true;
            this.lblReservation.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReservation.Location = new System.Drawing.Point(177, 15);
            this.lblReservation.Name = "lblReservation";
            this.lblReservation.Size = new System.Drawing.Size(185, 18);
            this.lblReservation.TabIndex = 59;
            this.lblReservation.Text = "NEW RESERVATION";
            // 
            // ReservationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(536, 727);
            this.Controls.Add(this.lblReservation);
            this.Controls.Add(this.chkStep1);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.gboStep1);
            this.Controls.Add(this.gboStep2);
            this.Controls.Add(this.txtTotalPrice);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.gboStep3);
            this.Controls.Add(this.gboReservationsService);
            this.Controls.Add(this.gboService);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(552, 766);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(552, 766);
            this.Name = "ReservationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservation";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.gboService.ResumeLayout(false);
            this.gboService.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.gboReservationsService.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvService)).EndInit();
            this.gboStep2.ResumeLayout(false);
            this.gboStep2.PerformLayout();
            this.gboStep1.ResumeLayout(false);
            this.gboStep1.PerformLayout();
            this.gboStep3.ResumeLayout(false);
            this.gboStep3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cboRoom;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.DateTimePicker dtpCheckInDate;
        private System.Windows.Forms.DateTimePicker dtpCheckedInTime;
        private System.Windows.Forms.DateTimePicker dtpCheckOutDate;
        private System.Windows.Forms.DateTimePicker dtpCheckedOutTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboService;
        private System.Windows.Forms.Label lblStep2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveService;
        private System.Windows.Forms.GroupBox gboService;
        private System.Windows.Forms.DataGridView dgvService;
        private System.Windows.Forms.Button btnCancelService;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.Button btnAddService;
        private System.Windows.Forms.Button btnRemoveService;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.CheckBox chkCheckedIn;
        private System.Windows.Forms.CheckBox chkCheckedOut;
        private System.Windows.Forms.TextBox txtTotalPrice;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox gboStep2;
        private System.Windows.Forms.GroupBox gboStep1;
        private System.Windows.Forms.GroupBox gboStep3;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.CheckBox chkStep1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox gboReservationsService;
        private System.Windows.Forms.Label lblReservation;
        private System.Windows.Forms.TextBox txtServicePrice;
        private System.Windows.Forms.Label label2;
    }
}