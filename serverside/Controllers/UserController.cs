using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using serverside.Data.DTO;
using serverside.Data.Resource;
using serverside.Core.Models;
using AutoMapper;
using serverside.Core;
using serverside.Core.Authorization;
using serverside.Services;

namespace serverside.Controllers
{
    [Route("api/Users/")]
    [ApiController]
    public class UsersController : Controller
    {
        private IUserService _userService;

        private IMapper mapper;
        private IUserRepository repository;
        private readonly IUnitOfWork unitOfWork;

        public UsersController(IMapper _mapper, IUserRepository repository, IUnitOfWork unitOfWork, IUserService userService)
        {
            this.mapper = _mapper;
            this.repository = repository;
            this.unitOfWork = unitOfWork;
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }
        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = _userService.RefreshToken(refreshToken, ipAddress());
            setTokenCookie(response.RefreshToken);
            return Ok(response);
        }
        [HttpPost("revoke-token")]
        public IActionResult RevokeToken(RevokeTokenRequest model)
        {
            // accept refresh token in request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            _userService.RevokeToken(token, ipAddress());
            return Ok(new { message = "Token revoked" });
        }


        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpGet("{id}/refresh-tokens")]
        public IActionResult GetRefreshTokens(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user.RefreshTokens);
        }
                private string ipAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

        // helper methods

        private void setTokenCookie(string token)
        {
            // append cookie with refresh token to the http response
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddDays(7)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }



        [HttpGet]
        public async Task<ActionResult<ApiResult<UserDTO>>> GetUsers(
            int pageIndex = 0,
            int pageSize = 10,
            string sortColumn = null,
            string sortOrder = null,
            string filterColumn = null,
            string filterQuery = null)
        {

            var dataQuery =  repository.GetUserList();
            
            return await ApiResult<UserDTO>.CreateAsync(
                    dataQuery.Select( u => new UserDTO() {
                        Id = u.Id,
                        NamaBelakang = u.NamaBelakang,
                        NamaDepan = u.NamaDepan,
                        Role = u.Role
                    }),
                    pageIndex,
                    pageSize,
                    sortColumn,
                    sortOrder,
                    filterColumn,
                    filterQuery
            );
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResource>> GetUser(int id) {
            var user = await repository.Get(id);
            if (user == null) {
                return NotFound();
            }
            return mapper.Map<User, UserResource>(user);
        }
        [HttpPost]
        public ActionResult CreateUser([FromBody] UserResource userResource)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = mapper.Map<UserResource, User>(userResource);
            repository.Add(user);
            unitOfWork.CompleteAsync();
            return Ok(user);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> ChangeUserData(int id, [FromBody] UserResource userResource) {
            if (!ModelState.IsValid) { 
                return BadRequest();
            }
            var user = await repository.Get(id);
            if (user == null) { 
                return BadRequest(" id user tidak valid");
            }
            mapper.Map<UserResource, User>(userResource, user);
            await unitOfWork.CompleteAsync();
            user = await repository.Get(id);
            var result = mapper.Map<User, UserDTO>(user);
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id) {
            var user = await repository.Get(id);
            if (user == null) {
                return BadRequest("Invalid id to delete");
            }
            repository.Remove(user);
            await unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}