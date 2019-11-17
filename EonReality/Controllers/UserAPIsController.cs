using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EonReality.Models;

namespace EonReality.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAPIsController : ControllerBase
    {
        private readonly UserContext _context;

        public UserAPIsController(UserContext context)
        {
            _context = context;
        }

        // GET: api/UserAPIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAPI>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/UserAPIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserAPI>> GetUserAPI(long id)
        {
            var userAPI = await _context.Users.FindAsync(id);

            if (userAPI == null)
            {
                return NotFound();
            }

            return userAPI;
        }

        // PUT: api/UserAPIs/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAPI(long id, UserAPI userAPI)
        {
            if (id != userAPI.Id)
            {
                return BadRequest();
            }

            _context.Entry(userAPI).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAPIExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserAPIs
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<UserAPI>> PostUserAPI(UserAPI userAPI)
        {
            _context.Users.Add(userAPI);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserAPI), new { id = userAPI.Id }, userAPI); 
        }

        // DELETE: api/UserAPIs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserAPI>> DeleteUserAPI(long id)
        {
            var userAPI = await _context.Users.FindAsync(id);
            if (userAPI == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userAPI);
            await _context.SaveChangesAsync();

            return userAPI;
        }

        private bool UserAPIExists(long id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
