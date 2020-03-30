using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using APBDcw4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APBDcw4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
       public IActionResult Get()
        {
            SqlConnection con = new SqlConnection("Data Source = bd-mssql;Initial Catalog=S18705;Integrated Security=True");

            //using(var client = new SqlConnection("[CONNECTION STRING]"))
            //{
            //
            //}

            using(var com = new SqlCommand())
            {
                com.Connection = con;
                com.CommandText = "select * from Students ....";

                con.Open();
                var dr = com.ExecuteReader();
                while(dr.Read())
                {
                    var st = new Student();
                    st.FirstName = dr["FirstName"].ToString();
                    //...
                }
            }

            //SqlCommand com;
            return Ok();
        }
    }
}