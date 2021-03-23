using System;
using System.Collections.Generic;
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
        public interface IRepository
        {
            public void Create(Person person);
            public Person Get(int id);
            public List<Person> GetPeople();
            public void Update(Person person);
            public void Delete(int id);
        }
        public class PeopleRepository : IRepository
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
                throw new NotImplementedException();
            }

            public List<Person> GetPeople()
            {
                throw new NotImplementedException();
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
