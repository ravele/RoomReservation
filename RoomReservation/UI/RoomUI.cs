using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoomReservation.DTO;
using RoomReservation.Utils;
using RoomReservation.BLL;

namespace RoomReservation
{
    public partial class RoomUI : Form
    {
        #region Constants & Properties
        private RoomBLL roomBLL = null;
        private RoomDTO room = null;
        private List<RoomDTO> roomList = null;
        private BookingBLL bookingBLL = null;
        private List<BookingDTO> bookingList = null;
        #endregion

        #region Constructors
        public RoomUI()
        {
            InitializeComponent();
            roomBLL = new RoomBLL();
            roomList = new List<RoomDTO>();
            bookingList = new List<BookingDTO>();

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
                roomList = Functions.ConvertToList<RoomDTO>(roomBLL.LoadXML());

                foreach (var item in roomList)
                {
                    if (item.Name == txtRoomName.Text)
                    {
                        MessageBox.Show("Já existe uma sala com este nome.", "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                LoadData();
                roomBLL.ManipulateRoom(room);
                roomBLL.SaveRoom();
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
                    bookingBLL = new BookingBLL(roomId.ToString());
                    bookingList = Functions.ConvertToList<BookingDTO>(bookingBLL.LoadXML()).Where(x => x.RoomId == roomId).ToList();
                    if (bookingList.Count > 0)
                    {
                        MessageBox.Show("Não é possível excluir a sala, pois há agendamento(s) atribuído(s) a ela.", "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        roomBLL.DeleteRoom(dgvRoom.CurrentRow.Cells[0].Value.ToString());
                        dgvRoom.DataSource = roomBLL.LoadXML();
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
                room = new RoomDTO()
                {
                    Id = (txtRoomName.AccessibleName == "0" ? roomList.Last().Id + 1 : Convert.ToInt32(txtRoomName.AccessibleName)),
                    Name = txtRoomName.Text
                };
            }
            else
            {
                room = new RoomDTO()
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
            dgvRoom.DataSource = roomBLL.LoadXML();
            dgvRoom.Columns[0].Visible = false;
            dgvRoom.Columns[1].HeaderText = "Nome da Sala";
        }
        #endregion
        
    }
}