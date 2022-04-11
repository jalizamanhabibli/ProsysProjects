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
    public class ExamController : Controller
    {
        private readonly IExamService _service;
        private readonly IMapper _mapper;

        public ExamController(IExamService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var exam = await _service.GetAllAsync();
            var examDto = _mapper.Map<IEnumerable<ExamTableDto>>(exam);
            return View(examDto);
        }

        [HttpGet]
        [ServiceFilter(typeof(NotFountFilter<Exam>))]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> GetExamById(int id)
        {
            var data = await _service.GetExamWithStudentsAndLessons(id);
            var examDto = _mapper.Map<ExamDto>(data.exam);
            var students = _mapper.Map<IEnumerable<StudentDto>>(data.students);
            var lessons = _mapper.Map<IEnumerable<LessonDto>>(data.lessons);
            ViewData["students"] = students;
            ViewData["lessons"] = lessons;
            return PartialView("ShowModal", examDto??new ExamDto());
        }
        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> AddExam(ExamDto exam)
        {
            await _service.AddAsync(_mapper.Map<Exam>(exam));
            return Redirect("/Exam");
        }
        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> EditExam(ExamDto exam)
        {
            await _service.UpdateAsync(_mapper.Map<Exam>(exam));
            return Redirect("/Exam");
        }
        [HttpPost]
        [ServiceFilter(typeof(NotFountFilter<Exam>))]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var exam = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(exam);
            return Redirect("/Exam");
        }
    }
}
