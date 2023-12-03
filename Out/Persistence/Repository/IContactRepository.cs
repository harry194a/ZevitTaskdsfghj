using ZevitTask.Application.Models.In.Create;
using ZevitTask.Application.Models.In.Mediator;
using ZevitTask.Application.Models.In.Update;

namespace ZevitTask.Infrastructure.Out.Persistence.Repository;

public interface IContactRepository
{
    List<ContactMediator> GetContacts();
    ContactMediator GetContactById(Guid id);
    ContactMediator AddContact(CreateContactRequest createContactRequest);
    ContactMediator UpdateContact(Guid id , UpdateContactRequest updateContactRequest);
    void DeleteContact(Guid id);
}