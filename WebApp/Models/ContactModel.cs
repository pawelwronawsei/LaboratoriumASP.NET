using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(length:20, ErrorMessage = "Imię nie może być większe niż 20 znaków")]
    [MinLength(length:2,ErrorMessage = "Imie musi mieć conajmniej 2 znaki!")]
    [Display(Name = "Imię")]
    public string FirstName { get; set; }
    
    [Required]
    [MaxLength(length:20, ErrorMessage = "Imię nie może być większe niż 20 znaków")]
    [MinLength(length:2,ErrorMessage = "Imie musi mieć conajmniej 2 znaki!")]
    [Display(Name = "Nazwisko")]
    public string LastName { get; set; }
    
    [EmailAddress]
    [Display(Name = "Adres Email")]
    public string Email { get; set; }
    
    [Phone]
    [RegularExpression("\\d{3} \\d{3} \\d{3}", ErrorMessage = "Wpisz numer wg wzoru: xxx xxx xxx")]
    [Display(Name = "Numer telefonu")]
    public string PhoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    [Display(Name = "Data urodzenia")]
    public DateOnly BirthDate { get; set; }
    
    [Display(Name = "Kategoria")]
    public Category Category { get; set; }
    
    
}