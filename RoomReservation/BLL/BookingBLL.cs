using RoomReservation.DAL;
using RoomReservation.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservation.BLL
{
    public class BookingBLL
    {
        #region Constants & Properties
        private BookingDAL bookingDAL = null;
        #endregion

        #region Constructor
        public BookingBLL(string pidRoom)
        {
            bookingDAL = new BookingDAL(pidRoom);
        }
        #endregion

        #region Methods

        public DataTable LoadXML()
        {
            return bookingDAL.LoadXML();
        }

        public void ManipulateBooking(BookingDTO bookingDTO)
        {
            bookingDAL.ManipulateBooking(bookingDTO);
        }

        public void SaveBooking()
        {
            bookingDAL.SaveBooking();
        }

        public void DeleteBooking(string id)
        {
            bookingDAL.DeleteBooking(id);
        }

        #endregion
    }
}
