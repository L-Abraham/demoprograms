using AutoMapper;
using Microsoft.AspNetCore.Http;
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
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase,IUser
    {
        LearningAssistantDbContext _context;
        private readonly ILogger<UserController> _logger;

        private static IMapper Mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<User, UserDto>();
            cfg.CreateMap<UserDto, User>();
            cfg.CreateMap<Student, StudentDto>();
            cfg.CreateMap<StudentDto, Student>();


        }
       ).CreateMapper();
        public UserController(ILogger<UserController> logger, LearningAssistantDbContext context)
        {
            _logger = logger;
            _context = context;
        }

       
        [HttpPost]
        [Route("IsloginUser")]
        public async Task<UserDto> IsloginUser(UserInput input )
        {
            try
            {
                var user = await _context.Users.Include(x => x.Student).Where(x => x.Student.EmailAddress.Trim().ToLower() ==input.EmailAddress.Trim().ToLower()
                && x.Password == input.Password
                ).FirstOrDefaultAsync();
                if (user != null)
                {
                    var userDto = Mapper.Map<UserDto>(user);
                    return userDto;
                }
                return null;
            }
            catch(Exception  ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
            }
            return null;
        }


        [HttpPost]
        [Route("AddUser")]
        public async Task<bool> AddUser(UserInput input)
        {
            try
            {
                var student = await _context.Students.Where(x => x.EmailAddress.Trim().Equals(input.EmailAddress.Trim(), StringComparison.OrdinalIgnoreCase)).FirstOrDefaultAsync();

                if (student != null)
                {
                    _context.Users.Add(new User { StudentGuid = student.Id, Password = input.Password });
                    await _context.SaveChangesAsync();
                }
            }
            catch
            { return false; }

            return true;
        }

    }
}
