namespace ExpenseTracker_API.Models;
public class GetRoomModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    public RoomStatus Status { get; set; }

    //public int AdminId { get; set; }
    public GetUser Admin { get; set; }
}
