using RoomReservation.BLL;
using RoomReservation.DAL;
using RoomReservation.Forms;
using RoomReservation.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoomReservation
{
    public partial class FormMain : Form
    {
        #region Constants & Properties
        private Booking booking = null;
        private Bookings bookings = null;
        private List<Booking> bookingList = null;
        private List<Booking> bookingListAll = null;
        private Room room = null;
        private Rooms rooms = null;
        private int roomId = 0;
        string startDateSelected = "";
        string endDateSelected = "";
        string[] splitter;
        DateTime startList;
        DateTime endList;
        bool flagMonday = true;
        #endregion

        #region Constructors
        public FormMain()
        {
            InitializeComponent();
            bookingList = new List<Booking>();
            bookingListAll = new List<Booking>();
            rooms = new Rooms();
            room = new Room();
            startList = new DateTime();
            endList = new DateTime();
        }
        #endregion

        #region Events

        /// <summary>
        /// Event that do tasks on screen loading.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            if (cbxRoom.SelectedValue != null)
                room = rooms.LoadRoom(cbxRoom.SelectedValue.ToString());
            else
            {
                LoadRooms();
                LoadWeekDays();
                LoadStartHour();
            }

            if (cbxRoom.SelectedValue != null)
            {
                bookings = new Bookings(cbxRoom.SelectedValue.ToString());
                if (bookings != null)
                    bookingListAll = Functions.ConvertToList<Booking>(bookings.LoadXML());
                LoadBookings();
            }
            tmrRefreshGrid.Interval = 60000;
            tmrRefreshGrid.Start();
        }

        /// <summary>
        /// Event that instances the Rooms' screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRooms_Click(object sender, EventArgs e)
        {
            FormRoom frmRoom = new FormRoom();
            frmRoom.ShowDialog();
            LoadRooms();
            if (bookings == null && cbxRoom.SelectedItem == null)
                return;
            if (bookings == null && cbxRoom.SelectedItem != null)
                bookings = new Bookings(cbxRoom.SelectedValue.ToString());
            if (bookings != null && cbxRoom.SelectedItem == null)
            {
                for (int i = 0; i < 11; i++)
			        dgvBooking.Columns.Remove(dgvBooking.Columns[0].Name);
                return;
            }
            bookingListAll = Functions.ConvertToList<Booking>(bookings.LoadXML());
            LoadBookings();
        }

        /// <summary>
        /// Event that instances the Bookings' screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFutureBookings_Click(object sender, EventArgs e)
        {
            FormBookings frmBooking = new FormBookings();
            frmBooking.ShowDialog();
        }

        /// <summary>
        /// Event that saves the bookings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBookingSave_Click(object sender, EventArgs e)
        {
            if (cbxRoom.SelectedItem != null)
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text) && (cbxWeekDay.SelectedItem != null && cbxWeekDay.SelectedItem != "") &&
                    (cbxStartHour.SelectedItem != null && cbxStartHour.SelectedItem != "") &&
                    (cbxEndHour.SelectedItem != null && cbxEndHour.SelectedItem != ""))
                {
                    splitter = cbxWeekDay.SelectedItem.ToString().Split(' ');
                    startDateSelected = splitter.Last() + "/" + DateTime.Today.Year + " " + cbxStartHour.SelectedItem;
                    DateTime startSelected = Convert.ToDateTime(startDateSelected);
                    endDateSelected = splitter.Last() + "/" + DateTime.Today.Year + " " + cbxEndHour.SelectedItem;
                    DateTime endSelected = Convert.ToDateTime(endDateSelected);

                    #region Verifying if the booking already exists
                    bookingListAll = Functions.ConvertToList<Booking>(bookings.LoadXML());
                    LoadBookings();
                    for (int i = 0; i < bookingList.Count; i++)
                    {
                        splitter = bookingList[i].WeekDay.Split(' ');
                        startDateSelected = splitter.Last() + "/" + DateTime.Today.Year + " " + bookingList[i].StartBookingHour;
                        startList = Convert.ToDateTime(startDateSelected);

                        endDateSelected = splitter.Last() + "/" + DateTime.Today.Year + " " + bookingList[i].EndBookingHour;
                        endList = Convert.ToDateTime(endDateSelected);

                        if ((startList <= startSelected && endList >= endSelected) ||
                            (startList >= startSelected && endList <= endSelected))
                        {
                            MessageBox.Show("O horário está reservado. Verifique o horário escolhido.", "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                    }
                    #endregion

                    int startHour = Convert.ToInt32(cbxStartHour.SelectedItem.ToString().Substring(0, 2));
                    int endHour = Convert.ToInt32(cbxEndHour.SelectedItem.ToString().Substring(0, 2));

                    for (int i = 0; i < (endHour - startHour); i++)
                    {
                        LoadData(i);
                        bookings.ManipulateBooking(booking);
                        bookings.SaveBooking();
                        bookingListAll = Functions.ConvertToList<Booking>(bookings.LoadXML());
                    }

                    txtName.Clear();
                    cbxWeekDay.SelectedIndex = 0;
                    cbxStartHour.SelectedIndex = 0;
                    cbxEndHour.Items.Clear();

                    roomId = Convert.ToInt32(cbxRoom.SelectedValue.ToString());
                    bookingList = Functions.ConvertToList<Booking>(bookings.LoadXML()).Where(x => x.RoomId == roomId).ToList();
                    LoadBookings();
                }
                else
                {
                    MessageBox.Show("Preencha todos os campos para concluir.", "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        /// <summary>
        /// Event that enables on or off the combobox "cbxEndHour" and loads their values.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxStartHour_SelectedValueChanged(object sender, EventArgs e)
        {
            cbxEndHour.Items.Clear();

            if (!string.IsNullOrEmpty(cbxStartHour.SelectedItem.ToString()))
                for (int i = Convert.ToInt32(cbxStartHour.SelectedItem.ToString().Substring(0, 2)); i < 18; i++)
                    cbxEndHour.Items.Add(DateTime.Today.AddHours(i + 1).ToShortTimeString());

            cbxEndHour.Enabled = !string.IsNullOrEmpty(cbxStartHour.SelectedItem.ToString());
        }

        /// <summary>
        /// Event that refreshes the bookings when it is changed the room.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxRoom_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbxRoom.Focused)
            {
                roomId = Convert.ToInt32(cbxRoom.SelectedValue.ToString());
                bookingList = Functions.ConvertToList<Booking>(bookings.LoadXML()).Where(x => x.RoomId == roomId).ToList();
                LoadBookings();
            }
        }

        /// <summary>
        /// Event that closes the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        /// <summary>
        /// Event that deletes a selected booking.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBookingDelete_Click(object sender, EventArgs e)
        {
            if (cbxRoom.SelectedItem != null)
                if (!string.IsNullOrEmpty(dgvBooking.SelectedCells[0].Value.ToString()) && !dgvBooking.CurrentRow.Cells["Horário"].Selected)
                    if (MessageBox.Show("Deseja excluir o agendamento?", "Mecalux", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        bookings.DeleteBooking(dgvBooking.SelectedCells[0].Tag.ToString());
                        LoadBookings();
                    }
        }
        
        /// <summary>
        /// Event that loads the grid of bookings every minute.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrRefreshGrid_Tick(object sender, EventArgs e)
        {
            if (bookings != null)
                LoadBookings();
        }

        /// <summary>
        /// Event that calls the btnBookingDelete event when is pressed delete key.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvBooking_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
                btnBookingDelete_Click(sender, e);
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

        /// <summary>
        /// Method that load week's day in the combobox "cbxWeekDay"
        /// </summary>
        private void LoadWeekDays()
        {
            var culture = new CultureInfo("pt-BR");

            for (int i = 0; i < 12; i++)
                if (DateTime.Today.AddDays(i).DayOfWeek != DayOfWeek.Saturday && 
                    DateTime.Today.AddDays(i).DayOfWeek != DayOfWeek.Sunday)
                    cbxWeekDay.Items.Add(culture.DateTimeFormat.GetDayName(DateTime.Today.AddDays(i).DayOfWeek) 
                        + " - " + DateTime.Today.AddDays(i).Day.ToString().PadLeft(2,'0') + "/" 
                        + DateTime.Today.AddDays(i).Month.ToString().PadLeft(2, '0'));
        }

        /// <summary>
        /// Method that load week's day in the combobox "cbxWeekDay"
        /// </summary>
        private void LoadStartHour()
        {
            for (int i = 8; i < 18; i++)
                cbxStartHour.Items.Add(DateTime.Today.AddHours(i).ToShortTimeString());
        }

        /// <summary>
        /// Method that creates a Booking object.
        /// </summary>
        private void LoadData(int i)
        {
            int startHour = Convert.ToInt32(cbxStartHour.SelectedItem.ToString().Substring(0, 2));
            int endHour = Convert.ToInt32(cbxEndHour.SelectedItem.ToString().Substring(0, 2));

            booking = new Booking()
            {
                Id = bookingListAll.Count > 0 ? bookingListAll.LastOrDefault().Id + 1 : bookingListAll.Count + i + 1,
                RoomId = cbxRoom.SelectedValue == null ? 0 : Convert.ToInt32(cbxRoom.SelectedValue),
                Username = txtName.Text,
                WeekDay = cbxWeekDay.SelectedItem.ToString(),
                StartBookingHour = (startHour+i < 10 ? "0" + (startHour + i) + ":00" : (startHour + i) + ":00"),
                EndBookingHour = (startHour+i+1 < 10 ? "0" + (startHour + i + 1) + ":00" : (startHour + i + 1) + ":00")
            };
        }

        /// <summary>
        /// Method that loads bookings in the datagridview.
        /// </summary>
        private void LoadBookings()
        {
            try
            {
                roomId = Convert.ToInt32(cbxRoom.SelectedValue.ToString());
                if (DateTime.Today.DayOfWeek == DayOfWeek.Monday && flagMonday)
                {
                    for (int i = 0; i < bookingListAll.Count; i++)
                    {
                        splitter = bookingListAll[i].WeekDay.Split(' ');
                        startDateSelected = splitter.Last() + "/"+ DateTime.Today.Year;
                        startList = Convert.ToDateTime(startDateSelected);
                        if (startList < DateTime.Today)
                            bookings.DeleteBooking(bookingListAll[i].Id.ToString());
                    }
                    flagMonday = false;
                }
                bookingList = Functions.ConvertToList<Booking>(bookings.LoadXML()).Where(x => x.RoomId == roomId).ToList();

                dgvBooking.Columns.Clear();
                dgvBooking.Columns.Add("Horário", "Horário");
                dgvBooking.ReadOnly = true;

                #region Creating fix columns
                for (int i = 0; i < 2; i++)
                {
                    using (DataGridViewColumn colMonday = new DataGridViewColumn())
                    {
                        colMonday.Name = DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday) + (i * 7)).Day.ToString().PadLeft(2,'0') + "/" +
                                          DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday) + (i * 7)).Month.ToString().PadLeft(2, '0');
                        colMonday.HeaderText = "segunda-feira - " + colMonday.Name;
                        colMonday.Width = 145;
                        dgvBooking.Columns.Add(colMonday);
                    }
                    using (DataGridViewColumn colTuesday = new DataGridViewColumn())
                    {
                        colTuesday.Name = DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Tuesday) + (i * 7)).Day.ToString().PadLeft(2, '0') + "/" +
                                        DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Tuesday) + (i * 7)).Month.ToString().PadLeft(2, '0');
                        colTuesday.HeaderText = "terça-feira - " + colTuesday.Name;
                        colTuesday.Width = 145;
                        dgvBooking.Columns.Add(colTuesday);
                    }
                    using (DataGridViewColumn colWednesday = new DataGridViewColumn())
                    {
                        colWednesday.Name = DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Wednesday) + (i * 7)).Day.ToString().PadLeft(2, '0') + "/" +
                                         DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Wednesday) + (i * 7)).Month.ToString().PadLeft(2, '0');
                        colWednesday.HeaderText = "quarta-feira - " + colWednesday.Name;
                        colWednesday.Width = 145;
                        dgvBooking.Columns.Add(colWednesday);
                    }
                    using (DataGridViewColumn colThursday = new DataGridViewColumn())
                    {
                        colThursday.Name = DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Thursday) + (i * 7)).Day.ToString().PadLeft(2, '0') + "/" +
                                         DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Thursday) + (i * 7)).Month.ToString().PadLeft(2, '0');
                        colThursday.HeaderText = "quinta-feira - " + colThursday.Name;
                        colThursday.Width = 145;
                        dgvBooking.Columns.Add(colThursday);
                    }
                    using (DataGridViewColumn colFriday = new DataGridViewColumn())
                    {
                        colFriday.Name = DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Friday) + (i * 7)).Day.ToString().PadLeft(2, '0') + "/" +
                                        DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Friday) + (i * 7)).Month.ToString().PadLeft(2, '0');
                        colFriday.HeaderText = "sexta-feira - " + colFriday.Name;
                        colFriday.Width = 145;
                        dgvBooking.Columns.Add(colFriday);
                    }
                }
                #endregion

                #region Creating fix rows

                int ind = 8;
                for (int i = 0; i < 10; i++)
                {
                    int[] columns = new int[11];

                    using (DataGridViewRow row = new DataGridViewRow())
                    {
                        for (int c = 0; c < columns.Length; c++)
                        {
                            row.Cells.Add(new DataGridViewTextBoxCell { Value = (c == 0) ? DateTime.Today.AddHours(ind).ToShortTimeString() : "" });
                        }
                        ind++;
                        dgvBooking.Rows.Add(row);
                    }
                    
                }
                #endregion

                #region Populating cells
                for (int i = 0; i < dgvBooking.Rows.Count; i++)
                    for (int j = 0; j < bookingList.Count; j++)
                        if (Convert.ToDateTime(bookingList[j].StartBookingHour) <= Convert.ToDateTime(dgvBooking.Rows[i].Cells[0].Value.ToString()) &&
                            Convert.ToDateTime(bookingList[j].EndBookingHour) > Convert.ToDateTime(dgvBooking.Rows[i].Cells[0].Value.ToString()))
                            for (int k = 1; k < dgvBooking.Rows[i].Cells.Count; k++)
                                if (bookingList[j].WeekDay == dgvBooking.Columns[k].HeaderText.ToString())
                                {
                                    dgvBooking.Rows[i].Cells[k].Tag = bookingList[j].Id;
                                    dgvBooking.Rows[i].Cells[k].Value = bookingList[j].Username;
                                }
                #endregion

                dgvBooking.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                dgvBooking.Columns["Horário"].Frozen = true;
                dgvBooking.Columns["Horário"].Width = 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Erro para montar tabela temporária," + ex.Message, "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
