using RoomReservation.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservation.Forms
{
    public partial class FormBookings : Form
    {
        #region Constants & Properties
        private Rooms rooms = null;

        #endregion

        #region Constructors
        public FormBookings()
        {
            InitializeComponent();
            rooms = new Rooms();
        }
        #endregion

        #region Methods
        
        /// <summary>
        /// Method that load rooms in the combobox "cbxRoom"
        /// </summary>
        private void LoadRooms()
        {
            cbxRoom.ValueMember = "Id";
            cbxRoom.DisplayMember = "Name";
            cbxRoom.DataSource = rooms.LoadXML();
        }

        #endregion
    }
}
