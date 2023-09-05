namespace ExpenseTracker_API.Models;
public class CreateRoomModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    public RoomStatus Status { get; set; }
}
