using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repository
{
    internal class ResidentCollectionRepo : IResidentRepository
    {
        private readonly string _connectionString;

        public ResidentCollectionRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Resident resident)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Resident (ResidentID, PhoneNumber, Name, City, PostNr, Email, ApartmentNr, FloorNr) " +
                    "VALUES (@ResidentID, @PhoneNumber, @City, @PostNr, @Email @ApartmentNr, @FloorNr)", conn);

                cmd.Parameters.AddWithValue("@ReisdentID", resident.ResidentID);
                cmd.Parameters.AddWithValue("@PhoneNumber", resident.PhoneNumber);
                cmd.Parameters.AddWithValue("@Name", resident.Name);
                cmd.Parameters.AddWithValue("@City", resident.City);
                cmd.Parameters.AddWithValue("@PostNr", resident.PostNr);
                cmd.Parameters.AddWithValue("@Email", resident.Email);
                cmd.Parameters.AddWithValue("@ApartmentNr", resident.ApartmentNr);
                cmd.Parameters.AddWithValue("@FloorNr", resident.FloorNr);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public List<Resident> GetAll()
        {
            List<Resident> residents = new List<Resident>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Resident", conn);
                conn.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Resident r = new Resident
                        {
                            ResidentID = (int)reader["ResidentID"],
                            PhoneNumber = (string)reader["PhoneNr"],
                            Name = (string)reader["Name"],
                            City = (string)reader["City"],
                            Email = (string)reader["Email"],
                            PostNr = (int)reader["PostNr"],
                            ApartmentNr = (int)reader["ApartmentNr"],
                            FloorNr = (int)reader["FloorNr"]
                        };
                        residents.Add(r);
                    }
                }
            }
            return residents;
        }

        //public Resident FindById(int id)
        //{
        //    Resident resident = null;

        //    using (SqlConnection conn = new SqlConnection(_connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("SELECT * FROM Resident WHERE BeboerID=@id", conn);
        //        cmd.Parameters.AddWithValue("@id", id);
        //        conn.Open();

        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            if (reader.Read())
        //            {
        //                resident = new Resident
        //                {
        //                    ResidentID = (int)reader["BeboerID"],
        //                    Name = (string)reader["Navn"],
        //                    PhoneNumber = (string)reader["Mobil"],
        //                    Email = (string)reader["Email"],
        //                    PostNr = (int)reader["Postnummer"],
        //                    AppartmentNr = (int)reader["Lejlighedsnummer"],
        //                    FloorNr = (int)reader["Etagenummer"]
        //                };
        //            }
        //        }
        //    }
        //    return resident;
        //}
        public void Update(Resident resident)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Resident SET ResidentID=@ResidentId, PhoneNumber=@PhoneNumber, City=@City, PostNr=@PostNr, Email=@Email, " +
                    "ApartmentNr=@ApartmentNr, ApartmentNr=@ApartmentNr, FloorNr=@FloorNr", conn);

                cmd.Parameters.AddWithValue("@ResidentID", resident.ResidentID);
                cmd.Parameters.AddWithValue("@PhoneNumber", resident.PhoneNumber);
                cmd.Parameters.AddWithValue("@Name", resident.Name);
                cmd.Parameters.AddWithValue("@City", resident.City);
                cmd.Parameters.AddWithValue("@PostNr", resident.PostNr);
                cmd.Parameters.AddWithValue("@Email", resident.Email);
                cmd.Parameters.AddWithValue("@ApartmentNr", resident.ApartmentNr);
                cmd.Parameters.AddWithValue("@FloorNr", resident.FloorNr);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Resident WHERE BeboerID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
