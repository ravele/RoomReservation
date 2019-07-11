using RoomReservation.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservation.DAL
{
    public class Bookings
    {
        #region Constants & Properties
        List<Booking> _bookings = null;
        DataSet dsXML = null;
        string idRoom = string.Empty;
        string filenameXML = Environment.CurrentDirectory + "\\Bookings.xml";
        string filenameXSD = Environment.CurrentDirectory + "\\Bookings.xsd";
        #endregion

        #region Constructor
        public Bookings(string pidRoom)
        {
            this._bookings = new List<Booking>();
            dsXML = new DataSet();
            idRoom = pidRoom;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Method that creates xml and xsd files.
        /// </summary>
        private void CreateXML()
        {
            try
            {
                using (DataTable dtBooking = new DataTable("Booking"))
                {
                    dtBooking.Columns.Add("Id", typeof(int));
                    dtBooking.Columns.Add("RoomId", typeof(string));
                    dtBooking.Columns.Add("Username", typeof(string));
                    dtBooking.Columns.Add("WeekDay", typeof(string));
                    dtBooking.Columns.Add("StartBookingHour", typeof(string));
                    dtBooking.Columns.Add("EndBookingHour", typeof(string));
                    dsXML.Tables.Add(dtBooking);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar xml" + ex.Message, "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dsXML.WriteXml(filenameXML);
                dsXML.WriteXmlSchema(filenameXSD);
            }
        }

        /// <summary>
        /// Method that loads xml and xsd files.
        /// </summary>
        /// <returns></returns>
        public DataTable LoadXML()
        {
            try
            {
                if (!File.Exists(filenameXML))
                    CreateXML();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar xml " + ex.Message, "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                try
                {
                    if (dsXML.Tables.Count > 0)
                        if (dsXML.Tables[0].Rows.Count > 0)
                            dsXML = new DataSet();
                    dsXML.ReadXmlSchema(filenameXSD);
                    dsXML.ReadXml(filenameXML);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar xml, " + ex.Message, "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.Delete(filenameXML);
                    LoadXML();
                }
            }
            return dsXML.Tables["Booking"];
        }

        /// <summary>
        /// Method that adds a line in the table of the xml file.
        /// </summary>
        /// <param name="room">Room object</param>
        public void ManipulateBooking(Booking booking)
        {
            DataRow row;

            if (dsXML.Tables.Count < 1)
                CreateXML();

            row = dsXML.Tables["Booking"].NewRow();
            row["Id"] = booking.Id;
            row["RoomId"] = booking.RoomId;
            row["Username"] = booking.Username;
            row["WeekDay"] = booking.WeekDay;
            row["StartBookingHour"] = booking.StartBookingHour;
            row["EndBookingHour"] = booking.EndBookingHour;

            dsXML.Tables["Booking"].Rows.Add(row);
        }

        /// <summary>
        /// Method that deletes a booking.
        /// </summary>
        /// <param name="id">booking id</param>
        public void DeleteBooking(string id)
        {
            try
            {
                dsXML.Tables["Booking"].Select("Id = " + id)[0].Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir agendamento. " + ex.Message, "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                dsXML.AcceptChanges();
                dsXML.WriteXml(filenameXML);
            }
        }

        /// <summary>
        /// Method that saves the room.
        /// </summary>
        public void SaveBooking()
        {
            dsXML.AcceptChanges();
            dsXML.WriteXml(filenameXML);
        }

        #endregion
    }
}
