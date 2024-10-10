﻿using BaseLibrary.DTOs;
using Microsoft.AspNetCore.Mvc;
using ServerLibrary.Repositories.Contracts;

namespace Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController(IUserAccount userAccount) : ControllerBase
	{

		[HttpPost("register")]
		public async Task<IActionResult> CreateAsync(Register user) {

			if (user is null) return BadRequest("Model is empty.");
			var result = await userAccount.CreateAsync(user);
			return Ok(result);
		
		}

		[HttpPost("login")]
		public async Task<IActionResult> login(Login user) {
			if (user is null) return BadRequest("Model is empty");

			var result = await userAccount.SignInAsync(user);
			return Ok(result);
		
		}

		[HttpPost("refresh-token")]
		public async Task<IActionResult> refreshtoken(RefreshToken token) {

			if (token is null) return BadRequest("Model is empty");
			var result = await userAccount.RefreshTokenAsync(token);
			return Ok(result);
		
		}

	}
}
