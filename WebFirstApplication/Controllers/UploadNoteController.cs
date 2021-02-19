using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.IControllers;
using WebFirstApplication.objects;
using WebFirstApplication.Objects;
using WebFirstApplication.ObjectsDto;

namespace WebFirstApplication.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UploadNoteController : ControllerBase, IUploadNote
    {

        LearningAssistantDbContext _context;
        private readonly ILogger<UploadNoteController> _logger;

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

        public UploadNoteController(ILogger<UploadNoteController> logger, LearningAssistantDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        //   [Authorize]
        [HttpPost]
        [Route("UploadDoc")]
        public async Task<UploadedDocumentsDto> UploadDocuments(IFormFile input)
        {

            UploadedDocuments documents;

            using (var memoryStream = new MemoryStream())
            {
                input.OpenReadStream().CopyTo(memoryStream);
                var bytes = memoryStream.ToArray();
                documents = new UploadedDocuments
                {
                    FileName = input.FileName,
                    ContetntType = input.ContentType,
                    Content = bytes
                };

            };

            _context.Add(documents);
            await _context.SaveChangesAsync();
            return Mapper.Map<UploadedDocumentsDto>(documents);
        }


        //    [Authorize]
        [HttpPost]
        [Route("AddStudentsCourse")]
        public async Task<bool> AddStudentCourse(StudentCourseInputDto input)
        {
            if (input != null)
            {
                foreach (var course in input.Courses)
                {
                    StudentCourses s1 = new StudentCourses();
                    s1.CourseGuid = course.Id.Value;
                    s1.StudentGuid = input.StudentGuid;
                    _context.Add(s1);
                }
            }
            await _context.SaveChangesAsync();
            return true;
        }


        [HttpPost]
        [Route("GetStudentCourses")]
        public async Task<List<StudentCoursesDto>> GetStudentCourses(StudentCourseInputDto input)
        {

            List<StudentCoursesDto> studentCoursesDto = new List<StudentCoursesDto>();
            var studentCourses = await _context.StudentCourse.Include(x => x.Course).Where(x => x.StudentGuid == input.StudentGuid).ToListAsync();

            if (studentCourses != null)
            {
                studentCoursesDto = Mapper.Map<List<StudentCoursesDto>>(studentCourses);
            }
            return studentCoursesDto;
        }


        [HttpPost]
        [Route("AddDailyNote")]
        public async Task<List<DailyNoteDto>> AddDailyNote(List<DailyNoteDto> input)
        {
           
                List<DailyNoteDto> output = new List<DailyNoteDto>();
                if (input != null)
                {
                    var dailyNote = Mapper.Map<List<DailyNote>>(input);
                 
                    foreach(var x in dailyNote)
                    {
                        x.Documents = null;
                    }
                    _context.DailyNotes.AddRange(dailyNote);
                    await _context.SaveChangesAsync();

                var result = await _context.DailyNotes.Where(x => x.StudentCoursesId == dailyNote[0].StudentCoursesId).ToListAsync();
                output = Mapper.Map<List<DailyNoteDto>>(result);
                }
                return output;
        }


        [HttpPost]
        [Route("GetDailyNotes")]
        public async Task<List<DailyNoteDto>> GetDailyNotes(SingleFieldInput<Guid> input)
        {

            List<DailyNoteDto> output = new List<DailyNoteDto>();
            if (input.Value != null)
            {
               var result= await _context.DailyNotes.Where(x => x.StudentCoursesId == input.Value).ToListAsync();
            if (result != null)
             
                output = Mapper.Map<List<DailyNoteDto>>(result);
            }
            return output;

        }


        [HttpPost]
        [Route("GetDocument")]
        public async Task<UploadedDocumentsDto> Getdocuments(SingleFieldInput<Guid> input)
        {
            UploadedDocumentsDto output = new UploadedDocumentsDto();
           
               var result= await _context.UploadedDocuments.Where(x => x.Id == input.Value).FirstOrDefaultAsync();
            if (result != null)
            {
                output = Mapper.Map<UploadedDocumentsDto>(result);
            }
            return output;
        }
    }
}
