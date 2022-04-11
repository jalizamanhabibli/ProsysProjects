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
    public class LessonController : Controller
    {
        private readonly ILessonService _service;
        private readonly IMapper _mapper;

        public LessonController(ILessonService service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allLesson = await _service.GetAllAsync();
            var allLessonDto = _mapper.Map<IEnumerable<LessonDto>>(allLesson);
            ViewBag.Lesson = new LessonDto();
            return View(allLessonDto);
        }

        [HttpGet]
        [ServiceFilter(typeof(NotFountFilter<Lesson>))]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> GetLessonByCode(string id)
        {
            var lesson = await _service.GetByIdAsync(id);
            var lessonDto = _mapper.Map<LessonDto>(lesson);
            return PartialView("ShowModal",lessonDto);
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> AddLesson(LessonDto lessonDto)
        {
            await _service.AddAsync(_mapper.Map<Lesson>(lessonDto));
            return Redirect("/Lesson");
        }

        [HttpPost]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> EditLesson(LessonDto lessonDto)
        {
            await _service.UpdateAsync(_mapper.Map<Lesson>(lessonDto));
            return Redirect("/Lesson");
        }

        [HttpPost]
        [ServiceFilter(typeof(NotFountFilter<Lesson>))]
        [ServiceFilter(typeof(ModelStateFilter))]
        public async Task<IActionResult> DeleteLesson(string id)
        {
            var lesson = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(lesson);

            return Redirect("/Lesson");
        }
    }
}
