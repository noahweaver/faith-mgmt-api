using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FaithMgmtAPI.Models;
using FaithMgmtAPI.Data;

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

        // GET: api/member/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Member>> GetMember(int id)
        {
            var member = await _context.Members_Table.FindAsync(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // POST
        [HttpPost]
        //[Route("AddMember")]
        public async Task<ActionResult<List<Member>>> AddMember(Member member)
        {
            //Will add to the context but not store in the db, must save changes
            _context.Members_Table.Add(member);
            //Save changes to the db
            await _context.SaveChangesAsync();

            return Ok(await GetAllMembers());
            //if I want to return only the new member instead of all members
            //return CreatedAtAction("GetMember", new { id = member.Id }, member);
        }

        //DELETE
        // currently not working because of constraint from Prayer_Requests_Table
        [HttpDelete]
        [Route("DeleteMember/{id}")]

        public async Task<ActionResult<Member>> DeleteMember(int id)
        {
            var member = await _context.Members_Table.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }

            _context.Members_Table.Remove(member);
            await _context.SaveChangesAsync();

            return Ok(member);
        }
    }
}
