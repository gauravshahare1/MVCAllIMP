

using System.Data.SqlClient;
using System.Data;

namespace ValidationDemo.Models
{
    public class StudentDB
    {
        string _connectionString = null;
        public StudentDB(string connectionString) 
        { 
            _connectionString = connectionString;
        }
        public List<StudentModel> Students()
        {
            List<StudentModel> students = new List<StudentModel>();
            SqlConnection con = new SqlConnection(_connectionString);
            try
            {
                
                string commandText = "usp_AllStudents";
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        students.Add(new StudentModel()
                        {
                            Rollnumber = reader.GetInt32("RollNumber"),
                            Name = reader.GetString("Name"),
                            Gender = reader.GetString("Gender"),
                            Mobile = reader.GetString("Mobile"),
                            Email= reader.GetString("Email"),
                            Age = reader.GetInt32("Age"),
                            Password= !reader.IsDBNull("Password")? reader.GetString("Password"): "No Password",
                            AdmissionDate= !reader.IsDBNull("AdmissionDate")? reader.GetDateTime("AdmissionDate"): DateTime.Parse("01/01/0001"),
                        });
                    }
                }

               
            }
            catch (Exception ex)
            {

            }

            finally
            {
                if(con != null)
                    con.Close();
            }
            return students;
        }

        public StudentModel StudentByRollNumber(int rollNumber)
        {
            StudentModel student = new StudentModel();
            SqlConnection con = new SqlConnection(_connectionString);
            try
            {

                string commandText = "usp_StudentByRollnumber";
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RollNumber", rollNumber);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        student=  new StudentModel()
                        {
                            Rollnumber = reader.GetInt32("RollNumber"),
                            Name = reader.GetString("Name"),
                            Gender = reader.GetString("Gender"),
                            Mobile = reader.GetString("Mobile"),
                            Age = reader.GetInt32("Age")
                        };
                        break;
                    }
                }

            }
            catch (Exception ex)
            {

            }

            finally
            {
                if (con != null)
                    con.Close();
            }
            return student;
        }

        public bool Insert(StudentModel student)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            try
            {

                string commandText = "usp_InsertStudent";
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Age", student.Age);
                cmd.Parameters.AddWithValue("@Password", student.Password);
                cmd.Parameters.AddWithValue("@AdmissionDate", student.AdmissionDate);

                SqlParameter status = new SqlParameter() 
                {
                ParameterName = "@Status",
                SqlDbType = SqlDbType.Bit,
                Direction= ParameterDirection.Output
                };
                cmd.Parameters.Add(status);

                con.Open();
                int row = cmd.ExecuteNonQuery();
                return (bool)status.Value;
               
            }
            catch (Exception ex)
            {

            }

            finally
            {
                if (con != null)
                    con.Close();
            }
            return false;
        }

        public bool Update(StudentModel student)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            try
            {

                string commandText = "usp_UpdateStudent";
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RollNumber", student.Rollnumber);
                cmd.Parameters.AddWithValue("@Name", student.Name);
                cmd.Parameters.AddWithValue("@Gender", student.Gender);
                cmd.Parameters.AddWithValue("@Mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@Email", student.Email);
                cmd.Parameters.AddWithValue("@Age", student.Age);

                SqlParameter status = new SqlParameter()
                {
                    ParameterName = "@Status",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(status);

                con.Open();
                int row = cmd.ExecuteNonQuery();
                return (bool)status.Value;

            }
            catch (Exception ex)
            {

            }

            finally
            {
                if (con != null)
                    con.Close();
            }
            return false;
        }

        public bool Delete(int rollnumber)
        {
            SqlConnection con = new SqlConnection(_connectionString);
            try
            {

                string commandText = "usp_DeleteStudent";
                SqlCommand cmd = new SqlCommand(commandText, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@RollNumber", rollnumber);
               
                SqlParameter status = new SqlParameter()
                {
                    ParameterName = "@Status",
                    SqlDbType = SqlDbType.Bit,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(status);

                con.Open();
                int row = cmd.ExecuteNonQuery();
                return (bool)status.Value;

            }
            catch (Exception ex)
            {

            }

            finally
            {
                if (con != null)
                    con.Close();
            }
            return false;
        }
    }
}
