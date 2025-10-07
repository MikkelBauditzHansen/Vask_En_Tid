using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repository
{
    public class MachineCollectionRepo : IMachineRepository
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
                var command = new SqlCommand("SELECT MachineID, MachineName, MachineType FROM Machine", connection);
                connection.Open();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = (int)reader["MachineID"];
                        string name = reader["MachineName"].ToString();
                        string type = reader["MachineType"].ToString();

                        Machine machine;

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

        public void Add(Machine machine)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("INSERT INTO Machine (MachineName, MachineType) VALUES (@MachineName, @MachineType)", connection);
                command.Parameters.AddWithValue("@MachineName", machine.MachineName);
                command.Parameters.AddWithValue("@MachineType", machine.MachineType);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Update(Machine machine)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("UPDATE Machine SET MachineName = @MachineName, MachineType = @MachineType WHERE MachineID = @MachineID", connection);
                command.Parameters.AddWithValue("@MachineID", machine.MachineID);
                command.Parameters.AddWithValue("@MachineName", machine.MachineName);
                command.Parameters.AddWithValue("@MachineType", machine.MachineType);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var command = new SqlCommand("DELETE FROM Machine WHERE MachineID = @MachineID", connection);
                command.Parameters.AddWithValue("@MachineID", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
