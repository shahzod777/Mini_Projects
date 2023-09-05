using ExpenseTracker_API.Data;
using ExpenseTracker_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public readonly ExpensesDbContext _context;
        public UsersController(ExpensesDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete]
        public IActionResult DeleteUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user is null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            _context.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public User AddUser(User user)
        {
            var newUser = new User()
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                CreatedDate = DateTime.Now,
            };

            _context.Add(newUser);
            _context.SaveChanges();
            return newUser;
        }

        [HttpGet]
        public List<User> GetUsers()
        {
            var users = _context.Users!.ToList();
            return users;
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id,User newUser)
        {
           var user = _context.Users?.FirstOrDefault(u => u.Id == id);

            if(user is null)
            {
                return NotFound();
            }

            user.Name = newUser.Name;
            user.Email = newUser.Email;
            user.Phone = newUser.Phone; 
            user.CreatedDate = DateTime.Now;
            _context.SaveChanges();
            return Ok(user);
        }

        [HttpPost("join-room/{roomId}")]
        public IActionResult JoinRoom(int roomId,string key,int userId)
        {
            //int userId = 2;

            var room = _context.Rooms.FirstOrDefault(r => r.Id == roomId);

            if (room is null || room.Key != key)
                return NotFound();

            var user = _context.Users.FirstOrDefault(u => u.Id == userId);

            user.RoomId = roomId;
            _context.SaveChanges();
            return Ok(user);
        }
    }
}