using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repository
{
    internal class MachineCollectionRepo : IMachineRepository
    {
        private readonly string _connectionString;

        public MachineCollectionRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Machine> GetAll()
        {
            var machines = new List<Machine>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT MachineID, BookingDate, ResidentID, MachineID, TimeSlot FROM Bookings", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Machine = new Machine
                        {
                            MachineID = (int)reader["MachineID"],
                            BookingID = (int)reader["BookingID"],
                            MachineName = (string)reader["MachineName"],
                            MachineType = (string)reader["MachineType"],
                        };
                        machines.Add(machine);
                    }
                }
            }
            return machines;
        }

        public void Add(Machine machine)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Machines (BookingID, MachineName, MachineType) VALUES (@BookingID, @MachineName, @MachineType)", connection);
                command.Parameters.AddWithValue("@BookingID", machine.BookingID);
                command.Parameters.AddWithValue("@MachineName", machine.MachineName);
                command.Parameters.AddWithValue("@MachineType", machine.MachineType);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
