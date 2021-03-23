using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;

namespace HomeworkLesson18
{
    class Program
    {
        private const string ConString =
            @"Data Source=NASIBANOSIROVA\SQLEXPRESS; Initial Catalog=Person; Integrated Security=True";
        static void Main(string[] args)
        {
        }
        public class Person
        {
            public int Id { get; set; }
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleName { get; set; }
            public DateTime BirthDate { get; set; }
        }
        public class PeopleRepository
        {
            public void Create(Person person)
            {
                using (var conn = new SqlConnection(ConString))
                {
                    var sql = @"INSERT INTO PEOPLE (LastName, FirstName, MiddleName, BirtDate) 
                    VALUES (@LastName, @FirstName, @MiddleName, @BirthDate)";
                    conn.Execute(sql, person);
                }
            }
            public Person Get(int id)
            {
                using (var conn = new SqlConnection(ConString))
                {
                    return conn.Query<Person>($"SELECT * FROM PEOPLE WHERE Id={id}").FirstOrDefault();
                }
            }

            public List<Person> GetPeople()
            {
                using (var conn = new SqlConnection(ConString))
                {
                    return conn.Query<Person>("SELECT * FROM PEOPLE").ToList();
                }
            }

            public void Update(Person person)
            {
                throw new NotImplementedException();
            }

            public void Delete(int id)
            {
                throw new NotImplementedException();
            }
        }
    }
}
