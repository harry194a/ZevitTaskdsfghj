using Microsoft.AspNetCore.Mvc;
using ZevitTask.Application.Models.In.Create;
using ZevitTask.Application.Models.In.Update;
using ZevitTask.Application.Models.Out;
using ZevitTask.Infrastructure.Out.Service;

namespace ZevitTask.Infrastructure.In.Presentation;

    [ApiController]
    [Route("api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly ContactService _context;

        public ContactsController(ContactService context)
        {
            _context = context;
        }

        // GET: api/contacts
        [HttpGet]
        public  List<ContactResponse> GetContacts()
        {
            return  _context.GetAll();
        }

        // GET: api/contacts/{id}
        [HttpGet("{id}")]
        public ContactResponse GetContact(Guid id)
        {
            var contact = _context.GetById(id);
            return contact;
        }

        // POST: api/contacts
        [HttpPost]
        public ContactResponse CreateContact(CreateContactRequest request)
        {
            return _context.Create(request);
        }

        // PUT: api/contacts/{id}
        [HttpPut("{id}")]
        public ContactResponse UpdateContact(Guid id, UpdateContactRequest updateContactRequest)
        {

            return _context.Update(updateContactRequest,id);
        }

        // DELETE: api/contacts/{id}
        [HttpDelete("{id}")]
        public void DeleteContact(Guid id)
        {
            _context.Delete(id);
        }
    }

