using RoomReservation.DAL;
using RoomReservation.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservation.BLL
{
    public class RoomBLL
    {
        #region Constants & Properties
        private RoomDTO roomDTO = null;
        private RoomDAL roomDAL = null;
        #endregion

        #region Constructor
        public RoomBLL()
        {
            roomDAL = new RoomDAL();
        }
        #endregion

        public RoomDTO LoadRoom(string id)
        {
            roomDTO = roomDAL.LoadRoom(id);
            return roomDTO;
        }

        public DataTable LoadXML()
        {
            return roomDAL.LoadXML();
        }

        public void ManipulateRoom(RoomDTO roomDTO)
        {
            roomDAL.ManipulateRoom(roomDTO);
        }

        public void SaveRoom()
        {
            roomDAL.SaveRoom();
        }

        public void DeleteRoom(string id)
        {
            roomDAL.DeleteRoom(id);
        }
    }
}
