using AspApiEfProject.DataAccess;
using AspApiEfProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspApiEfProject.Controllers
{
    [ApiController]
    public class ContactController : Controller
    {
        public readonly AspApiDbContext db;

        public ContactController(AspApiDbContext db)
        {
            this.db = db;
        }


        [HttpPost("/Contact")]
        public async Task<IActionResult> ContactCreation(string firstname, string lastname, string email)
        {
            if (string.IsNullOrEmpty(firstname) && string.IsNullOrEmpty(lastname) && string.IsNullOrEmpty(email))
            {
                return BadRequest();
            }

            try
            {
                await db.Contact.AddAsync(new Contact()
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Email = email
                });
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                return Conflict();
            }
            catch (Exception)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
