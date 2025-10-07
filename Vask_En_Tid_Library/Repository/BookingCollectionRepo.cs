using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repository
{
    public class BookingCollectionRepo : IBookingRepository
    {
        private readonly string _connectionString;

        public BookingCollectionRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Booking> GetAll()
        {
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "SELECT BookingID, BookingDate, ResidentID, MachineID, TimeSlot FROM Bookings",
                    connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Booking booking = new Booking();
                    booking.BookingID = (int)reader["BookingID"];
                    booking.BookingDate = (DateTime)reader["BookingDate"];
                    booking.ResidentID = (int)reader["ResidentID"];
                    booking.MachineID = (int)reader["MachineID"];
                    booking.TimeSlot = Enum.Parse<TimeSlotType>(reader["TimeSlot"].ToString());

                    bookings.Add(booking);
                }
            }

            return bookings;
        }

        // Add a booking
        public void Add(Booking booking)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Bookings (BookingDate, ResidentID, MachineID, TimeSlot) " +
                    "VALUES (@BookingDate, @ResidentID, @MachineID, @TimeSlot)",
                    connection);

                command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                command.Parameters.AddWithValue("@ResidentID", booking.ResidentID);
                command.Parameters.AddWithValue("@MachineID", booking.MachineID);
                command.Parameters.AddWithValue("@TimeSlot", booking.TimeSlot.ToString());

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Update a booking
        public void Update(Booking booking)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "UPDATE Bookings SET BookingDate = @BookingDate, ResidentID = @ResidentID, MachineID = @MachineID, TimeSlot = @TimeSlot " +
                    "WHERE BookingID = @BookingID",
                    connection);

                command.Parameters.AddWithValue("@BookingID", booking.BookingID);
                command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                command.Parameters.AddWithValue("@ResidentID", booking.ResidentID);
                command.Parameters.AddWithValue("@MachineID", booking.MachineID);
                command.Parameters.AddWithValue("@TimeSlot", booking.TimeSlot.ToString());

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Delete a booking
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "DELETE FROM Bookings WHERE BookingID = @BookingID", connection);

                command.Parameters.AddWithValue("@BookingID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
