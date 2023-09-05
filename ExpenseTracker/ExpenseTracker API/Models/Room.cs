using ExpenseTracker_API.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker_API.Models;
public class Room
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Key { get; set; }
    public RoomStatus Status { get; set; }
    public int AdminId { get; set; }

    [ForeignKey("AdminId")] //! => this means that when we are trying to invoke admin ef gets the admin depending on it's id
    [NotMapped]
    public User Admin { get; set; }
    [NotMapped]
    public List<User> Users { get; set; }
    [NotMapped]
    public List<Outlay> Outlays { get; set; }
    
}
