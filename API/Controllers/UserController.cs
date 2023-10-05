using Application.AppUsers.Queries.Login;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [AllowAnonymous]
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
    }
}
