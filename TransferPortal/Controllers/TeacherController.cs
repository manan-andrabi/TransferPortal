using Microsoft.AspNetCore.Mvc;
using TransferPortal.Application.Abstraction.IService;
using TransferPortal.Application.Abstraction.RRModal;

namespace TransferPortal.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService service;
        public TeacherController(ITeacherService service)
        {
            this.service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Add(TeacherRequest modal)
        {
            var res = await service.Add(modal);
            if (res > 0)
            {
                return Ok(modal.Name + " : Added Successfully");
            }
            return BadRequest("Failed to save ");
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await service.GetAll();
            if (res is null)
            {
                return BadRequest("Not Data Found");
            }
            return Ok(res);
        }
        [HttpGet("/Results")]
        public async Task<IActionResult> GetRes()
        {
            var res = await service.GetResult();
            if (res is null)
            {
                return BadRequest("Not Result Matched yet");
            }
            return Ok(res);
        }
        [HttpGet("{id:guid}/getByID")]
        public async Task<IActionResult> GetbyId(Guid id)
        {
            var res = await service.GetByID(id);
            if (res is null)
            {
                return BadRequest("Not Result Matched yet");
            }
            return Ok(res);
        }
        [HttpGet("{no}")]
        public async Task<IActionResult> Getbyphone(string no)
        {
            var res = await service.GetByPhone(no);
            if (res is null)
            {
                return BadRequest("Not Result Matched yet");
            }
            return Ok(res);
        }

        [HttpDelete]
        public  async Task<IActionResult> Delete(Guid id)
        {
            var res = await service.Delete(id);
            if (res > 0)
            {
                return Ok("Deleted Successfully");
            }
            return BadRequest("Failed to Delete ");
        }
    }
}
