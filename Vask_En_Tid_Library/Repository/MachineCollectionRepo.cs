using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Vask_En_Tid_Library.Repository
{
    internal class MachineCollectionRepo
    {
        private readonly string _connectionString;

        public MachineCollectionRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void StartBooking(Models.Machine machine)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand("INSERT INTO Rentals (BikeID, UserID, StartTime) VALUES (@b,@u,@s)", conn);
                cmd.Parameters.AddWithValue("@b", rental.BikeID);
                cmd.Parameters.AddWithValue("@u", rental.UserID);
                cmd.Parameters.AddWithValue("@s", rental.StartTime);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
