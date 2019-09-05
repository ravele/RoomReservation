namespace RoomReservation
{
    partial class RoomUI
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRoom = new System.Windows.Forms.DataGridView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRoomClose = new System.Windows.Forms.Button();
            this.btnRoomSave = new System.Windows.Forms.Button();
            this.btnRoomDelete = new System.Windows.Forms.Button();
            this.txtRoomName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRoom);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(315, 376);
            this.panel1.TabIndex = 1;
            // 
            // dgvRoom
            // 
            this.dgvRoom.AllowUserToAddRows = false;
            this.dgvRoom.AllowUserToDeleteRows = false;
            this.dgvRoom.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRoom.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvRoom.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvRoom.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRoom.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgvRoom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvRoom.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvRoom.Location = new System.Drawing.Point(0, 162);
            this.dgvRoom.MultiSelect = false;
            this.dgvRoom.Name = "dgvRoom";
            this.dgvRoom.ReadOnly = true;
            this.dgvRoom.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRoom.ShowEditingIcon = false;
            this.dgvRoom.Size = new System.Drawing.Size(315, 214);
            this.dgvRoom.TabIndex = 0;
            this.dgvRoom.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoom_CellDoubleClick);
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.btnRoomClose);
            this.panel2.Controls.Add(this.btnRoomSave);
            this.panel2.Controls.Add(this.btnRoomDelete);
            this.panel2.Controls.Add(this.txtRoomName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(315, 143);
            this.panel2.TabIndex = 2;
            // 
            // btnRoomClose
            // 
            this.btnRoomClose.BackColor = System.Drawing.Color.Black;
            this.btnRoomClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRoomClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoomClose.ForeColor = System.Drawing.Color.White;
            this.btnRoomClose.Image = global::RoomReservation.Properties.Resources.cross_32x32;
            this.btnRoomClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomClose.Location = new System.Drawing.Point(207, 20);
            this.btnRoomClose.Name = "btnRoomClose";
            this.btnRoomClose.Size = new System.Drawing.Size(90, 40);
            this.btnRoomClose.TabIndex = 12;
            this.btnRoomClose.Text = "Fechar";
            this.btnRoomClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRoomClose.UseVisualStyleBackColor = false;
            this.btnRoomClose.Click += new System.EventHandler(this.btnRoomClose_Click);
            // 
            // btnRoomSave
            // 
            this.btnRoomSave.BackColor = System.Drawing.Color.Black;
            this.btnRoomSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRoomSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoomSave.ForeColor = System.Drawing.Color.White;
            this.btnRoomSave.Image = global::RoomReservation.Properties.Resources.report_add_32x32;
            this.btnRoomSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomSave.Location = new System.Drawing.Point(111, 20);
            this.btnRoomSave.Name = "btnRoomSave";
            this.btnRoomSave.Size = new System.Drawing.Size(90, 40);
            this.btnRoomSave.TabIndex = 9;
            this.btnRoomSave.Text = "Salvar";
            this.btnRoomSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRoomSave.UseVisualStyleBackColor = false;
            this.btnRoomSave.Click += new System.EventHandler(this.btnRoomSave_Click);
            // 
            // btnRoomDelete
            // 
            this.btnRoomDelete.BackColor = System.Drawing.Color.Black;
            this.btnRoomDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnRoomDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoomDelete.ForeColor = System.Drawing.Color.White;
            this.btnRoomDelete.Image = global::RoomReservation.Properties.Resources.report_delete_32x32;
            this.btnRoomDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRoomDelete.Location = new System.Drawing.Point(15, 20);
            this.btnRoomDelete.Name = "btnRoomDelete";
            this.btnRoomDelete.Size = new System.Drawing.Size(90, 40);
            this.btnRoomDelete.TabIndex = 8;
            this.btnRoomDelete.Text = "Excluir";
            this.btnRoomDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRoomDelete.UseVisualStyleBackColor = false;
            this.btnRoomDelete.Click += new System.EventHandler(this.btnRoomDelete_Click);
            // 
            // txtRoomName
            // 
            this.txtRoomName.AccessibleName = "0";
            this.txtRoomName.Location = new System.Drawing.Point(15, 115);
            this.txtRoomName.Name = "txtRoomName";
            this.txtRoomName.Size = new System.Drawing.Size(282, 25);
            this.txtRoomName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Nome:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RoomUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(315, 376);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RoomUI";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Salas";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoom)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvRoom;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRoomClose;
        private System.Windows.Forms.Button btnRoomSave;
        private System.Windows.Forms.Button btnRoomDelete;
        private System.Windows.Forms.TextBox txtRoomName;
        private System.Windows.Forms.Label label1;

    }
}