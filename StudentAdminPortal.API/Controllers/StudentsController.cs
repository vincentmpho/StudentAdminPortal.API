using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudentAdminPortal.API.Models;
using StudentAdminPortal.API.Models.DTOs;
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

        [HttpGet]
        [Route("{studentId:guid}")]

        public async Task<IActionResult> GetStudentAsyc([FromRoute] Guid studentId)
        {


            //Frtch Student Details
            var student = await _studentRepository.GetStudentAsync(studentId);


            //return Student
            if (student == null) 
            {
                return NotFound("No students found.");
            }

            var mappedStudent = _mapper.Map<Student>(student);

            return Ok(mappedStudent);
        }

        [HttpPut("{studentId:guid}")]
        public async Task<IActionResult> UpdateStudentAsync(Guid studentId, [FromBody] UpdateStudentDTO request)
        {
            if (!await _studentRepository.Exists(studentId))
            {
                return NotFound();
            }

            // Map UpdateStudentDTO to Student
            var studentEntity = _mapper.Map<Student>(request);

            var updatedStudent = await _studentRepository.UpdateStudent(studentId, studentEntity);

            if (updatedStudent == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to update student.");
            }

            var updatedStudentDTO = _mapper.Map<StudentDTO>(updatedStudent);
            return Ok(updatedStudentDTO);
        }


    }
}
