namespace ExpenseTracker_API.Models;
public class CalculateRoomOutlays
{
    public int UsersCount { get; set; }
    public int TotalCost { get; set; }
    public int CostPerPerson
        =>  TotalCost / UsersCount;
}
