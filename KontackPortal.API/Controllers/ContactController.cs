using KontackPortal.API.Helpers;
using KontackPortal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KontackPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly ContactContext _context;
        public ContactController(ContactContext context)
        {
            _context = context;
        }

         // GET: api/contact
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactModel>>> GetContacts()
        {
            var contacts = await _context.Contacts.ToListAsync();
            return Ok(contacts);
        }
    }
}