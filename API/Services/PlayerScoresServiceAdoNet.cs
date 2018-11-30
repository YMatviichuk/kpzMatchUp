using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using API.Contracts;
using API.DbContext;
using API.Models;

namespace API.Services
{
    public class PlayerScoresServiceAdoNet : IPlayerScoresService
    {
        private readonly string ConnectionString = "Data Source=.;Initial Catalog=matchUpDb;Integrated Security=True;";
            

        public List<PlayerScore> GetPlayerScores()
        {
            List<PlayerScore> resultList = new List<PlayerScore>();
            
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM matchUpDb";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            resultList.Add(new PlayerScore
                            {
                                Id = (int)reader["Id"],
                                Date = (DateTime)reader["Date"],
                                Score = (int)reader["Score"]
                            });
                        }
                    }
                }
            }

            return resultList;
        }

        public PlayerScore GetPlayerScore(int id)
        {
            PlayerScore instance;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "SELECT * FROM matchUpDb WHERE Id= \'" + id + "\'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        reader.Read();
                        instance = new PlayerScore
                        {
                            Id = (int)reader["Id"],
                            Date = (DateTime)reader["Date"],
                            Score = (int)reader["Score"]
                        };
                    }
                }
            }

            return instance;
        }

        public bool UpdatePlayerScore(int id, PlayerScore playerScore)
        {
            int result;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $"UPDATE matchUpDb SET Score={playerScore.Score}, Date={playerScore.Date}, Player_Id={playerScore.Player.Id}  WHERE Id='{id}'";
                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery();
                connection.Close();
            }

            return result > 0;
        }

        public void InsertPlayerScore(PlayerScore playerScore)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $"INSERT INTO matchUpDb VALUES({playerScore.Score},{playerScore.Date},{playerScore.Player.Id})";
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public bool DeletePlayerScore(int id)
        {
            int result;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $"DELETE FROM matchUpDb WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery();
                connection.Close();
            }

            return result > 0;
        }

        public bool PlayerScoreExists(int id)
        {
            int result;
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = $"SELECT * FROM matchUpDb WHERE Id = {id}";
                SqlCommand command = new SqlCommand(query, connection);
                result = command.ExecuteNonQuery();
                connection.Close();
            }

            return result > 0;
        }
    }
}