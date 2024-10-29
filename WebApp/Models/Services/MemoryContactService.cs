using WebApp.Controllers;

namespace WebApp.Models.Services;

public class MemoryContactService : IContactService
{
    private Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ()
            {
                Id = 1,
                Category = Category.Business,
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
                Category = Category.Family,
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
                Category = Category.Friend,
                FirstName = "Marcin",
                LastName = "Tomaszek",
                Email = "Marcin@Tomek.pl",
                PhoneNumber = "843 323 313",
                BirthDate = new DateOnly(2003,09,22)
            }
        
        }
    };

    private int _currentId = 3;
    
    public void Add(ContactModel model)
    {
        model.Id = ++_currentId;
        _contacts.Add(model.Id,model);
    }

    public void Update(ContactModel model)
    {
        if (_contacts.ContainsKey(model.Id))
        {
            _contacts[model.Id] = model;
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel? GetById(int id)
    {
        return _contacts[id];
    }
}