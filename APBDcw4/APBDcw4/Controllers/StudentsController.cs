using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using APBDcw4.Models;
using APBDcw4.Services;
using Microsoft.AspNetCore.Mvc;

namespace APBDcw4.Controllers
{
    [ApiController]
    [Route("api/students")]
    public class StudentsController : ControllerBase
    {

        private readonly IStudentsDal _dbService;

        //public StudentsController(IStudentsDal dbService)
        //{
        ///    _dbService = dbService;
        //}


        [HttpGet("id")]
        public IActionResult GetStudents()//[FromServices] IStudentsDal dbService)
        {
            var list = new List<Student>();

            using (SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18705;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from student";

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    var st = new Student();
                    st.IdStudent = int.Parse(dr["IdStudent"].ToString());
                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    st.BirthDate = dr["BirthDate"].ToString();
                    st.IdEnrollment = int.Parse(dr["IdEnrollment"].ToString());
                    list.Add(st);
                }
            }
             return Ok(list);
        }


        public IActionResult GetEnrollment(string idStudenta)
        {
            var list = new List<Enrollment>();

            using (SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18705;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Enrollment where IdEnrollment = (select IdEnrollment from Student where Student.IndexNumber='@index')";

                SqlParameter par = new SqlParameter();
                par.Value = idStudenta;
                par.ParameterName = "index";
                com.Parameters.Add(par);

                con.Open();
                SqlDataReader dr = com.ExecuteReader();

                while (dr.Read())
                {
                    var en = new Enrollment();
                    en.IdEnrollment = int.Parse(dr["IdEnrollment"].ToString());
                    en.Semester = int.Parse(dr["Semesrt"].ToString());
                    en.StartDate = dr["StartDate"].ToString();
                    en.IdStudy = int.Parse(dr["IdStudy"].ToString());
                    list.Add(en);
                }
            }
            return Ok(list);
        }


        /*
        [HttpGet("{indexNumber}")]
        public IActionResult GetStudent(string indexNumber)
        {
            using (SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18705;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from student where indexnumber = @index";

                SqlParameter par = new SqlParameter();
                par.Value = indexNumber;
                par.ParameterName = "index";
                com.Parameters.Add(par);

                con.Open();
                var dr = com.ExecuteReader();
                if (dr.Read())
                {
                    var st = new Student();

                    
                    //if(dr["IndexNumber"] == DBNull.Value)
                    //{

                    //}
                    

                    st.IndexNumber = dr["IndexNumber"].ToString();
                    st.FirstName = dr["FirstName"].ToString();
                    st.LastName = dr["LastName"].ToString();
                    return Ok(st);
                }
            }
            return NotFound();
        }


        [HttpGet("ex2")]
        public IActionResult GetStudents2()
        {

            using (SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18705;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "TestProc3";
                com.CommandType = System.Data.CommandType.StoredProcedure;

                com.Parameters.AddWithValue("Lastname", "Kowalksi");
                var dr = com.ExecuteReader();
                

                  if (dr.Read())
                    {
                        var st = new Student();

                    
                         //if(dr["IndexNumber"] == DBNull.Value)
                        //{

                        //}
                    

                        st.IndexNumber = dr["IndexNumber"].ToString();
                        st.FirstName = dr["FirstName"].ToString();
                        st.LastName = dr["LastName"].ToString();
                        return Ok(st);
                    }


            }

            return NotFound();
        }



        [HttpGet("ex3")]
        public IActionResult GetStudents3()
        {

            using (SqlConnection con = new SqlConnection("Data Source=db-mssql;Initial Catalog=s18705;Integrated Security=True"))
            using (SqlCommand com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "insert into studnts(FirstName) VALUES (@firstName)";



                con.Open();
                SqlTransaction trans = con.BeginTransaction();


                try
                {
                    int affectedRows = com.ExecuteNonQuery();

                    com.CommandText = "update into ...";
                    com.ExecuteNonQuery();

                    trans.Commit();
                }
                catch(Exception ex)
                {
                    trans.Rollback();
                }

            }

            return Ok();
        }
        */
    }
}
