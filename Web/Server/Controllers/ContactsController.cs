using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Web.Shared.Interfaces;
using Web.Shared.Entities;
using Web.Shared.DTO;
using AutoMapper;

namespace Web.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {

        public readonly IContactService _contactService;
        private readonly IMapper _mapper;

        public ContactsController(IContactService contactService,
            IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("GetContacts")]
        public async Task<IActionResult> GetContacts()
        {
            var result = await _contactService.GetAllContactsAsync();

            return Ok(result);
        }

        [HttpGet]
        [Route("GetContacts/{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var result = await _contactService.GetContactByIdAsync(id);

            var contactDTO = _mapper.Map<ContactDetailDTO>(result);
            return Ok(contactDTO);
        }

        [HttpPost]
        [Route("CreateContact")]
        public async Task<IActionResult> CreateContact(ContactDetailDTO contactDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var contact = _mapper.Map<Contact>(contactDto);
                contact.ContactId = Guid.NewGuid().ToString();
                contact.AddressId = Guid.NewGuid().ToString();
                contact.Address.AddressId = contact.AddressId;
                var createdContact = await _contactService.CreateContactAsync(contact);
                return CreatedAtAction(nameof(GetContactById), new { id = createdContact.ContactId }, createdContact);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while creating the contact.");
            }
        }

        [HttpPut]
        [Route("UpdateContact/{id}")]
        public async Task<IActionResult> UpdateContactById(ContactDetailDTO contactDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var contact = _mapper.Map<Contact>(contactDTO);
                await _contactService.UpdateContactAsync(contact);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }


        [HttpDelete("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            try
            {
                await _contactService.DeleteContactAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}

