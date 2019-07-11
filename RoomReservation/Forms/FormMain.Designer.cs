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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDeleteBooking = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxEndHour = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxStartHour = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxWeekDay = new System.Windows.Forms.ComboBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnBookingSave = new System.Windows.Forms.Button();
            this.btnRooms = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxRoom = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvBooking = new System.Windows.Forms.DataGridView();
            this.tmrRefreshGrid = new System.Windows.Forms.Timer(this.components);
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDeleteBooking);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbxEndHour);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.cbxStartHour);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.cbxWeekDay);
            this.panel2.Controls.Add(this.txtName);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnBookingSave);
            this.panel2.Controls.Add(this.btnRooms);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.cbxRoom);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(840, 175);
            this.panel2.TabIndex = 3;
            // 
            // btnDeleteBooking
            // 
            this.btnDeleteBooking.BackColor = System.Drawing.Color.Black;
            this.btnDeleteBooking.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDeleteBooking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteBooking.ForeColor = System.Drawing.Color.White;
            this.btnDeleteBooking.Image = global::RoomReservation.Properties.Resources.calendar_delete_32x32;
            this.btnDeleteBooking.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteBooking.Location = new System.Drawing.Point(111, 20);
            this.btnDeleteBooking.Name = "btnDeleteBooking";
            this.btnDeleteBooking.Size = new System.Drawing.Size(90, 40);
            this.btnDeleteBooking.TabIndex = 24;
            this.btnDeleteBooking.Text = "Excluir";
            this.btnDeleteBooking.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDeleteBooking.UseVisualStyleBackColor = false;
            this.btnDeleteBooking.Click += new System.EventHandler(this.btnBookingDelete_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(635, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "Hora Final";
            // 
            // cbxEndHour
            // 
            this.cbxEndHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxEndHour.Enabled = false;
            this.cbxEndHour.FormattingEnabled = true;
            this.cbxEndHour.Location = new System.Drawing.Point(635, 110);
            this.cbxEndHour.Name = "cbxEndHour";
            this.cbxEndHour.Size = new System.Drawing.Size(85, 25);
            this.cbxEndHour.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(530, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "Hora Inicial";
            // 
            // cbxStartHour
            // 
            this.cbxStartHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStartHour.FormattingEnabled = true;
            this.cbxStartHour.Items.AddRange(new object[] {
            ""});
            this.cbxStartHour.Location = new System.Drawing.Point(530, 110);
            this.cbxStartHour.Name = "cbxStartHour";
            this.cbxStartHour.Size = new System.Drawing.Size(85, 25);
            this.cbxStartHour.TabIndex = 20;
            this.cbxStartHour.SelectedValueChanged += new System.EventHandler(this.cbxStartHour_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(320, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Dia da Semana";
            // 
            // cbxWeekDay
            // 
            this.cbxWeekDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxWeekDay.FormattingEnabled = true;
            this.cbxWeekDay.Items.AddRange(new object[] {
            ""});
            this.cbxWeekDay.Location = new System.Drawing.Point(320, 110);
            this.cbxWeekDay.Name = "cbxWeekDay";
            this.cbxWeekDay.Size = new System.Drawing.Size(190, 25);
            this.cbxWeekDay.TabIndex = 18;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(155, 110);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(145, 25);
            this.txtName.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(155, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "Reservante";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::RoomReservation.Properties.Resources.cross_32x32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(303, 20);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 40);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Fechar";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnBookingSave
            // 
            this.btnBookingSave.BackColor = System.Drawing.Color.Black;
            this.btnBookingSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnBookingSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBookingSave.ForeColor = System.Drawing.Color.White;
            this.btnBookingSave.Image = global::RoomReservation.Properties.Resources.calendar_add_32x32;
            this.btnBookingSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBookingSave.Location = new System.Drawing.Point(207, 20);
            this.btnBookingSave.Name = "btnBookingSave";
            this.btnBookingSave.Size = new System.Drawing.Size(90, 40);
            this.btnBookingSave.TabIndex = 13;
            this.btnBookingSave.Text = "Salvar";
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
            this.label1.Location = new System.Drawing.Point(15, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Sala selecionada";
            // 
            // cbxRoom
            // 
            this.cbxRoom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxRoom.FormattingEnabled = true;
            this.cbxRoom.Location = new System.Drawing.Point(15, 110);
            this.cbxRoom.Name = "cbxRoom";
            this.cbxRoom.Size = new System.Drawing.Size(120, 25);
            this.cbxRoom.TabIndex = 3;
            this.cbxRoom.SelectedValueChanged += new System.EventHandler(this.cbxRoom_SelectedValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvBooking);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 264);
            this.panel1.TabIndex = 4;
            // 
            // dgvBooking
            // 
            this.dgvBooking.AllowUserToAddRows = false;
            this.dgvBooking.AllowUserToDeleteRows = false;
            this.dgvBooking.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBooking.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBooking.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBooking.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvBooking.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBooking.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvBooking.Location = new System.Drawing.Point(0, 0);
            this.dgvBooking.MultiSelect = false;
            this.dgvBooking.Name = "dgvBooking";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBooking.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvBooking.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvBooking.ShowEditingIcon = false;
            this.dgvBooking.Size = new System.Drawing.Size(840, 264);
            this.dgvBooking.TabIndex = 3;
            // 
            // tmrRefreshGrid
            // 
            this.tmrRefreshGrid.Tick += new System.EventHandler(this.tmrRefreshGrid_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(840, 439);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reserva de Sala";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBooking)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxEndHour;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxStartHour;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxWeekDay;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnBookingSave;
        private System.Windows.Forms.Button btnRooms;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbxRoom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvBooking;
        private System.Windows.Forms.Button btnDeleteBooking;
        private System.Windows.Forms.Timer tmrRefreshGrid;

    }
}