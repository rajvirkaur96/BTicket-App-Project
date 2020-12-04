using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BTicketSystem.Models;
using SQLite;

namespace BTicketSystem.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<UserInfo>().Wait();
            _database.CreateTableAsync<TicketBookingInfo>().Wait();
        }
        //get user
        internal Task<List<UserInfo>> GetUserAsync()
        {
            return _database.Table<UserInfo>().ToListAsync();
        }
        //user save
        internal Task<int> SaveUserAsync(UserInfo user)
        {
            return _database.InsertAsync(user);
        }


        //get booking history
        internal Task<List<TicketBookingInfo>> GetBookingAsync()
        {
            return _database.Table<TicketBookingInfo>().ToListAsync();
        }

        //save booking
        internal Task<int> SaveBookingAsync(TicketBookingInfo ticketB)
        {
            return _database.InsertAsync(ticketB);
        }


        internal async Task<UserInfo> updateUserValidation(string userid, string pass)
        {
            try
            {
                UserInfo data = await getUserData(userid, pass);
                var d1 = _database.Table<UserInfo>().Where(i => i.PersonEmail == userid && i.PersonPassword == pass)
                            .FirstOrDefaultAsync();
                if (data != null)
                {
                    return data;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }


        private Task<UserInfo> getUserData(string userid, string pass)
        {
            var d1 = _database.Table<UserInfo>().Where(i => i.PersonEmail == userid && i.PersonPassword == pass)
                       .FirstOrDefaultAsync();
            return d1;
        }

       


    }
}
