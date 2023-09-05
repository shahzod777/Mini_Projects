using ExpenseTracker_API.Data;
using ExpenseTracker_API.Helpers;
using ExpenseTracker_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public partial class RoomsController : ControllerBase
{
    public readonly ExpensesDbContext _context;
    public RoomsController(ExpensesDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetRooms()
    {
        var rooms = _context.Rooms.Include(r => r.Admin).ToList().Select(room => ConvertToRoomModel(room)).ToList();

        return Ok(rooms);
    }

    [HttpPost]
    public IActionResult AddRoom(CreateRoomModel createRoomModel)
    {
        var room = new Room
        {
            Name = createRoomModel.Name,
            Status = RoomStatus.Created,
            Key = RandomGenerator.GetRandomString(),
            AdminId = 1, // user's id when he is gonna login
        };

        _context.Rooms.Add(room);
        _context.SaveChanges();

        return Ok(ConvertToRoomModel(room));
    }

    [HttpGet("{id}")]
    public IActionResult GetRoomById(int id)
    {
        //! ef core  then also returns admin id when it birings us an admin prop => 
        var room = _context.Rooms.Include(r => r.Admin).FirstOrDefault(room => room.Id == id);

        if (room is null)
        {
            return NotFound();
        }
        //! here we are assigning the values that was gotten from the room class to the getroom
        //! class that's gonna return a single room 
        var user = _context.Users?.FirstOrDefault(u => u.Id == room.AdminId);
        
        var getRoomModel = ConvertToRoomModel(room);
        getRoomModel.Admin = ConvertToUserModel(user!);

        return Ok(getRoomModel);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRoom(int id, UpdateRoom updateRoom)
    {
        var room = _context.Rooms.FirstOrDefault(room => room.Id == id);

        if (room is null)
        {
            return NotFound();
        }

        room.Name = updateRoom.Name;
        room.Status = updateRoom.Status;

        _context.Rooms.Add(room);
        _context.SaveChanges();
        return Ok(ConvertToRoomModel(room));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRoom(int id)
    {
        var room = _context.Rooms.FirstOrDefault(room => room.Id == id);

        if (room is null)
        {
            return NotFound();
        }

        _context.Rooms.Remove(room);
        _context.SaveChanges();
        return Ok(room);
    }

    private GetRoomModel ConvertToRoomModel(Room room)
    {
        return new GetRoomModel()
        {
            Id = room.Id,
            Name = room.Name,
            Key = room.Key,
            Status = room.Status,
            Admin = ConvertToUserModel(room.Admin),
        };
    }

    private GetUser? ConvertToUserModel(User user)
    {
        if (user is null)
            return null;

        return new GetUser
        {
            Id = user.Id,
            Name = user.Name,
        };
    }

    [HttpGet("{id}/users")]
    public IActionResult GetRoomUsers(int id)
    {
        var room = _context.Rooms.Include(r => r.Users)
            .FirstOrDefault(r => r.Id == id);

        return Ok(room.Users);
    }
}


