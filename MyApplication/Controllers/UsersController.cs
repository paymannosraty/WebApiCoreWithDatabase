using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyApplication.Controllers
{
	public class UsersController : Infrastructure.BaseApiControllerWithDatabase
	{
		public UsersController(Models.DatabaseContext databaseContext) : base(databaseContext)
		{
		}

		[HttpGet]
		public async Task<ActionResult<IList<Models.User>>> GetAllAsync()
		{
			var result =
				await DatabaseContext
				.Users
				.ToListAsync()
				;

			return Ok(value: result);
		}

		[HttpGet(template: "{0}")]
		public async Task<ActionResult<Models.User>> GetAllAsync(Guid Id)
		{
			var result =
				await DatabaseContext
				.Users
				.Where(current => current.Id == Id)
				.FirstOrDefaultAsync()
				;

			return Ok(value: result);
		}

		[HttpPost]
		public async Task<ActionResult<Models.User>> PostAsync(Models.User user)
		{
			try
			{
				await DatabaseContext
					.Users
					.AddAsync(user)
					;

				await DatabaseContext.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}

			return Ok(value: user);
		}

		[HttpPut]
		public async Task<ActionResult<Models.User>> PutAsync(Models.User user)
		{
			try
			{
				var foundedEntity =
					await DatabaseContext
					.Users
					.Where(current => current.Id == user.Id)
					.FirstOrDefaultAsync();

				if (foundedEntity == null)
				{
					return BadRequest();
				}

				foundedEntity.Username = user.Username;
				foundedEntity.FullName = user.FullName;

				await DatabaseContext.SaveChangesAsync();
			}
			catch (Exception)
			{
				throw;
			}

			return Ok(value: user);
		}

		[HttpDelete]
		public async Task<ActionResult> DeleteAsync(Guid id)
		{
			var foundedEntity =
				await DatabaseContext
				.Users
				.Where(current => current.Id == id)
				.FirstOrDefaultAsync();

			DatabaseContext
				.Users
				.Remove(foundedEntity);

			await DatabaseContext.SaveChangesAsync();

			return Ok();
		}
	}
}
