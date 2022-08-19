using AspApiEfProject.DataAccess;
using AspApiEfProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace AspApiEfProject.Controllers
{
    [ApiController]
    public class AccountController : Controller
    {
        public readonly AspApiDbContext db;

        public AccountController(AspApiDbContext db)
        {
            this.db = db;
        }

        [HttpPost("/Account")]
        public async Task<IActionResult> AccountCreation(string name, string contactEmail)
        {
            if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(contactEmail))
            {
                return BadRequest();
            }

            var contact = db.Contact.Where(c => c.Email == contactEmail).FirstOrDefault();
            if (contact == null)
            {
                return NotFound();
            }
            

            try
            {
                var account = new Account() { Name = name };
                await db.Account.AddAsync(account);
                db.SaveChanges();
                contact.AccountId = account.Id;
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
