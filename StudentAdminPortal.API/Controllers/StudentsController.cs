using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Models;
using StudentAdminPortal.API.Repositories.Interfaces;

namespace StudentAdminPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentsController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            try
            {
                // Fetch students from the repository
                var students = await _studentRepository.GetStudentsAsync();

                // validation to check if students are null
                if (students == null)
                {
                    return NotFound("No students found.");
                }

                // Map the retrieved students to the desired model
                var mappedStudents = _mapper.Map<List<Student>>(students);

                return Ok(mappedStudents);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,"An error occurred while processing your request.");
            }
        }
    }
}
