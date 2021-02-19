using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.IControllers;
using WebFirstApplication.objects;
using WebFirstApplication.Objects;
using WebFirstApplication.ObjectsDto;

namespace WebFirstApplication.Controllers
{
 //   [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase,IStudent
    {
        LearningAssistantDbContext _context;
        private readonly ILogger<StudentController> _logger;

        private static IMapper Mapper = new MapperConfiguration(cfg =>
        {
          
            cfg.CreateMap<Student, StudentDto>();
            cfg.CreateMap<StudentDto, Student>();

            cfg.CreateMap<DailyNote, DailyNoteDto>();
            cfg.CreateMap<DailyNoteDto, DailyNote>();

            cfg.CreateMap<StudentCourses, StudentCoursesDto>();
            cfg.CreateMap<StudentCoursesDto, StudentCourses>();
            cfg.CreateMap<Course, CourseDto>();
            cfg.CreateMap<CourseDto, Course>();


        }
       ).CreateMapper();
        public StudentController(ILogger<StudentController> logger, LearningAssistantDbContext context)
        {
            _logger = logger;
            _context = context;
        }


     //   [Authorize]
        [HttpPost]
        [Route("AddUpdateStudents")]
        public async Task AddUpdateStudents(StudentDto input)
        {
            if (input.Id.HasValue)
                await UpdateStudents(input);
            else
                await AddStudents(input);

        }

        private async Task<bool> AddStudents(StudentDto input)
        {
            var studentAdded = Mapper.Map<Student>(input);
            _context.Add(studentAdded);
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> UpdateStudents(StudentDto input)
        {
            var studentAdded = Mapper.Map<Student>(input);
            _context.Update(studentAdded);
            await _context.SaveChangesAsync();
            return true;
        }

    //    [Authorize]
        [HttpPost]
        [Route("GetStudents")]
        public async Task<List<StudentDto>> GetStudents(NoInput input)
        {
            List<StudentDto> studentsDto = new List<StudentDto>();
            var students = await _context.Students.ToListAsync();
            if(students!=null)
            studentsDto=Mapper.Map<List<StudentDto>>(students);

            return studentsDto;
        }


     //   [Authorize]
        [HttpPost]
        [Route("GetStudent")]
        public async Task<StudentDto> GetStudent(SingleFieldInput<Guid> input)
        {
            StudentDto studentsDto = new StudentDto(); ;
            var student = await  _context.Students.Where(x => x.Id == input.Value).FirstOrDefaultAsync();
            if (student != null)
                studentsDto = Mapper.Map<StudentDto>(student);

            return studentsDto;
        }

   


    }
}
