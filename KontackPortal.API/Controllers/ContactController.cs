using KontackPortal.Domain.DTOs;
using KontackPortal.DomainLogic.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KontackPortal.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        ///     Get all Contacts.
        /// </summary>
        /// <returns>List of contacts.</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(500)]
        public async Task<ActionResult<List<Contact>>> GetAllContacts()
        {
            var contacts = await _contactService.GetAllAsync();
            return Ok(contacts);
        }

   
             /// <summary>
            ///     Get Single Contact.
            /// </summary>
            /// <param name="id">The ID of the contact to retrieve.</param>
            /// <returns>The requested contact.</returns>
            [HttpGet("{id}")]
            [ProducesResponseType(StatusCodes.Status200OK)]
            [ProducesResponseType(StatusCodes.Status404NotFound)]
            [ProducesResponseType(StatusCodes.Status500InternalServerError)]
            public async Task<ActionResult<Contact>> GetContact([FromRoute] int id)
            {
                var contact = await _contactService.GetAsync(id);

                if (contact == null)
                {
                    return NotFound(new Contact { Id = id });
                }

                return Ok(contact);
            }

    }
}