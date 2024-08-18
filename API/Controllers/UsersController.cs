using System.Threading.Tasks;
using API.Data;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace API.Controllers;


[ApiController]
[Route("api/[controller]")] // api/user

    public class UsersController(DataContext context) : ControllerBase

    {

    [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var Users = await context.Users.ToListAsync();
            return Users;
        }

    [HttpGet("{id:int}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null) return NotFound();
            return user;
        }
    }
