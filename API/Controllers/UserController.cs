using Application.AppUsers.Commands.AddRoleToUser;
using Application.AppUsers.Queries.GetUserDetails;
using Application.AppUsers.Queries.GetUserList;
using Application.AppUsers.Queries.Login;
using Application.Roles.Enums;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        public UserController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Provides authentication for user
        /// </summary>
        /// <remarks>
        /// Sample reques:
        /// POST /login
        /// </remarks>
        /// <param name="loginDto">
        /// Login and password (There are two test users: Login: user1, Password: password; Login: user2, Password: password)
        /// </param>
        /// <returns>Returns authenticated user with access token</returns>
        /// <response code="200">Success</response>
        /// <response code="404">If user not found</response>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AppUserDto>> LoginAsync(LoginDto loginDto)
        {
            var query = _mapper.Map<LoginQuery>(loginDto);
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
        public async Task<ActionResult<UserListVm>> GetUsersAsync([FromQuery] GetUserListDto dto)
        {
            var query = _mapper.Map<GetUserListQuery>(dto);
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets user by Id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /users/{id}
        /// </remarks>
        /// <returns>Returns UserDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unauthorized</response>
        [HttpGet("users/{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<UserDetailsVm>> GetUserAsync(Guid id)
        {
            var query = new GetUserDetailsQuery
            {
                Id = id.ToString()
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Adding list of roles to user
        /// </summary>
        /// <remarks>
        /// Sample reques:
        /// PUT /users/{id}/add-role
        /// </remarks>
        /// <param name="id">User id</param>
        /// <param name="roles">List of roles to add (valid roles: Admin, User, SuperAdmin, Support)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="200">Success</response>
        /// <response code="404">If user not found</response>
        /// <response code="401">If user is unauthorized</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPut("users/{id}/add-role")]
        [Authorize]
        public async Task<ActionResult> AddRoleToUser(Guid id, [FromBody] List<UserRoles> roles)
        {
            var command = new AddRoleToUserCommand
            {
                Id = id.ToString(),
                Roles = roles
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
