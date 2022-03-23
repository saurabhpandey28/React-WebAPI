using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using React_WebAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace React_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

   
    public class ContactController : ControllerBase
    {
        private readonly ContactDBContext _context;

        public ContactController(ContactDBContext context)
        {
            _context = context;
        }

        // GET: api/<ContactController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Contact>>> GetContact()
        {
            var list = await _context.Contacts.ToListAsync();
            return Ok(list);
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
       
         public async Task<ActionResult<Contact>> GetContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);

            if (contact == null)
            {
                return NotFound();
            }
            return contact;
        }

        // POST api/<ContactController>
        [HttpPost]
        
        public async Task<ActionResult<Contact>> PostContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetContact", new { id = contact.id }, contact);
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContact(int id, Contact contact)
        {
            contact.id = id;

            _context.Entry(contact).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Contact>> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            return contact;
        }
        private bool ContactExists(int id)
        {
            return _context.Contacts.Any(e => e.id == id);
        }
    }
}
