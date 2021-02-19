using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.ObjectsDto;

namespace WebFirstApplication.IControllers
{
    public interface ICourse
    {
        Task<bool> AddUpdateCourses(CourseDto input);
        Task<List<CourseDto>> GetCourses(NoInput input);

        Task<CourseDto> GetCourse(SingleFieldInput<Guid> input);

       
    }
}
