using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project2.Core.Dtos;
using Project2.Core.Entities;
using Project2.Core.Services;
using Project2.Mvc.Filters;

namespace Project2.Mvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _service;
        private readonly IMapper _mapper;

        public StudentController(IStudentService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allStudent = await _service.GetAllAsync();
            var allStudentDto = _mapper.Map<IEnumerable<StudentDto>>(allStudent);
            return View(allStudentDto);
        }
        [HttpGet]
        [ServiceFilter(typeof(NotFountFilter<Student>))]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var allStudent = await _service.GetByIdAsync(id);
            var allStudentDto = _mapper.Map<StudentDto>(allStudent);
            return PartialView("ShowModal",allStudentDto);
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> AddStudent(StudentDto studentDto)
        {
            await _service.AddAsync(_mapper.Map<Student>(studentDto));
            return Redirect("/Student");
        }
        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> EditStudent(StudentDto studentDto)
        {
            await _service.UpdateAsync(_mapper.Map<Student>(studentDto));
            return Redirect("/Student");
        }

        [HttpPost]
        [ServiceFilter(typeof(NotFountFilter<Student>))]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(student);
            return Redirect("/Student");
        }
    }
}
