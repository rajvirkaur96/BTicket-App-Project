using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace BTicketSystem.Models
{
    class UserInfo
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }

        public string PersonName { get; set; }

        public string PersonEmail { get; set; }

        public string PersonPassword { get; set; }

        public string PersonContact { get; set; }


    }
}
