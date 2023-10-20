using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.Model;
using StudentAdminPortal.Repository.IRepository;

namespace StudentAdminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderRepository _genderRepository;
        private readonly IMapper _mapper;

        public GenderController(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("getAllGender")]
        public async Task<IActionResult> GetAllGender()
        {
            var genderList = await _genderRepository.GetAllGender();
            if (genderList == null || !genderList.Any())
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<Gender>>(genderList));
        }
    }
}
