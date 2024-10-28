using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {1,new ContactModel(){Id = 1,FirstName = "Lukas",LastName = "Janus",Email = "LukasJanus@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2003,03,18), PhoneNumber = "+48 607 758 331"}},
        {2,new ContactModel(){Id = 2,FirstName = "Pawel",LastName = "Wrona",Email = "PawelWrona@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2003,07,18), PhoneNumber = "+48 111 222 333"}},
        {3,new ContactModel(){Id = 3,FirstName = "Kacper",LastName = "Wojas",Email = "KacperWojas@microsoft.wsei.edu.pl", BirthDate = new DateOnly(2005,03,18), PhoneNumber = "+48 412 123 123"}}
    };

    private static int _currentId = 3;
    public IActionResult Index()
    {
        return View(_contacts);
    }

    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(ContactModel cm)
    {
        if (!ModelState.IsValid)
        {
            return View(cm);
        }

        cm.Id = ++_currentId;
        _contacts.Add(cm.Id,cm);
        return View("Index", _contacts);
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }

    public IActionResult Details()
    {
        throw new NotImplementedException();
    }

    public IActionResult Edit()
    {
        throw new NotImplementedException();
    }
}