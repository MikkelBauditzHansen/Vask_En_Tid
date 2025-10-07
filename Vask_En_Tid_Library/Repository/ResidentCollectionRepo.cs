using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repository
{
    public class ResidentCollectionRepo : IResidentRepository
    {
        private readonly string _connectionString;

        public ResidentCollectionRepo(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Add(Resident resident)
        {
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=VaskEnTid;Trusted_Connection=True;TrustServerCertificate=True;"))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Resident (PhoneNumber, ResidentName, City, PostNr, Email, ApartmentNr, FloorNr) " +
                    "VALUES (@PhoneNumber, @ResidentName, @City, @PostNr, @Email, @ApartmentNr, @FloorNr)", conn);

                cmd.Parameters.AddWithValue("@PhoneNumber", resident.PhoneNumber);
                cmd.Parameters.AddWithValue("@ResidentName", resident.ResidentName);
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

            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=VaskEnTid;Trusted_Connection=True;TrustServerCertificate=True;"))
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
                            PhoneNumber = (string)reader["PhoneNumber"],
                            ResidentName = (string)reader["ResidentName"],
                            City = (string)reader["City"],
                            Email = (string)reader["Email"],
                            PostNr = (string)reader["PostNr"],
                            ApartmentNr = (int)reader["ApartmentNr"],
                            FloorNr = (int)reader["FloorNr"]
                        };
                        residents.Add(r);
                    }
                }
            }
            return residents;
        }

        public void Update(Resident resident)
        {
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=VaskEnTid;Trusted_Connection=True;TrustServerCertificate=True;"))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Resident SET ResidentID=@ResidentId, PhoneNumber=@PhoneNumber, ResidentName = @ResidentName, City=@City, PostNr=@PostNr, Email=@Email, " +
                    "ApartmentNr=@ApartmentNr, ApartmentNr=@ApartmentNr, FloorNr=@FloorNr", conn);

                cmd.Parameters.AddWithValue("@ResidentID", resident.ResidentID);
                cmd.Parameters.AddWithValue("@PhoneNumber", resident.PhoneNumber);
                cmd.Parameters.AddWithValue("@ResidentName", resident.ResidentName);
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
                SqlCommand cmd = new SqlCommand("DELETE FROM Resident WHERE ResidentID=@id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
