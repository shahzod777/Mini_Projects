namespace ExpenseTracker_API.Models;
public class GetRoomListModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    public RoomStatus Status { get; set; }
}
