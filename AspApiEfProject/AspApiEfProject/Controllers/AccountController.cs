using AspApiEfProject.DataAccess;
using AspApiEfProject.Models;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> AccountCreation(string name)
        {
            if(string.IsNullOrEmpty(name))
            { 
                return BadRequest();
            }
               
            await db.Account.AddAsync(new Account() { Name = name });

            Response.StatusCode = 404;
            return Ok();
        }
    }
}
