using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using RoomReservation.DAL;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoomReservation.BLL;
using RoomReservation.Utils;

namespace RoomReservation
{
    public partial class FormRoom : Form
    {
        #region Constants & Properties
        private Rooms rooms = null;
        private Room room = null;
        private List<Room> roomList = null;
        private Bookings bookings = null;
        private List<Booking> bookingList = null;
        #endregion

        #region Constructors
        public FormRoom()
        {
            InitializeComponent();
            rooms = new Rooms();
            roomList = new List<Room>();
            bookingList = new List<Booking>();

            LoadRooms();
        }
        #endregion

        #region Events
        
        /// <summary>
        /// Close the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRoomClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// Save a new room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRoomSave_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRoomName.Text))
            {
                roomList = Functions.ConvertToList<Room>(rooms.LoadXML());

                foreach (var item in roomList)
                {
                    if (item.Name == txtRoomName.Text)
                    {
                        MessageBox.Show("Já existe uma sala com este nome.", "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                LoadData();
                rooms.ManipulateRoom(room);
                rooms.SaveRoom();
                txtRoomName.AccessibleName = "0";
                txtRoomName.Clear();
                LoadRooms();
            }
        }

        /// <summary>
        /// Delete a room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRoomDelete_Click(object sender, EventArgs e)
        {
            if (dgvRoom.CurrentCell != null)
                if (MessageBox.Show("Deseja excluir a sala?", "Mecalux", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    int roomId = (int)dgvRoom.CurrentRow.Cells[0].Value;
                    bookings = new Bookings(roomId.ToString());
                    bookingList = Functions.ConvertToList<Booking>(bookings.LoadXML()).Where(x => x.RoomId == roomId).ToList();
                    if (bookingList.Count > 0)
                    {
                        MessageBox.Show("Não é possível excluir a sala, pois há agendamento(s) atribuído(s) a ela.", "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        rooms.DeleteRoom(dgvRoom.CurrentRow.Cells[0].Value.ToString());
                        dgvRoom.DataSource = rooms.LoadXML();
                    }
                }
        }

        /// <summary>
        /// Event that edits a selected room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomName.AccessibleName = dgvRoom.SelectedRows[0].Cells[0].Value.ToString();
            txtRoomName.Text = dgvRoom.SelectedRows[0].Cells[1].Value.ToString();
        }

        #endregion
               
        #region Methods
        
        /// <summary>
        /// Method that creates a Room object.
        /// </summary>
        private void LoadData()
        {
            if (roomList.Count != 0)
            {
                room = new Room()
                {
                    Id = (txtRoomName.AccessibleName == "0" ? roomList.Last().Id + 1 : Convert.ToInt32(txtRoomName.AccessibleName)),
                    Name = txtRoomName.Text
                };
            }
            else
            {
                room = new Room()
                {
                    Id = 1,
                    Name = txtRoomName.Text
                };
            }
        }

        /// <summary>
        /// Method that loads the rooms in the datagridview.
        /// </summary>
        private void LoadRooms()
        {
            dgvRoom.DataSource = rooms.LoadXML();
            dgvRoom.Columns[0].Visible = false;
            dgvRoom.Columns[1].HeaderText = "Nome da Sala";
        }
        #endregion
        
    }
}
