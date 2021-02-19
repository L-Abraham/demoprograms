using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebFirstApplication.ObjectsDto;

namespace WebFirstApplication.IControllers
{
    public interface IUser
    {
        Task<UserDto> IsloginUser(UserInput input);

        Task<bool> AddUser(UserInput input);
    }
}
