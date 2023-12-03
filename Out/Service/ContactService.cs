using ZevitTask.Application.Models.In.Create;
using ZevitTask.Application.Models.In.Mediator;
using ZevitTask.Application.Models.In.Update;
using ZevitTask.Application.Models.Out;
using ZevitTask.Domain.Port.Out;
using ZevitTask.Infrastructure.Out.Persistence.Repository;

namespace ZevitTask.Infrastructure.Out.Service;

public class ContactService : IContactPort
{
    private readonly IContactRepository _contactRepository;

    public ContactService(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public List<ContactResponse> GetAll()
    {
        var contacts = ContactMediator.ToContact(_contactRepository.GetContacts());
        return ContactResponse.From(contacts);
    }

    public ContactResponse GetById(Guid id)
    {
        var contacts = ContactMediator.ToContact(_contactRepository.GetContactById(id));
        return ContactResponse.From(contacts);
    }

    public void Delete(Guid id)
    {
        _contactRepository.DeleteContact(id);
    }

    public ContactResponse Create(CreateContactRequest contact)
    {
        var contacts = ContactMediator.ToContact(_contactRepository.AddContact(contact));
        return ContactResponse.From(contacts);

    }

    public ContactResponse Update(UpdateContactRequest contact, Guid id)
    {
        var contacts = ContactMediator.ToContact(_contactRepository.UpdateContact(id,contact));
        return ContactResponse.From(contacts);
    }
}