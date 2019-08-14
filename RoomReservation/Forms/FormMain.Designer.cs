namespace RoomReservation
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.dtpWeekday = new System.Windows.Forms.DateTimePicker();
            this.btnBookingDelete = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxEndHour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxStartHour = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBookingSave = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxRoom = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvAllBookings = new System.Windows.Forms.DataGridView();
            this.btnExpand = new System.Windows.Forms.Button();
            this.dgvQuickBookings = new System.Windows.Forms.DataGridView();
            this.tmrRefreshGrid = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBookings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuickBookings)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dtpWeekday);
            this.panel2.Controls.Add(this.btnBookingDelete);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbxEndHour);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbxStartHour);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnBookingSave);
            this.panel2.Controls.Add(this.btnRooms);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbxRoom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(868, 164);
            this.panel2.TabIndex = 3;
            // 
            // dtpWeekday
            // 
            this.dtpWeekday.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpWeekday.Location = new System.Drawing.Point(478, 105);
            this.dtpWeekday.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpWeekday.MaxDate = new System.DateTime(2025, 12, 31, 0, 0, 0, 0);
            this.dtpWeekday.MinDate = new System.DateTime(2019, 1, 1, 0, 0, 0, 0);
            this.dtpWeekday.Name = "dtpWeekday";
            this.dtpWeekday.Size = new System.Drawing.Size(145, 29);
            this.dtpWeekday.TabIndex = 28;
            this.dtpWeekday.ValueChanged += new System.EventHandler(this.dtpWeekday_ValueChanged);
            // 
            // btnBookingDelete
            // 
            this.btnBookingDelete.BackColor = System.Drawing.Color.Black;
            this.btnBookingDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBookingDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingDelete.ForeColor = System.Drawing.Color.White;
            this.btnBookingDelete.Image = global::RoomReservation.Properties.Resources.calendar_delete_32x32;
            this.btnBookingDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookingDelete.Location = new System.Drawing.Point(758, 20);
            this.btnBookingDelete.Name = "btnBookingDelete";
            this.btnBookingDelete.Size = new System.Drawing.Size(90, 40);
            this.btnBookingDelete.TabIndex = 24;
            this.btnBookingDelete.Text = "Excluir";
            this.btnBookingDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBookingDelete.UseVisualStyleBackColor = false;
            this.btnBookingDelete.Click += new System.EventHandler(this.btnBookingDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(763, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 23;
            this.label5.Text = "Hora Final";
            // 
            // cbxEndHour
            // 
            this.cbxEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEndHour.Enabled = false;
            this.cbxEndHour.FormattingEnabled = true;
            this.cbxEndHour.Location = new System.Drawing.Point(763, 105);
            this.cbxEndHour.Name = "cbxEndHour";
            this.cbxEndHour.Size = new System.Drawing.Size(85, 29);
            this.cbxEndHour.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(650, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 23);
            this.label4.TabIndex = 21;
            this.label4.Text = "Hora Inicial";
            // 
            // cbxStartHour
            // 
            this.cbxStartHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStartHour.FormattingEnabled = true;
            this.cbxStartHour.Items.AddRange(new object[] {
            ""});
            this.cbxStartHour.Location = new System.Drawing.Point(650, 105);
            this.cbxStartHour.Name = "cbxStartHour";
            this.cbxStartHour.Size = new System.Drawing.Size(85, 29);
            this.cbxStartHour.TabIndex = 20;
            this.cbxStartHour.SelectedValueChanged += new System.EventHandler(this.cbxStartHour_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(475, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 23);
            this.label3.TabIndex = 19;
            this.label3.Text = "Data da Reserva";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(195, 105);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 29);
            this.txtName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(195, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 23);
            this.label2.TabIndex = 16;
            this.label2.Text = "Reservante";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnBookingSave
            // 
            this.btnBookingSave.BackColor = System.Drawing.Color.Black;
            this.btnBookingSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBookingSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingSave.ForeColor = System.Drawing.Color.White;
            this.btnBookingSave.Image = global::RoomReservation.Properties.Resources.calendar_add_32x32;
            this.btnBookingSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookingSave.Location = new System.Drawing.Point(557, 20);
            this.btnBookingSave.Name = "btnBookingSave";
            this.btnBookingSave.Size = new System.Drawing.Size(195, 40);
            this.btnBookingSave.TabIndex = 13;
            this.btnBookingSave.Text = "Confirmar Agendamento";
            this.btnBookingSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBookingSave.UseVisualStyleBackColor = false;
            this.btnBookingSave.Click += new System.EventHandler(this.btnBookingSave_Click);
            // 
            // btnRooms
            // 
            this.btnRooms.BackColor = System.Drawing.Color.Black;
            this.btnRooms.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRooms.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRooms.ForeColor = System.Drawing.Color.White;
            this.btnRooms.Image = global::RoomReservation.Properties.Resources.report_32x32;
            this.btnRooms.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRooms.Location = new System.Drawing.Point(15, 20);
            this.btnRooms.Name = "btnRooms";
            this.btnRooms.Size = new System.Drawing.Size(90, 40);
            this.btnRooms.TabIndex = 5;
            this.btnRooms.Text = "Salas";
            this.btnRooms.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRooms.UseVisualStyleBackColor = false;
            this.btnRooms.Click += new System.EventHandler(this.btnRooms_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sala selecionada";
            // 
            // cbxRoom
            // 
            this.cbxRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRoom.FormattingEnabled = true;
            this.cbxRoom.Location = new System.Drawing.Point(15, 105);
            this.cbxRoom.Name = "cbxRoom";
            this.cbxRoom.Size = new System.Drawing.Size(150, 29);
            this.cbxRoom.TabIndex = 3;
            this.cbxRoom.SelectedValueChanged += new System.EventHandler(this.cbxRoom_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvAllBookings);
            this.panel1.Controls.Add(this.btnExpand);
            this.panel1.Controls.Add(this.dgvQuickBookings);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 536);
            this.panel1.TabIndex = 4;
            // 
            // dgvAllBookings
            // 
            this.dgvAllBookings.AllowUserToAddRows = false;
            this.dgvAllBookings.AllowUserToDeleteRows = false;
            this.dgvAllBookings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllBookings.BackgroundColor = System.Drawing.Color.Black;
            this.dgvAllBookings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllBookings.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvAllBookings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvAllBookings.Location = new System.Drawing.Point(0, 288);
            this.dgvAllBookings.MultiSelect = false;
            this.dgvAllBookings.Name = "dgvAllBookings";
            this.dgvAllBookings.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllBookings.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAllBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllBookings.ShowEditingIcon = false;
            this.dgvAllBookings.Size = new System.Drawing.Size(868, 248);
            this.dgvAllBookings.TabIndex = 4;
            this.dgvAllBookings.Visible = false;
            this.dgvAllBookings.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAllBookings_CellClick);
            // 
            // btnExpand
            // 
            this.btnExpand.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.ForeColor = System.Drawing.Color.White;
            this.btnExpand.Location = new System.Drawing.Point(0, 264);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(868, 24);
            this.btnExpand.TabIndex = 5;
            this.btnExpand.Text = "▼";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // dgvQuickBookings
            // 
            this.dgvQuickBookings.AllowUserToAddRows = false;
            this.dgvQuickBookings.AllowUserToDeleteRows = false;
            this.dgvQuickBookings.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuickBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvQuickBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvQuickBookings.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvQuickBookings.Dock = System.Windows.Forms.DockStyle.Top;
            this.dgvQuickBookings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvQuickBookings.Location = new System.Drawing.Point(0, 0);
            this.dgvQuickBookings.MultiSelect = false;
            this.dgvQuickBookings.Name = "dgvQuickBookings";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvQuickBookings.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvQuickBookings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvQuickBookings.ShowEditingIcon = false;
            this.dgvQuickBookings.Size = new System.Drawing.Size(868, 264);
            this.dgvQuickBookings.TabIndex = 3;
            this.dgvQuickBookings.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvBooking_KeyDown);
            // 
            // tmrRefreshGrid
            // 
            this.tmrRefreshGrid.Tick += new System.EventHandler(this.tmrRefreshGrid_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(868, 700);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reserva de Sala";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBookings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuickBookings)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxEndHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxStartHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBookingSave;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxRoom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvQuickBookings;
        private System.Windows.Forms.Button btnBookingDelete;
        private System.Windows.Forms.Timer tmrRefreshGrid;
        private System.Windows.Forms.DataGridView dgvAllBookings;
        private System.Windows.Forms.DateTimePicker dtpWeekday;
        private System.Windows.Forms.Button btnExpand;

    }
}