using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repository
{
    public class BookingCollectionRepo : IBookingRepository
    {

        private string _connectionString;
        public BookingCollectionRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Booking> GetAll()
        {
            var bookings = new List<Booking>();
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("SELECT BookingID, BookingDate, ResidentID, MachineID, TimeSlot FROM Bookings", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var booking = new Booking
                        {
                            BookingID = (int)reader["BookingID"],
                            BookingDate = (DateTime)reader["BookingDate"],
                            ResidentID = (int)reader["ResidentID"],
                            MachineID = (int)reader["MachineID"],
                            TimeSlot = (TimeSlotType)reader["TimeSlot"]
                        };
                        bookings.Add(booking);
                    }
                }
            }
            return bookings;
        }
        public void Add(Booking booking)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Bookings (BookingDate, ResidentID, MachineID, TimeSlot) VALUES (@BookingDate, @ResidentID, @MachineID, @TimeSlot)", connection);
                command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                command.Parameters.AddWithValue("@ResidentID", booking.ResidentID);
                command.Parameters.AddWithValue("@MachineID", booking.MachineID);
                command.Parameters.AddWithValue("@TimeSlot", booking.TimeSlot);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void Update(Booking booking)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE Bookings SET BookingID = @BookingID, BookingDate = @BookingDate, ResidentID = @ResidentID, MachineID = @MachineID, TimeSlot = @TimeSlot WHERE BookingID = @BookingID", connection);
                command.Parameters.AddWithValue("@BookingID", booking.BookingID);
                command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                command.Parameters.AddWithValue("@ResidentID", booking.ResidentID);
                command.Parameters.AddWithValue("@MachineID", booking.MachineID);
                command.Parameters.AddWithValue("@TimeSlot", booking.TimeSlot);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM Bookings WHERE BookingID = @BookingID", connection);
                command.Parameters.AddWithValue("@BookingID", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
