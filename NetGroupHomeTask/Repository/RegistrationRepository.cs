using Microsoft.Extensions.Configuration;
using NetGroupHomeTask.Interfaces;
using NetGroupHomeTask.Models;
using System.Data.SqlClient;

namespace NetGroupHomeTask.Repository
{
    public class RegistrationRepository : IRegistrationRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public RegistrationRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        }
        public void Register(User user)
        {
            string query = "INSERT INTO Users (FirstName, LastName, IdentityCode) VALUES (@FirstName, @LastName, @IdentityCode)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@IdentityCode", user.IdentityCode);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
