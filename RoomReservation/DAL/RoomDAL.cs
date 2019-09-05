using RoomReservation.DTO;
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
    public class RoomDAL
    {
        #region Constants & Properties
        List<RoomDTO> _rooms = null;
        string filenameXML = Environment.CurrentDirectory + "\\Rooms.xml";
        string filenameXSD = Environment.CurrentDirectory + "\\Rooms.xsd";
        DataSet dsXML = null;
        #endregion

        #region Constructors
        public RoomDAL()
        {
            this._rooms = new List<RoomDTO>();
            dsXML = new DataSet();
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
                using (DataTable dtRoom = new DataTable("Room"))
                {
                    dtRoom.Columns.Add("Id", typeof(int));
                    dtRoom.Columns.Add("Name", typeof(string));
                    dsXML.Tables.Add(dtRoom);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao criar xml. "+ ex.Message, "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao carregar xml. " + ex.Message, "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                catch(Exception ex)
                {
                    MessageBox.Show("Erro ao carregar xml. " + ex.Message, "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    File.Delete(filenameXML);
                    LoadXML();
                }
            }
            return dsXML.Tables["Room"];
        }

        /// <summary>
        /// Method that loads a room.
        /// </summary>
        /// <param name="id">room id</param>
        /// <returns>Room object</returns>
        public RoomDTO LoadRoom(string id)
        {
            try
            {
                dsXML.ReadXml(filenameXML);
                RoomDTO room = new RoomDTO();
                DataRow row;
                row = dsXML.Tables["Room"].Select("Id = " + id)[0];
                room.Id = Convert.ToInt32(row["Id"]);
                room.Name = row["Name"].ToString();
                return room;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Erro ao carregar xml. " + ex.Message, "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        /// <summary>
        /// Method that adds a line in the table of the xml file.
        /// </summary>
        /// <param name="room">Room object</param>
        public void ManipulateRoom(RoomDTO room)
        {
            DataRow row;
            
            if (dsXML.Tables.Count < 1)
                CreateXML();
            if (dsXML.Tables["Room"].Select("Id =" + room.Id).Length > 0)
                DeleteRoom(room.Id.ToString());
            row = dsXML.Tables["Room"].NewRow();
            row["Id"] = room.Id;
            row["Name"] = room.Name;

            dsXML.Tables["Room"].Rows.Add(row);
        }

        /// <summary>
        /// Method that deletes a room.
        /// </summary>
        /// <param name="id">room id</param>
        public void DeleteRoom(string id)
        {
            try
            {
                dsXML.Tables["Room"].Select("Id = " + id)[0].Delete();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir sala. " + ex.Message, "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        public void SaveRoom()
        {
            dsXML.AcceptChanges();
            dsXML.WriteXml(filenameXML);
        }
        #endregion
    }
}
