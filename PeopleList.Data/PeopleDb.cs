using System.Collections.Generic;
using System.Data.SqlClient;

namespace PeopleList.Data
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class PeopleDb
    {
        private readonly string _connectionString;

        public PeopleDb(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddPeople(List<Person> ppl)
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = conn.CreateCommand();
            conn.Open();
            //cmd.Parameters.Clear();
            foreach (Person person in ppl)
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "INSERT INTO People " +
                    "VALUES (@firstName, @lastName, @age)";
                cmd.Parameters.AddWithValue("@firstName", person.FirstName);
                cmd.Parameters.AddWithValue("@lastName", person.LastName);
                cmd.Parameters.AddWithValue("@age", person.Age);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Person> GetAllPeople()
        {
            using var conn = new SqlConnection(_connectionString);
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";
            conn.Open();
            var results = new List<Person>();
            var reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                results.Add(new Person
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });

            }
            return results;
        }
    }
}
