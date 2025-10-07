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

        // Henter alle bookinger med beboer og maskine
        public List<Booking> GetAll()
        {
            List<Booking> bookings = new List<Booking>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = @"
                    SELECT 
                        b.BookingID, 
                        b.BookingDate, 
                        b.ResidentID, 
                        b.MachineID, 
                        b.TimeSlot,
                        r.ResidentName, 
                        r.City, 
                        r.PostNr, 
                        r.PhoneNumber, 
                        r.Email, 
                        r.ApartmentNr, 
                        r.FloorNr,
                        m.MachineName, 
                        m.MachineType
                    FROM Bookings b
                    LEFT JOIN Resident r ON b.ResidentID = r.ResidentID
                    LEFT JOIN Machine m ON b.MachineID = m.MachineID";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Booking b = new Booking();
                    b.BookingID = (int)reader["BookingID"];
                    b.BookingDate = (DateTime)reader["BookingDate"];
                    b.ResidentID = (int)reader["ResidentID"];
                    b.MachineID = (int)reader["MachineID"];
                    b.TimeSlot = Enum.Parse<TimeSlotType>(reader["TimeSlot"].ToString());

                    // Fyld beboer
                    Resident res = new Resident();
                    res.ResidentID = b.ResidentID;
                    res.ResidentName = reader["ResidentName"] != DBNull.Value ? reader["ResidentName"].ToString() : "";
                    res.City = reader["City"] != DBNull.Value ? reader["City"].ToString() : "";
                    res.PostNr = reader["PostNr"] != DBNull.Value ? reader["PostNr"].ToString() : "";
                    res.PhoneNumber = reader["PhoneNumber"] != DBNull.Value ? reader["PhoneNumber"].ToString() : "";
                    res.Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "";
                    res.ApartmentNr = reader["ApartmentNr"] != DBNull.Value ? (int)reader["ApartmentNr"] : 0;
                    res.FloorNr = reader["FloorNr"] != DBNull.Value ? (int)reader["FloorNr"] : 0;

                    b.Resident = res;

                    // Fyld maskine
                    string machineType = reader["MachineType"] != DBNull.Value ? reader["MachineType"].ToString() : "";
                    Machine mach;

                    switch (machineType)
                    {
                        case "WashingMachine":
                            mach = new WashingMachine(b.MachineID, b.BookingID, reader["MachineName"].ToString());
                            break;
                        case "Dryer":
                            mach = new Dryer(b.MachineID, b.BookingID, reader["MachineName"].ToString());
                            break;
                        case "IroningMachine":
                            mach = new IroningMachine(b.MachineID, b.BookingID, reader["MachineName"].ToString());
                            break;
                        default:
                            mach = new ConcreteMachine(b.MachineID, b.BookingID, machineType, reader["MachineName"].ToString());
                            break;
                    }

                    b.Machine = mach;

                    bookings.Add(b);
                }
            }

            return bookings;
        }

        // Opret booking
        public void Add(Booking booking)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "INSERT INTO Bookings (BookingDate, ResidentID, MachineID, TimeSlot) VALUES (@BookingDate, @ResidentID, @MachineID, @TimeSlot)",
                    connection);

                command.Parameters.AddWithValue("@BookingDate", booking.BookingDate);
                command.Parameters.AddWithValue("@ResidentID", booking.ResidentID);
                command.Parameters.AddWithValue("@MachineID", booking.MachineID);
                command.Parameters.AddWithValue("@TimeSlot", booking.TimeSlot.ToString());

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Opdater booking
        public void Update(Booking booking)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand(
                    "UPDATE Bookings SET BookingDate = @BookingDate, ResidentID = @ResidentID, MachineID = @MachineID, TimeSlot = @TimeSlot WHERE BookingID = @BookingID",
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

        // Slet booking
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                SqlCommand command = new SqlCommand("DELETE FROM Bookings WHERE BookingID = @BookingID", connection);
                command.Parameters.AddWithValue("@BookingID", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
