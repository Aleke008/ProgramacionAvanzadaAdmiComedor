using AdmiComedor.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace AdmiComedor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EscuelasController : ControllerBase
    {
        private readonly string connectionString;
        public EscuelasController(IConfiguration configuration) 
        {
            connectionString = configuration["ConnectionStrings: SqlServerDb"] ?? "";
        }

        [HttpPost]
        public IActionResult CreateEscuelas(Escueladto escuelasdto) 
        {
            try 
            {
                using (var connection = new SqlConnection(connectionString)) 
                {
                    connection.Open();

                    string sql = "INSERT INTO escuelas " +
                        "(nombreEscuela, estado) VALUES" +
                        "(@nombreEscuela, @estado)";

                    using (var command = new SqlCommand(sql, connection)) 
                    {
                        command.Parameters.AddWithValue("@nombreEscuela", escuelasdto.NombreEscuela);
                        command.Parameters.AddWithValue("@estado", escuelasdto.Estado);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("Escuela", "Lo lamentamos, pero tenemos una excepción");
                return BadRequest(ModelState);
            }

            return Ok();
        }
    }
}
