using Dapper;
using Microsoft.VisualBasic;
using NetGroupHomeTask.Interfaces;
using NetGroupHomeTask.Models;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace NetGroupHomeTask.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly string _connectionString;
        private readonly IConfiguration _configuration;

        public EventRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration["ConnectionStrings:DefaultConnection"];
        }

        public IEnumerable<Event> GetAllEvents()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            return sqlConnection.Query<Event>("SELECT * FROM Events");
        }

        public void AddEvent(Event newEvent)
        {
            string query = "INSERT INTO Events (Name, DateAndTime, MaxAudienceNumber) VALUES (@Name, @DateAndTime, @MaxAudienceNumber)";

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", newEvent.Name);
                    command.Parameters.AddWithValue("@DateAndTime", newEvent.DateAndTime);
                    command.Parameters.AddWithValue("@MaxAudienceNumber", newEvent.MaxAudienceNumber);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public Event GetEvent(int id)
        {
            using IDbConnection db = new SqlConnection(_connectionString);
            return (Event)db.Query<Event>(@"SELECT * FROM Events WHERE Id = @id", new
            {
                id
            });
        }

        public void RegisterToEvent(int id)
        {
            var theEvent = GetEvent(id);
        }
    }
}
