namespace ExpenseTracker_API.Models;
public class User
{
    public int Id { get; set; }
    public string?  Name { get; set; }
    public string? Email { get; set; }
    public string?  Phone { get; set; }
    public DateTime CreatedDate { get; set; }
    public  int RoomId { get; set; }
}
