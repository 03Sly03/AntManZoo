using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AntManZooApi.Repositories;
using AntManZooClassLibrary.Models;

namespace AntManZooApi.Controllers
{
    [Route("api/staff")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IRepository<Staff> _staffRepository;
        
        public StaffController(IRepository<Staff> staffRepository)
        {
            _staffRepository = staffRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStaffs()
        {
            return Ok(await _staffRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffById(int id)
        {
            var staff = await _staffRepository.GetById(id);
            if (staff == null)
            {
                return NotFound("Personnel non trouvé");
            }
            return Ok(staff);
        }
    }
}
