using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ChitCoreApi.Pattern;
using ChitCoreApi.Users.get.v1.Dto_s;
using ChitCoreApi.Users.post.v1.Dto_s;
using ChitCoreApi.Users.post.v1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChitCoreApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {
        #region Members

        private readonly IUnitOfWork unitOfWork;

        #endregion Members

        #region Constructors

        public UsersController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        #endregion Constructors

        #region Methods

        // GET: api/Users
        [HttpGet]
        public ActionResult Get(string searchTerm)
        {
            var userEntities = unitOfWork.Users.Get(searchTerm);
            var getUserDtos = Mapper.Map<IEnumerable<User>, IEnumerable<GetUserDto>>(userEntities);
            return Ok(getUserDtos);
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "GetUserById")]
        public ActionResult Get(int id)
        {
            var userEntity = unitOfWork.Users.Get(id);
            var getUserDto = Mapper.Map<User, GetUserDto>(userEntity);
            return Ok(userEntity);
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult Post([FromBody]CreateUserDto createUserDto)
        {
            if (createUserDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return StatusCode(400, ModelState);

            var userEntity = Mapper.Map<CreateUserDto, User>(createUserDto);
            unitOfWork.Users.Add(userEntity);
            if (!unitOfWork.Complete())
            {
                return StatusCode(500, "An unexpected fault happened. Try again later.");
            }

            var getUserDto = Mapper.Map<User, GetUserDto>(userEntity);
            return CreatedAtRoute("GetUserById", new { id = getUserDto.Id }, getUserDto);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        #endregion Methods
    }
}
