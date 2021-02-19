using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.ObjectsDto;

namespace WebFirstApplication.IControllers
{
    public interface IStudent
    {

        Task AddUpdateStudents(StudentDto input);
        Task<List<StudentDto>> GetStudents(NoInput input);
        Task<StudentDto> GetStudent(SingleFieldInput<Guid> input);
        
    }
}
