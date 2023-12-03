using System.ComponentModel.DataAnnotations;

namespace ZevitTask.Infrastructure.Out.Persistence.Entity;

public class ContactEntity
{
    public Guid? Id{ get; set; }
    
    [Required(ErrorMessage = "Full Name is required")]
    public string? FullName{ get; set; }
    
    [Required(ErrorMessage = "Email Address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string? EmailAddress{ get; set; }
    
    [Required(ErrorMessage = "Phone Number is required")]
    [Phone(ErrorMessage = "Invalid Phone Number")]
    public string? PhoneNumber{ get; set; }
    public string? PhysicalAddress{ get; set; }
}