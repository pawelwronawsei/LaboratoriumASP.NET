using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(length:20, ErrorMessage = "Name must have at most 20 characters")]
    [MinLength(length:2, ErrorMessage = "Name must have at least 2 characters")]
    public string FirstName { get; set; }  
    
    [Required]
    [MaxLength(length:50, ErrorMessage = "Surame must have at most 50 characters")]
    [MinLength(length:2, ErrorMessage = "Surame must have at least 2 characters")]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [Phone]
    [RegularExpression("\\d{3} \\d{3} \\d{3}",ErrorMessage = "Type number in format xxx xxx xxx")]
    public string PhoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
}