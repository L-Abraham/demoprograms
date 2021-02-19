using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using WebFirstApplication.ObjectsDto;
using AutoMapper;
using WebFirstApplication.objects;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using WebFirstApplication.Objects;
using Microsoft.EntityFrameworkCore;
using WebFirstApplication.IControllers;

using Microsoft.AspNetCore.Authorization;
namespace WebFirstApplication.Controllers
{

    [ApiController]
    [Route("[controller]")]
   
    public class CourseController : ControllerBase, ICourse
    {

        private readonly ILogger<CourseController> _logger;


        private static IMapper Mapper = new MapperConfiguration(cfg => 
        {
            cfg.CreateMap<Course, CourseDto>();
            cfg.CreateMap<CourseDto, Course>();
        
            cfg.CreateMap<Student, StudentDto>();
            cfg.CreateMap<StudentDto, Student>();

            cfg.CreateMap<DailyNote, DailyNoteDto>();
            cfg.CreateMap<DailyNoteDto, DailyNote>();

            cfg.CreateMap<StudentCourses, StudentCoursesDto>();
            cfg.CreateMap<StudentCoursesDto, StudentCourses>();


            cfg.CreateMap<UploadedDocumentsDto, UploadedDocuments>();
            cfg.CreateMap<UploadedDocuments, UploadedDocumentsDto>();

        }
        ).CreateMapper();

        LearningAssistantDbContext _context;

        public CourseController(ILogger<CourseController> logger,LearningAssistantDbContext context)
        {
            _logger = logger;
            _context = context;
        }
   

       
        [HttpPost]
        [Route("AddUpdateCourse")]
        public async Task<bool> AddUpdateCourses(CourseDto input)
        {
            if (input.Id.HasValue)
                return await UpdateCourses(input);
            else
                return await AddCourses(input);
        }




        private async Task<bool> AddCourses(CourseDto input)
        {
            var courseAdded = Mapper.Map<Course>(input);
            _context.Add(courseAdded);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> UpdateCourses(CourseDto input)
        {
            var courseUpdate = Mapper.Map<Course>(input);
            _context.Update(courseUpdate);
            await _context.SaveChangesAsync();
            return true;
        }

  
        [HttpPost]
        [Route("GetCorses")]
        public async Task<List<CourseDto>> GetCourses(NoInput input)
        {
            List<CourseDto> coursesDto = new List<CourseDto>();
            var courses = await _context.Courses.ToListAsync();
            if (courses != null)
                coursesDto = Mapper.Map<List<CourseDto>>(courses);

            return coursesDto;
        }

      
        [HttpPost]
        [Route("GetCourse")]
        public async Task<CourseDto> GetCourse(SingleFieldInput<Guid> input)
        {
            CourseDto coursesDto = new CourseDto();
            var course = await _context.Courses.Where(x => x.Id == input.Value).FirstOrDefaultAsync();
            if (course != null)
                coursesDto = Mapper.Map<CourseDto>(course);

            return coursesDto;
        }


    }
}
