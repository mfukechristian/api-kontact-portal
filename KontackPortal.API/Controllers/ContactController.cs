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

            /// <summary>
            ///     Create Contact.
            /// </summary>
            /// <param name="contact">Contact details</param>
            /// <returns>Created document.</returns>
            [HttpPost]
            [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(Contact), StatusCodes.Status400BadRequest)]
            [ProducesResponseType(500)]
            public async Task<ActionResult> Post([FromForm] ContactCreate contact)
            {
                var newContact = await _contactService.PostAsync(contact);

                if (newContact == null)
                {
                    return BadRequest();
                }
                return Ok(newContact);
            }

            /// <summary>
            ///     Update Contact.
            /// </summary>
            /// <param name="id">Contact identifier</param>
            /// <param name="model">Contact details</param>
            /// <returns>Updated contact.</returns>
            [HttpPut("{id:int}")]
            [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(Contact), StatusCodes.Status400BadRequest)]
            [ProducesResponseType(500)]
            public async Task<ActionResult> Put([FromRoute] int id, [FromForm] ContactUpdate contact)
            {
                var updateContact = await _contactService.PutAsync(id, contact);

                if (updateContact == null)
                {
                    return BadRequest();
                }
                return Ok(updateContact);
            }

            /// <summary>
            ///     Patch Contact.
            /// </summary>
            /// <param name="id">Contact identifier</param>
            /// <param name="model">Contact details</param>
            /// <returns>Patched Contact.</returns>
            [HttpPatch("{id:int}")]
            [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(Contact), StatusCodes.Status400BadRequest)]
            [ProducesResponseType(500)]
            public async Task<ActionResult> Patch([FromRoute] int id, [FromForm] ContactPatch contact)
            {
          
                var patchContact = await _contactService.PatchAsync(id, contact);

                if (patchContact == null)
                {
                    return BadRequest();
                }
                return Ok(patchContact);
            }

            /// <summary>
            ///     Delete Contact by id.
            /// </summary>
            /// <param name="id">contact identifier</param>
            /// <returns>Contact.</returns>
            [HttpDelete("{id:int}")]
            [ProducesResponseType(typeof(Contact), StatusCodes.Status200OK)]
            [ProducesResponseType(typeof(Contact), StatusCodes.Status404NotFound)]
            [ProducesResponseType(500)]
            public async Task<ActionResult<Contact>> Delete([FromRoute] int id)
            {
                var deleteContact = await _contactService.GetAsync(id);
                if (deleteContact == null)
                {
                    return NotFound(new Contact()
                    {
                        Id = id
                    });
                }

                var result = await _contactService.DeleteAsync(id);

                return Ok(result);
            }

    }
}