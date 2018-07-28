using AutoMapper;
using ChitCore.Common.Dtos.v1.patch;
using ChitCore.Common.v1.Dtos;
using ChitCore.Data.v1;
using ChitCore.Data.v1.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

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

        // GET: api/Chits/{id}
        [HttpGet("{id}", Name = "GetChitBydId")]
        public IActionResult Get(int id)
        {
            var chitEntity = unitOfWork.Chits.Get(id);
            

            var manager = chitEntity.Manager;

            var user = chitEntity.ChitUsers
                                    .Where(x => x.UserId == chitEntity.ManagerId)
                                    .Select(x => x.User).FirstOrDefault();

            var getChitDto = Mapper.Map<Chit, GetChitDto>(chitEntity);

            getChitDto.Manager = (user != null) ? string.Join(" ", new string[] { user.FirstName, user.Minitial, user.LastName }) : string.Empty;

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

        // PATCH: api/Chits/{id}
        [HttpPatch("{id}")]
        public ActionResult Patch(int id, [FromBody]JsonPatchDocument jsonPatchDoc)
        {
            if (jsonPatchDoc == null)
            {
                return BadRequest();
            }

            var chitEntity = unitOfWork.Chits.Get(id);

            if (chitEntity == null)
            {
                NotFound();
            }

            var patchChitDto = Mapper.Map<Chit, PatchChitDto>(chitEntity);
            jsonPatchDoc.ApplyTo(patchChitDto);

            Mapper.Map(patchChitDto, chitEntity);
            unitOfWork.Chits.Update(chitEntity);

            var chitAdminEntity = unitOfWork.ChitAdmins.GetAll().Where(x => x.ChitId == id).FirstOrDefault();

            if (chitEntity.ManagerId.HasValue)
            {
                if (chitAdminEntity == null)
                {
                    unitOfWork.ChitAdmins.Add(new ChitAdministrator() { ChitId = id, UserId = chitEntity.ManagerId.Value });
                }
                else
                {
                    chitAdminEntity.UserId = chitEntity.ManagerId.Value;
                    unitOfWork.ChitAdmins.Update(chitAdminEntity);
                }
            }

            if (!unitOfWork.Complete())
            {
                return StatusCode(500, "An unexpected fault happened. Try again later.");
            }

            return NoContent();
        }

        // PUT: api/Chits/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]object value)
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
