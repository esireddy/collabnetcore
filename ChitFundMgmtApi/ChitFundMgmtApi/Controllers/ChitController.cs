using System.Collections.Generic;
using AutoMapper;
using ChitFundMgmtApi.ChitMgmt.Get.v1.Dto_s;
using ChitFundMgmtApi.ChitMgmt.Post.v1.Dto_s;
using ChitFundMgmtApi.ChitMgmt.Post.v1.Entities;
using ChitFundMgmtApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ChitFundMgmtApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Chit")]
    public class ChitController : Controller
    {
        #region Members
        private IUnitOfWork unitOfWork;
        #endregion Members

        #region Constructors
        public ChitController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        #endregion Constructors

        #region Methods
        // GET: api/Chit
        [HttpGet]
        public IActionResult Get()
        {
            var chitEntityList = unitOfWork.Chits.GetAll();

            if (chitEntityList == null)
                return NotFound();

            var getChitDtoList = Mapper.Map<IEnumerable<Chit>, IEnumerable<GetChitDto>>(chitEntityList);

            return Ok(getChitDtoList);
        }

        // GET: api/Chit/5
        [HttpGet("{id}", Name = "GetChitById")]
        public IActionResult Get(int id)
        {
            var entity = unitOfWork.Chits.Get(id);

            if (entity == null)
                return NotFound();

            var getChitDto = Mapper.Map<Chit, GetChitDto>(entity);

            return Ok(getChitDto);
        }

        // POST: api/Chit
        [HttpPost]
        public IActionResult Post([FromBody]CreateChitDto createChitDto)
        {
            if (createChitDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var entity = Mapper.Map<CreateChitDto, Chit>(createChitDto);
            unitOfWork.Chits.Add(entity);

            if (!unitOfWork.Complete())
                return StatusCode(500, "An unexpected fault happened. Try again later.");

            var getChitDto = Mapper.Map<Chit, GetChitDto>(entity);
            return CreatedAtRoute("GetChitById", new { id = getChitDto.Id }, getChitDto);
        }

        // PUT: api/Chit/5
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
