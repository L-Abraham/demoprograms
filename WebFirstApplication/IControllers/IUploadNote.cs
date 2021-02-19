using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.ObjectsDto;

namespace WebFirstApplication.IControllers
{
    public interface IUploadNote
    {
        Task<List<StudentCoursesDto>> GetStudentCourses(StudentCourseInputDto input);
        Task<UploadedDocumentsDto> UploadDocuments(IFormFile input);
        Task<bool> AddStudentCourse(StudentCourseInputDto input);
        Task<List<DailyNoteDto>> AddDailyNote(List<DailyNoteDto> input);

        Task<UploadedDocumentsDto> Getdocuments(SingleFieldInput<Guid> input);
        Task<List<DailyNoteDto>> GetDailyNotes(SingleFieldInput<Guid> input);
    }
}
