namespace ExpenseTracker_API.Models;
public class CreateOutlayModel
{
    public string Description { get; set; }
    public int Cost { get; set; }
    public int UserId { get; set; }
}
