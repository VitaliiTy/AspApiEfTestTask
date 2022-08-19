using AspApiEfProject.DataAccess;
using AspApiEfProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspApiEfProject.Controllers
{
    [ApiController]
    public class IncidentController : Controller
    {
        public readonly AspApiDbContext db;

        public IncidentController(AspApiDbContext db)
        {
            this.db = db;
        }

        [HttpPost("/Incident")]
        public async Task<IActionResult> IncidentCreation(string accountName, string firstname, string lastname, string email, string description)
        {
            if (string.IsNullOrEmpty(accountName) && string.IsNullOrEmpty(firstname) && string.IsNullOrEmpty(lastname) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(description))
            {
                return BadRequest();
            }

            Random random = new();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var ramdomString = new string(Enumerable.Repeat(chars, 10).Select(s => s[random.Next(s.Length)]).ToArray());

            var account = db.Account.Where(c => c.Name == accountName).FirstOrDefault();
            if (account == null)
            {
                return NotFound();
            }

            try
            {
                var contact = db.Contact.Where(c => c.Email == email).FirstOrDefault();
                if (contact == null)
                {
                    contact = new Contact()
                    {
                        FirstName = firstname,
                        LastName = lastname,
                        Email = email,
                        AccountId = account.Id
                    };
                    await db.Contact.AddAsync(contact);
                }
                else
                {
                    contact.FirstName = firstname;
                    contact.LastName = lastname;
                    contact.AccountId = account.Id;
                }
                db.SaveChanges();

                var incident = new Incident() { Name = ramdomString,
                                                Description = description };
                await db.Incident.AddAsync(incident);
                db.SaveChanges();

                account.IncidentId = incident.Id;
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
