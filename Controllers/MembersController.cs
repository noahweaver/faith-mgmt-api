using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using MySqlConnector;


namespace FaithMgmtAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private IConfiguration _config;
        public MemberController(IConfiguration config)
        {
            _config = config;
        }

        // GET: api/Members
        [HttpGet]
        [Route("all_members")]
        public JsonResult GetMembers()
        {
            string query = "SELECT * FROM `faith-mgmt-db`.members_table";
            DataTable table = new DataTable();

            string sqlDataSource = _config.GetConnectionString("FaithMgmt");
            MySqlDataReader myReader;

            using (MySqlConnection mySqlConn = new MySqlConnection(sqlDataSource))
            {
                mySqlConn.Open();
                using (MySqlCommand mySqlCmd = new MySqlCommand(query, mySqlConn))
                {
                    myReader = mySqlCmd.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    mySqlConn.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}
