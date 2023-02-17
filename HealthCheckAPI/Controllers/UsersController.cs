
using EFcoreTesting.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HealthCheckAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
	private MaelstromContext _context { get; set; }

	public UsersController(MaelstromContext context)
	{
		_context = context;
	}

	[HttpGet]
	public ActionResult<IEnumerable<User>> GetUsers()
	{
		var usersList = _context.Users.ToList();
		return usersList;
	}

    [HttpGet("{id}")]
    public ActionResult<User> GetUser(int id)
    {
	
        var user= _context.Users.Find(id);
		if (user == null)
		{
			var message = "Sorry that User does not exist.";
			return new BadRequestObjectResult(message);
		}
		else
		{
            return user;
        }
		
    }
}
