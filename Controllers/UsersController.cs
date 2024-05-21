using LoginPage.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginPage.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private static List<User> _users = new List<User>();


		[HttpPost("signup")]
		public IActionResult Signup(User user)
		{
			if (_users.Any(p => p.UserName == user.UserName))
			{
				return BadRequest("کاربر با این نام وجود دارد");
			}
			_users.Add(user);

			return Ok("ثبت نام با موفقیت انجام شد");
		}

		[HttpPost("login")]
		public IActionResult Login(User login)
		{
			var user = _users.FirstOrDefault(p => p.UserName == login.UserName && p.Password == login.Password);

			if (user == null)
			{
				return Unauthorized("نام کاربری یا رمز عبور اشتباه است");
			}
			


			return Ok("ورود با موفقیت انجام شد");
		}
	}
}
