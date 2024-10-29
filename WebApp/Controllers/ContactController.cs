using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    public IActionResult Index()
    {
        return View(_contactService.GetAll());
    }

    public IActionResult Details(int id)
    {
        return View(_contactService.GetById(id));
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
        return RedirectToAction(nameof(System.Index));
    }

    public IActionResult Edit(int id)
    {
        return View(_contactService.GetById(id));
    }
    
    [HttpPost]
    public IActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        _contactService.Update(model);
        return RedirectToAction(nameof(System.Index));
    }

    public IActionResult Delete(int id)
    {
        _contactService.Delete(id);
        return RedirectToAction(nameof(Index));
    }
    
}