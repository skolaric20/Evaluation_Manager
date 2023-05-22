using DBLayer;
using Evaluation_Manager.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluation_Manager.Repositories
{
    public static class StudentRepository
    {
        public static Student GetStudent(int id)
        {
            Student student = null;

            DB.OpenConnection();

            var dr = DB.GetDataReader($"SELECT * FROM Students WHERE Id = {id}");

            if (dr.HasRows)
            {
                dr.Read();
                student = CreateObject(dr);
            }

            DB.CloseConnection();

            return student;
        }

        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();

            DB.OpenConnection();

            var dr = DB.GetDataReader($"SELECT * FROM Students");

            while (dr.Read())
            {
                Student student = CreateObject(dr);
                students.Add(student);
            }

            DB.CloseConnection();

            return students;
        }

        private static Student CreateObject(SqlDataReader dr)
        {
            return new Student()
            {
                Id = int.Parse(dr["Id"].ToString()),
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString()
            };
        }
    }
}
