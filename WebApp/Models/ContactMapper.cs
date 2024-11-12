using WebApp.Controllers;

namespace WebApp.Models;

public class ContactMapper
{
    public static ContactEntity ToEntity(ContactModel arg)
    {
        return new ContactEntity()
        {
            Id = arg.Id,
            FirstName = arg.FirstName,
            LastName = arg.LastName,
            PhoneNumber = arg.PhoneNumber,
            Email = arg.Email,
            BirthDate = arg.BirthDate,
            Organization = arg.Organization,
            OrganizationId = arg.OrganizationId
        };
    }

    public static ContactModel FromEntity(ContactEntity arg)
    {
        return new ContactModel()
        {
            Id = arg.Id,
            FirstName = arg.FirstName,
            LastName = arg.LastName,
            PhoneNumber = arg.PhoneNumber,
            Email = arg.Email,
            BirthDate = arg.BirthDate,
            Organization = arg.Organization,
            OrganizationId = arg.OrganizationId
        };
    }
}