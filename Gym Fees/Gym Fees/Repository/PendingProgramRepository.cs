using Gym_Fees.Entity;
using Gym_Fees.IRepo;
using Gym_Fees.Service;
using Microsoft.Data.SqlClient;
using static Gym_Fees.Repository.PendingProgramRepository;

namespace Gym_Fees.Repository
{
   
        public class PendingProgramRepository : IPendingProgramRepo
        {
       
            private readonly string _connectionString;

            public PendingProgramRepository(string connectionString)
            {
                _connectionString = connectionString;
            }

            public async Task<List<Pendingprogram>> GetAllPendingProgramsAsync()
            {
                var pendingPrograms = new List<Pendingprogram>();
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("SELECT * FROM PendingPrograms", connection);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            pendingPrograms.Add(new Pendingprogram
                            {
                                PendingprogramId = reader.GetGuid(0),
                                TrainingId = reader.GetGuid(1),
                                MemberId = reader.GetGuid(2),
                                Cardio = reader.GetString(3),
                                Weighttraining = reader.GetString(4)
                            });
                        }
                    }
                }
                return pendingPrograms;
            }

            public async Task<Pendingprogram> GetPendingProgramByIdAsync(Guid id)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("SELECT * FROM PendingPrograms WHERE PendingprogramId = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Pendingprogram
                            {
                                PendingprogramId = reader.GetGuid(0),
                                TrainingId = reader.GetGuid(1),
                                MemberId = reader.GetGuid(2),
                                Cardio = reader.GetString(3),
                                Weighttraining = reader.GetString(4)
                            };
                        }
                    }
                }
                return null;
            }

            public async Task AddPendingProgramAsync(Pendingprogram pendingProgram)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand(
                        "INSERT INTO PendingPrograms (PendingprogramId, TrainingId, MemberId, Cardio, Weighttraining) " +
                        "VALUES (@PendingprogramId, @TrainingId, @MemberId, @Cardio, @Weighttraining)", connection);
                    command.Parameters.AddWithValue("@PendingprogramId", pendingProgram.PendingprogramId);
                    command.Parameters.AddWithValue("@TrainingId", pendingProgram.TrainingId);
                    command.Parameters.AddWithValue("@MemberId", pendingProgram.MemberId);
                    command.Parameters.AddWithValue("@Cardio", pendingProgram.Cardio);
                    command.Parameters.AddWithValue("@Weighttraining", pendingProgram.Weighttraining);
                    await command.ExecuteNonQueryAsync();
                }
            }

            public async Task DeletePendingProgramAsync(Guid id)
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();
                    var command = new SqlCommand("DELETE FROM PendingPrograms WHERE PendingprogramId = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

    }





