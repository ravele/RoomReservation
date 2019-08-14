using RoomReservation.BLL;
using RoomReservation.DAL;
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
                dtpWeekday.MinDate = DateTime.Today;
                dtpWeekday.MaxDate = DateTime.Today.AddDays(365);
                LoadStartHour();
            }

            if (cbxRoom.SelectedValue != null)
            {
                bookings = new Bookings(cbxRoom.SelectedValue.ToString());
                if (bookings != null)
                    bookingListAll = Functions.ConvertToList<Booking>(bookings.LoadXML());
                LoadBookings();
                LoadAllBookings();
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
			        dgvQuickBookings.Columns.Remove(dgvQuickBookings.Columns[0].Name);
                return;
            }
            bookingListAll = Functions.ConvertToList<Booking>(bookings.LoadXML());
            LoadBookings();
            LoadAllBookings();
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
                if (!string.IsNullOrWhiteSpace(txtName.Text) && (cbxStartHour.SelectedItem != null && cbxStartHour.SelectedItem != "") &&
                    (cbxEndHour.SelectedItem != null && cbxEndHour.SelectedItem != ""))
                {
                    startDateSelected = dtpWeekday.Text + " " + cbxStartHour.SelectedItem;
                    DateTime startSelected = Convert.ToDateTime(startDateSelected);
                    endDateSelected = dtpWeekday.Text + " " + cbxEndHour.SelectedItem;
                    DateTime endSelected = Convert.ToDateTime(endDateSelected);

                    #region Verifying if the booking already exists
                    bookingListAll = Functions.ConvertToList<Booking>(bookings.LoadXML());
                    LoadBookings();
                    LoadAllBookings();
                    for (int i = 0; i < bookingList.Count; i++)
                    {
                        splitter = bookingList[i].WeekDay.Split(' ');
                        startDateSelected = bookingList[i].WeekDay + " " + bookingList[i].StartBookingHour;
                        startList = Convert.ToDateTime(startDateSelected);

                        endDateSelected = bookingList[i].WeekDay + " " + bookingList[i].EndBookingHour;
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
                    dtpWeekday.Value = DateTime.Today;
                    cbxStartHour.SelectedIndex = 0;
                    cbxEndHour.Items.Clear();

                    roomId = Convert.ToInt32(cbxRoom.SelectedValue.ToString());
                    bookingList = Functions.ConvertToList<Booking>(bookings.LoadXML()).Where(x => x.RoomId == roomId).ToList();
                    LoadBookings();
                    LoadAllBookings();
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
                LoadAllBookings();
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
            int id = Convert.ToInt32(dgvQuickBookings.SelectedCells[0].Tag);
            DateTime date = Convert.ToDateTime(bookingList[id-1].WeekDay);
            if (date >= DateTime.Today)
            {
                if (cbxRoom.SelectedItem != null)
                    if (!string.IsNullOrEmpty(dgvQuickBookings.SelectedCells[0].Value.ToString()) && !dgvQuickBookings.CurrentRow.Cells["Horário"].Selected)
                        if (MessageBox.Show("Deseja excluir o agendamento?", "Mecalux", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                        {
                            bookings.DeleteBooking(dgvQuickBookings.SelectedCells[0].Tag.ToString());
                            LoadBookings();
                            LoadAllBookings();
                        }
            }
            else
                MessageBox.Show("Você não pode excluir registros antigos!", "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        
        /// <summary>
        /// Event that loads the grid of bookings every minute.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrRefreshGrid_Tick(object sender, EventArgs e)
        {
            if (bookings != null)
            {
                LoadBookings();
                LoadAllBookings();
            }
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

        /// <summary>
        /// Event that expands the visualization of the all bookings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (btnExpand.Text == "▼")
            {
                btnExpand.Text = "▲";
                dgvAllBookings.Visible = true;
            }
            else
            {
                btnExpand.Text = "▼";
                dgvAllBookings.Visible = false;
            }
        }

        /// <summary>
        /// Event that delete info when clicks in the button X.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAllBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {
                if (MessageBox.Show("Deseja excluir o agendamento?", "Mecalux", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    bookings.DeleteBooking(dgvAllBookings.SelectedCells[0].Value.ToString());
                    LoadBookings();
                    LoadAllBookings();
                }
            }
        }

        /// <summary>
        /// Event that doesn't allow that could be selected saturdays and sundays in the calendar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpWeekday_ValueChanged(object sender, EventArgs e)
        {
            if (dtpWeekday.Value.DayOfWeek == DayOfWeek.Saturday)
            {
                dtpWeekday.Text = dtpWeekday.Value.AddDays(2).ToString();
            }
            else if (dtpWeekday.Value.DayOfWeek == DayOfWeek.Sunday)
            {
                dtpWeekday.Text = dtpWeekday.Value.AddDays(1).ToString();
            }
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
        /// Method that load all the bookings
        /// </summary>
        private void LoadAllBookings()
        {
            dgvAllBookings.Columns.Clear();
            dgvAllBookings.DataSource = bookingList;
            dgvAllBookings.Columns[0].Visible = false;
            dgvAllBookings.Columns[1].Visible = false;
            dgvAllBookings.Columns[2].HeaderText = "Reservante";
            dgvAllBookings.Columns[3].HeaderText = "Data da Reserva";
            dgvAllBookings.Columns[4].HeaderText = "Hora Inicial";
            dgvAllBookings.Columns[5].HeaderText = "Hora Final";
            dgvAllBookings.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            dgvAllBookings.Columns.Add(btn);
            btn.HeaderText = "";
            btn.Text = "X";
            btn.FlatStyle = FlatStyle.Popup;
            btn.DefaultCellStyle.BackColor = Color.Red;
            btn.DefaultCellStyle.ForeColor = Color.White;
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;
            dgvAllBookings.Columns[6].Width = 50;
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
                WeekDay = dtpWeekday.Text,
                Username = txtName.Text,
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
                bookingList = Functions.ConvertToList<Booking>(bookings.LoadXML()).Where(x => x.RoomId == roomId).OrderBy(x => Convert.ToDateTime(x.WeekDay)).ThenBy(x => x.StartBookingHour).ToList();

                dgvQuickBookings.Columns.Clear();
                dgvQuickBookings.Columns.Add("Horário", "Horário");
                dgvQuickBookings.ReadOnly = true;

                #region Creating fix columns
                for (int i = 0; i < 2; i++)
                {
                    using (DataGridViewColumn colMonday = new DataGridViewColumn())
                    {
                        colMonday.Name = DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday) + (i * 7)).Day.ToString().PadLeft(2,'0') + "/" +
                                          DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday) + (i * 7)).Month.ToString().PadLeft(2, '0');
                        colMonday.HeaderText = "segunda-feira - " + colMonday.Name;
                        colMonday.Width = 145;
                        dgvQuickBookings.Columns.Add(colMonday);
                    }
                    using (DataGridViewColumn colTuesday = new DataGridViewColumn())
                    {
                        colTuesday.Name = DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Tuesday) + (i * 7)).Day.ToString().PadLeft(2, '0') + "/" +
                                        DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Tuesday) + (i * 7)).Month.ToString().PadLeft(2, '0');
                        colTuesday.HeaderText = "terça-feira - " + colTuesday.Name;
                        colTuesday.Width = 145;
                        dgvQuickBookings.Columns.Add(colTuesday);
                    }
                    using (DataGridViewColumn colWednesday = new DataGridViewColumn())
                    {
                        colWednesday.Name = DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Wednesday) + (i * 7)).Day.ToString().PadLeft(2, '0') + "/" +
                                         DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Wednesday) + (i * 7)).Month.ToString().PadLeft(2, '0');
                        colWednesday.HeaderText = "quarta-feira - " + colWednesday.Name;
                        colWednesday.Width = 145;
                        dgvQuickBookings.Columns.Add(colWednesday);
                    }
                    using (DataGridViewColumn colThursday = new DataGridViewColumn())
                    {
                        colThursday.Name = DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Thursday) + (i * 7)).Day.ToString().PadLeft(2, '0') + "/" +
                                         DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Thursday) + (i * 7)).Month.ToString().PadLeft(2, '0');
                        colThursday.HeaderText = "quinta-feira - " + colThursday.Name;
                        colThursday.Width = 145;
                        dgvQuickBookings.Columns.Add(colThursday);
                    }
                    using (DataGridViewColumn colFriday = new DataGridViewColumn())
                    {
                        colFriday.Name = DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Friday) + (i * 7)).Day.ToString().PadLeft(2, '0') + "/" +
                                        DateTime.Today.AddDays((-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Friday) + (i * 7)).Month.ToString().PadLeft(2, '0');
                        colFriday.HeaderText = "sexta-feira - " + colFriday.Name;
                        colFriday.Width = 145;
                        dgvQuickBookings.Columns.Add(colFriday);
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
                        dgvQuickBookings.Rows.Add(row);
                    }
                    
                }
                #endregion

                #region Populating cells
                for (int i = 0; i < dgvQuickBookings.Rows.Count; i++)
                    for (int j = 0; j < bookingList.Count; j++)
                        if (Convert.ToDateTime(bookingList[j].StartBookingHour) <= Convert.ToDateTime(dgvQuickBookings.Rows[i].Cells[0].Value.ToString()) &&
                            Convert.ToDateTime(bookingList[j].EndBookingHour) > Convert.ToDateTime(dgvQuickBookings.Rows[i].Cells[0].Value.ToString()))
                            for (int k = 1; k < dgvQuickBookings.Rows[i].Cells.Count; k++)
                            {
                                var split = dgvQuickBookings.Columns[k].HeaderText.Split(' ');
                                if (bookingList[j].WeekDay == split.Last().ToString() + "/" + DateTime.Today.Year.ToString())
                                {
                                    dgvQuickBookings.Rows[i].Cells[k].Tag = bookingList[j].Id;
                                    dgvQuickBookings.Rows[i].Cells[k].Value = bookingList[j].Username;
                                }
                            }
                #endregion

                dgvQuickBookings.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f => f.SortMode = DataGridViewColumnSortMode.NotSortable);
                dgvQuickBookings.Columns["Horário"].Frozen = true;
                dgvQuickBookings.Columns["Horário"].Width = 100;

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "Erro para montar tabela temporária," + ex.Message, "Mecalux", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

    }
}
