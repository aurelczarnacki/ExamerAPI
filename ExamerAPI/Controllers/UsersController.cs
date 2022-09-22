using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ExamerAPI.Data;
using ExamerAPI.Models;
using Microsoft.Data.SqlClient;

namespace ExamerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly ExamerContext _context;

        public UsersController(ExamerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(int id)
        {
            var User = _context.Users.Find(id);

            if (User == null)
            {
                return NotFound();
            }

            return User;
        }

        [HttpPost]
        public ActionResult<User> PostUser(User user)
        {
            user.Role = "user";
            _context.Users.Add(user);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id, role = "user" }, user);
        }

        [HttpPost(template:"Login")]
        public ActionResult<User> Login(User user)
        {

            var temp = _context.Users
                .Where(x => x.Password == user.Password
                && x.Email == user.Email)
                .FirstOrDefault();
            if (temp == null)
            {
                return BadRequest();
            }
            else
            {
                user = temp;
                return Ok(new { user.Role, user.Id, user.Name, user.LastName });
            }

        }


        [HttpPut("{id}")]
        public IActionResult PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Users.Update(user);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var User = _context.Users.Find(id);

            if (User == null)
            {
                return NotFound();
            }

            _context.Users.Remove(User);
            _context.SaveChanges();

            return NoContent();
        }






        private bool UserExists(int id)
        {
          return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
