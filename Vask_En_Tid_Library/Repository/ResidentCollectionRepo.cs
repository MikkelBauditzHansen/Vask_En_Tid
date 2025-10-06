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
                cmd.Parameters.AddWithValue("@f", resident.FloorNr);

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
                            ResidentID = (int)reader["BeboerID"],
                            Name = (string)reader["Navn"],
                            PhoneNumber = (string)reader["Mobil"],
                            Email = (string)reader["Email"],
                            PostNr = (int)reader["Postnummer"],
                            AppartmentNr = (int)reader["Lejlighedsnummer"],
                            FloorNr = (int)reader["Etagenummer"]
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
                    "UPDATE Resident SET Navn=@n, Mobil=@m, Email=@e, Postnummer=@p, " +
                    "Lejlighedsnummer=@l, Etagenummer=@f WHERE BeboerID=@id", conn);

                cmd.Parameters.AddWithValue("@n", resident.Name);
                cmd.Parameters.AddWithValue("@m", resident.PhoneNumber);
                cmd.Parameters.AddWithValue("@e", resident.Email);
                cmd.Parameters.AddWithValue("@p", resident.PostNr);
                cmd.Parameters.AddWithValue("@l", resident.AppartmentNr);
                cmd.Parameters.AddWithValue("@f", resident.FloorNr);
                cmd.Parameters.AddWithValue("@id", resident.ResidentID);

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
