using AutoMapper;
using ChitCore.Common.v1.Dtos;
using ChitCore.Data.v1;
using ChitCore.Data.v1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ChitCoreApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Chits")]
    public class ChitsController : Controller
    {
        #region Members

        private IUnitOfWork unitOfWork;

        #endregion Members

        #region Constructors

        public ChitsController(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        #endregion Constructors

        #region Methods

        // GET: api/Chits
        [HttpGet]
        public ActionResult Get()
        {
            var listChitEntity = unitOfWork.Chits.GetAll();
            var listGetChitDto = Mapper.Map<IEnumerable<Chit>, IEnumerable<GetChitDto>>(listChitEntity);
            return Ok(listGetChitDto);
        }

        // GET: api/Chits/5
        [HttpGet("{id}", Name = "GetChitBydId")]
        public IActionResult Get(int id)
        {
            var chitEntity = unitOfWork.Chits.Get(id);
            var getChitDto = Mapper.Map<Chit, GetChitDto>(chitEntity);
            return Ok(getChitDto);
        }

        // POST: api/Chits
        [HttpPost]
        public IActionResult Post([FromBody]CreateChitDto createChitDto)
        {
            if (createChitDto == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return StatusCode(400, ModelState);

            var chitEntity = Mapper.Map<CreateChitDto, Chit>(createChitDto);
            unitOfWork.Chits.Add(chitEntity);
            if (!unitOfWork.Complete())
            {
                return StatusCode(500, "An unexpected fault happened. Try again later.");
            }

            var getChitDto = Mapper.Map<Chit, GetChitDto>(chitEntity);
            return CreatedAtRoute("GetChitBydId", new { id = getChitDto.Id }, getChitDto);
        }

        // PUT: api/Chits/5
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
