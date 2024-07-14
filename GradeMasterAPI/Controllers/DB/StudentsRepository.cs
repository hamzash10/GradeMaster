using GradeMasterAPI.Controllers.DB.DBModels;
using System.Data.SqlClient;

namespace GradeMasterAPI.Controllers.DB
{
    public class StudentsRepository
    {
        private readonly string _connectionString;

        public StudentsRepository(string connectionString)
        {
            _connectionString=connectionString;
        }

        public StudentsRepository()
        {
            _connectionString = "Data Source=HAMZASH\\SQLEXPRESS;Initial Catalog=GradeMAsterDB;Integrated Security=True;Connect Timeout=30";
        }

        public async Task<string> InsertStudentAsync(Student student)
        {
            string errors = "";
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    string query = "INSERT INTO Students (FirstName, LastName, DateBirth, Gender, PoneNumber, Adress, Email, EnrollmentDate) " +
                                   "VALUES (@FirstName, @LastName, @DateBirth, @Gender, @PoneNumber, @Adress, @Email, @EnrollmentDate)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", student.LastName);
                        cmd.Parameters.AddWithValue("@DateBirth", student.DateBirth);
                        cmd.Parameters.AddWithValue("@Gender", student.Gender);
                        cmd.Parameters.AddWithValue("@Adress", student.Address);
                        cmd.Parameters.AddWithValue("@PoneNumber", student.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", student.Email);
                        cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);

                        await conn.OpenAsync();
                        int affectedRows = await cmd.ExecuteNonQueryAsync();
                        if (affectedRows == 0)
                            errors = " insert not commited";
                    }
                }
            }
            catch(Exception ex)
            {
                errors = "exception: "+ex.Message;
              
            }
            return errors;
        }

        public void UpdateStudent(int id,Student student)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Students SET " +
                               "FirstName = @FirstName, " +
                               "LastName = @LastName, " +
                               "DateBirth = @DateBirth, " +
                               "Gender = @Gender, " +
                               "PoneNumber = @PoneNumber, " +
                               "Adress = @Adress, " +
                               "Email = @Email, " +
                               "EnrollmentDate = @EnrollmentDate " +
                               "WHERE Id = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", student.LastName);
                    cmd.Parameters.AddWithValue("@DateBirth", student.DateBirth);
                    cmd.Parameters.AddWithValue("@Gender", student.Gender);
                    cmd.Parameters.AddWithValue("@Adress", student.Address);
                    cmd.Parameters.AddWithValue("@PoneNumber", student.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
                    cmd.Parameters.AddWithValue("@Id", id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM students", conn);
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        students.Add(new Student
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1) ,
                            LastName = reader.GetString(2),
                            DateBirth = reader.GetDateTime(3),
                            Gender = reader.GetString(4),
                            PhoneNumber = reader.GetString(5),
                            Address = reader.GetString(6),
                            Email = reader.GetString(7),
                            EnrollmentDate= reader.GetDateTime(8),

                        });

                    }
                }
            }
            return students;
        }

        public Student? GetStudent(int Id)
        {
            Student student = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var command = new SqlCommand("SELECT * FROM students WHERE Id = @Id", conn);
                command.Parameters.AddWithValue("@Id", Id);
                using(var reader = command.ExecuteReader())
                {
                    if(reader.Read()){
                        student = new Student
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            DateBirth = reader.GetDateTime(3),
                            Gender = reader.GetString(4),
                            PhoneNumber = reader.GetString(5),
                            Address = reader.GetString(6),
                            Email = reader.GetString(7),
                            EnrollmentDate = reader.GetDateTime(8),

                        };
                    }

                }
            }
            return student;
        }

    }
}
