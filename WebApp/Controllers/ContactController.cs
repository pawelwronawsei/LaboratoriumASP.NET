using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace WebApp.Controllers;

public class ContactController : Controller
{

    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Abecki",
                Email = "adam@wsei.edu.pl",
                PhoneNumber = "222 222 222",
                BirthDate = new DateOnly(2003,10,10)
            }
            
        },
        {
            2,
            new ()
            {
                Id = 2,
                FirstName = "Paweł",
                LastName = "Wrona",
                Email = "Pawel@wrona.pl",
                PhoneNumber = "333 333 333",
                BirthDate = new DateOnly(2003,07,18)
            }
        
        
            
        },
        {
            3,
            new ()
            {
                Id = 3,
                FirstName = "Marcin",
                LastName = "Tomaszek",
                Email = "Marcin@Tomek.pl",
                PhoneNumber = "843 323 313",
                BirthDate = new DateOnly(2003,09,22)
            }
        
        }
    };

    private static int _currentId = 3;
    
        
    // Lista Kontaktów, przycisk dodawania kontaktu
    public IActionResult Index()
    {
        return View(_contacts);
    }
    //formularz dodawania kontaktu
    public IActionResult Add()
    {
        return View();
    }
    [HttpPost]
    //Odebranie danych z formularza, walidacji i dodanie kontaktu do kolekcji
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        //dodanie modelu kolekcji
        model.Id = ++_currentId;
        _contacts.Add(model.Id,model);
        return View("Index", _contacts);
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }
    
}