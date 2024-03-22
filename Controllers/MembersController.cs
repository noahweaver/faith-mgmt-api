using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
using MySqlConnector;
using FaithMgmtAPI.Models;
using FaithMgmtAPI.Data;
using NuGet.Protocol;


namespace FaithMgmtAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {

        private readonly FaithMgmtContext _context;

        public MemberController(FaithMgmtContext context)
        {
            _context = context;
        }


        // GET: api/all-members
        [HttpGet]
        [Route("all-members")]

        public async Task<ActionResult<List<Member>>> GetAllMembers()
        {
            var members = await _context.Members_Table.ToListAsync();
            return Ok(members);
        }

    }
}
