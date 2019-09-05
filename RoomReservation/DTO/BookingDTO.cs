using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomReservation.DTO
{
    public class BookingDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string Username { get; set; }
        public string WeekDay { get; set; }
        public string StartBookingHour { get; set; }
        public string EndBookingHour { get; set; }
    }
}
