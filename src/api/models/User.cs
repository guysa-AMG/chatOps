

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace chatOps.api.Models;

public class User()
{

    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = string.Empty;
    public string about { get; set; } = string.Empty;
    public ICollection<string> links { get; set; } = new List<String>();
    public string BackgroundImage { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;

    [EmailAddress]
    [MaxLength(100)]
    [Required]
    public string Email { get; set; } = string.Empty;
    public int? PhoneNumber { get; set; } = null;
    public string SecondaryEmail { get; set; } = string.Empty;
    public ICollection<RoomUser> UsersRooms { get; set; } = new List<RoomUser>();


}