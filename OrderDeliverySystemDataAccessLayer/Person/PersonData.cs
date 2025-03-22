using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace OrderDeliverySystemDataAccessLayer.People
{
    public class DataAccessPersonDTO
    {
        public DataAccessPersonDTO(int PersonId,string FullName,string Email,string PhoneNumber,
                        string BirthDate,int AreaID,string CreatedAt,string UpdatedAt,bool IsDeleted)
        {
            this.PersonID = PersonId;
            this.FullName = FullName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.BirthDate = BirthDate;
            this.AreaID = AreaID;
            this.CreatedAt = CreatedAt;
            this.UpdatedAt = UpdatedAt;
            this.IsDeleted = IsDeleted;
        }

        public DataAccessPersonDTO() { }

        public DataAccessPersonDTO(int personId, string fullName = null, string email = null, string phoneNumber = null,
                         string birthDate = null, int? areaID = null, string createdAt = null,
                         string updatedAt = null, bool? isDeleted = null)
        {
            PersonID = personId;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            AreaID = areaID;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            IsDeleted = isDeleted;
        }

        //---------
        public int PersonID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public int? AreaID { get; set; }
        public string CreatedAt { get; set; }
        public string UpdatedAt { get; set; }
        public bool? IsDeleted { get; set; }

    }

    public class PersonData
    {
        private static readonly string _connectionString = "Server=db16025.public.databaseasp.net; Database=db16025; User Id=db16025; Password=6h@CmG9?#iS5; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True;";

        public static DataAccessPersonDTO Find(int id)
        {
            DataAccessPersonDTO person = null;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_People_GetPersonByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int) { Value = id });

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read()) // التأكد من وجود بيانات
                        {
                            person = new DataAccessPersonDTO(
                              reader.GetInt32(reader.GetOrdinal("PersonID")),
                              reader.GetString(reader.GetOrdinal("FullName")),
                              reader.GetString(reader.GetOrdinal("Email")),
                              reader.GetString(reader.GetOrdinal("PhoneNumber")),
                              reader.GetDateTime(reader.GetOrdinal("BirthDate")).ToString("yyyy-MM-dd HH:mm:ss"),
                              reader.GetInt32(reader.GetOrdinal("AreaID")),
                              reader.GetDateTime(reader.GetOrdinal("CreatedAt")).ToString("yyyy-MM-dd HH:mm:ss"),
                              reader.GetDateTime(reader.GetOrdinal("UpdatedAt")).ToString("yyyy-MM-dd HH:mm:ss"),
                              reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                            );
                        }
                    }
                }
            }

            return person;
        }

        public static List<DataAccessPersonDTO> FindAll()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
               
                    using(SqlCommand cmd = new SqlCommand("SP_People_GetAllPeople",conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                       
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                        List<DataAccessPersonDTO> People = new List<DataAccessPersonDTO>();
                            while (reader.Read())
                                {
                           
                                var person = new DataAccessPersonDTO
                                (
                                    reader.GetInt32(reader.GetOrdinal("PersonID")),
                                    reader.GetString(reader.GetOrdinal("FullName")),
                                    reader.GetString(reader.GetOrdinal("Email")),
                                    reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                    reader.GetDateTime(reader.GetOrdinal("BirthDate")).ToString("yyyy-MM-dd HH:mm:ss"),
                                    reader.GetInt32(reader.GetOrdinal("AreaID")),
                                    reader.GetDateTime(reader.GetOrdinal("CreatedAt")).ToString("yyyy-MM-dd HH:mm:ss"),
                                    reader.GetDateTime(reader.GetOrdinal("UpdatedAt")).ToString("yyyy-MM-dd HH:mm:ss"),
                                    reader.GetBoolean(reader.GetOrdinal("IsDeleted"))
                                 );

                            People.Add(person);
                             
                            }
                        return People;

                    }
                    }
                return null;
            }
        }

        public static int DeletePerson(int id)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {

                using (SqlCommand cmd = new SqlCommand("SP_People_DeletePersonByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PersonID", id);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    return RowsAffected;
                }
            }
        }

        public static int UpdatePerson(DataAccessPersonDTO Person)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_People_UpdatePersonByID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("PersonID", Person.PersonID);
                    cmd.Parameters.AddWithValue("NewFullName", Person.FullName);
                    cmd.Parameters.AddWithValue("NewEmail", Person.Email);
                    cmd.Parameters.AddWithValue("NewPhoneNumber", Person.PhoneNumber);
                    cmd.Parameters.AddWithValue("NewBirthDate", Person.BirthDate);
                    cmd.Parameters.AddWithValue("NewAreaID", Person.AreaID);
                    conn.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();

                    return RowsAffected;
                }
            }
        }

        public static int AddNewPerson(DataAccessPersonDTO NewPerson)
        {
            using(SqlConnection conn = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SP_People_AddNewPerson", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    cmd.Parameters.AddWithValue("FullName", NewPerson.FullName);
                    cmd.Parameters.AddWithValue("Email", NewPerson.Email);
                    cmd.Parameters.AddWithValue("PhoneNumber", NewPerson.PhoneNumber);
                    cmd.Parameters.AddWithValue("BirthDate", NewPerson.BirthDate);
                    cmd.Parameters.AddWithValue("AreaID",NewPerson.AreaID);

                    SqlParameter outputParam = new SqlParameter("@PersonID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    // تنفيذ الإجراء المخزن
                    cmd.ExecuteNonQuery();

                    // استرجاع PersonID
                    int PersonID = (int)outputParam.Value;

                    return PersonID; // 
                }
            }
        }
    }
}
