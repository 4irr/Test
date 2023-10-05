using Application.AppUsers.Queries.GetUserList;
using Application.AppUsers.Queries.Login;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    public class UserController : BaseController
    {
        /// <summary>
        /// Provides authentication for user
        /// </summary>
        /// <remarks>
        /// Sample reques:
        /// POST /login
        /// </remarks>
        /// <param name="query">Login and password</param>
        /// <returns>Returns authenticated user with access token</returns>
        /// <response code="200">Success</response>
        /// <response code="404">If user not found</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppUser>> LoginAsync(LoginQuery query)
        {
            return await Mediator.Send(query);
        }
        /// <summary>
        /// Gets the list of users
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /users
        /// </remarks>
        /// <returns>Returns UserListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("users")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserListVm>> GetUsersAsync()
        {
            var query = new GetUserListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
