using ZevitTask.Application.comm;
using ZevitTask.Application.Models.In.Create;
using ZevitTask.Application.Models.In.Mediator;
using ZevitTask.Application.Models.In.Update;
using ZevitTask.Infrastructure.Out.Persistence.Entity;

namespace ZevitTask.Infrastructure.Out.Persistence.Repository;

public class ContactRepository : IContactRepository
{
    private readonly AppDbContext _contacts;


    public ContactRepository(AppDbContext context)
    {
        _contacts = context;
    }

    public  List<ContactMediator> GetContacts()
    {
        return ContactMediator.From(_contacts.ContactEntity.ToList());
    }

    public ContactMediator GetContactById(Guid id)
    {
            return ContactMediator.From(_contacts.ContactEntity.Find(id));
    }

    public ContactMediator AddContact(CreateContactRequest contact)
    {
        ContactMediator contactMediator = CreateContactRequest.toMediator(contact);
        ContactEntity entity = ContactMediator.ToEntity(contactMediator);
        _contacts.Add(entity);
        return ContactMediator.From(entity);
    }

    public ContactMediator UpdateContact(Guid id, UpdateContactRequest updateContactRequest)
    {
        var contactEntity = GetEntityById(id);
        contactEntity.EmailAddress = updateContactRequest.EmailAddress;
        contactEntity.PhoneNumber = updateContactRequest.PhoneNumber;
        contactEntity.PhysicalAddress = updateContactRequest.PhysicalAddress;
        contactEntity.FullName = updateContactRequest.FullName;
        _contacts.Update(contactEntity);
        return ContactMediator.From(contactEntity);
    }

    public void DeleteContact(Guid id)
    {
        var contactToRemove = GetEntityById(id);
        if (contactToRemove != null)
        {
            _contacts.Remove(contactToRemove);
        }
    }
    
    private ContactEntity GetEntityById(Guid id)
    {
        if (_contacts.ContactEntity.Find(id) == null)
        {
            throw new NullReferenceException("there is not an item with id - " + id);
        }
        return _contacts.ContactEntity.Find(id);
        
    }
}
