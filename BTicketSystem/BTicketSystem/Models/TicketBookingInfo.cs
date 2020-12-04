using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTicketSystem.Models
{
    class TicketBookingInfo
    {
        [PrimaryKey, AutoIncrement]
        public int TicketID { get; set; }

        public int PersonId { get; set; }

        public string DepartureFrom { get; set; }

        public string ArriveTo { get; set; }

        public DateTime TicketDate { get; set; }

        public TimeSpan TicketTime { get; set; }

        public string TicketType { get; set; }

        public string AirLine { get; set; }

    }
}
