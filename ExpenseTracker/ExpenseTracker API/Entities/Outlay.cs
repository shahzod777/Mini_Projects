using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTracker_API.Entities;

[Table("users_outlays")]
public class Outlay
{
    public int Id { get; set; }

    [Required]
    [MaxLength(30)]
    public string? Description { get; set; }
    public int Cost { get; set; }
    public int UserId { get; set; }
    public int  RoomId { get; set; }
}
