using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repository
{
    public class MachineCollectionRepo : IMachineRepository
    {
        private readonly string _connectionString;

        // Constructor – gemmer connection string så vi kan bruge den i hele klassen
        public MachineCollectionRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        // GET – henter alle maskiner fra databasen
        public List<Machine> GetAll()
        {
            List<Machine> machines = new List<Machine>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // SQL – henter alle maskiner og sorterer efter type og navn
                string query = "SELECT MachineID, MachineName, MachineType FROM Machine ORDER BY MachineType, MachineName";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["MachineID"];
                        string name = reader["MachineName"].ToString();
                        string type = reader["MachineType"].ToString();

                        Machine machine;

                        // Opretter det rigtige maskine-objekt baseret på typen (polymorfi)
                        switch (type)
                        {
                            case "WashingMachine":
                                machine = new WashingMachine(id, 0, name);
                                break;
                            case "Dryer":
                                machine = new Dryer(id, 0, name);
                                break;
                            case "IroningMachine":
                                machine = new IroningMachine(id, 0, name);
                                break;
                            default:
                                machine = new ConcreteMachine(id, 0, type, name);
                                break;
                        }

                        machines.Add(machine);
                    }
                }
            }

            return machines;
        }

        // ADD – tilføjer en ny maskine i databasen
        public void Add(Machine machine)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // SQL – indsætter ny række i Machine-tabellen
                string query = "INSERT INTO Machine (MachineName, MachineType) VALUES (@MachineName, @MachineType)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MachineName", machine.MachineName);
                command.Parameters.AddWithValue("@MachineType", machine.MachineType);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // UPDATE – opdaterer eksisterende maskine
        public void Update(Machine machine)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                // SQL – opdaterer navn og type ud fra maskinens ID
                string query = "UPDATE Machine SET MachineName = @MachineName, MachineType = @MachineType WHERE MachineID = @MachineID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MachineID", machine.MachineID);
                command.Parameters.AddWithValue("@MachineName", machine.MachineName);
                command.Parameters.AddWithValue("@MachineType", machine.MachineType);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // DELETE – sletter maskine ud fra ID
        public void Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Machine WHERE MachineID = @MachineID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MachineID", id);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
