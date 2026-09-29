using CRUDAppUsingADO.Models;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.Data;
using System.Data.SqlClient;


namespace CRUDAppUsingADO
{
    public class EmployeeDataAccessLayer : IEmployeeRepository
    {
        private readonly string _connectionString;

        public EmployeeDataAccessLayer(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<Employee> GetAllEmployee()
        {

            List<Employee> employees = new List<Employee>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetAllEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Employee employee = new Employee();
                    employee.Id = reader.GetInt32(0);
                    employee.Name = reader.GetString(1);
                    employee.Gender = reader.GetString(2);
                    employee.Age = reader.GetInt32(3);
                    employee.Designation = reader.GetString(4);
                    employee.City = reader.GetString(5);
                    employees.Add(employee);
                }
            }

            return employees;
        }

        public Employee GetEmployeeById(int? Id)
        {
            Employee employee = new Employee();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("GetEmployeeById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    employee.Id = reader.GetInt32(0);
                    employee.Name = reader.GetString(1);
                    employee.Gender = reader.GetString(2);
                    employee.Age = reader.GetInt32(3);
                    employee.Designation = reader.GetString(4);
                    employee.City = reader.GetString(5);
                }
            }

            return employee;
        }

        public void AddEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("InsertEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                cmd.Parameters.AddWithValue("@City", employee.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void UpdateEmployee(Employee employee)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", employee.Id);
                cmd.Parameters.AddWithValue("@Name", employee.Name);
                cmd.Parameters.AddWithValue("@Gender", employee.Gender);
                cmd.Parameters.AddWithValue("@Age", employee.Age);
                cmd.Parameters.AddWithValue("@Designation", employee.Designation);
                cmd.Parameters.AddWithValue("@City", employee.City);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public void DeleteEmployee(int? Id)
        {

            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", Id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();               
            }
            
        }

    }
}
