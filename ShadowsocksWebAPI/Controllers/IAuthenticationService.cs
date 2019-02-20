using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShadowsocksWebAPI.Controllers
{
   
    public interface IAuthenticationService
    {
        void AddUserDevice(UserDevice existsDevice);
        User GetUserByLoginId(string loginIdorEmail);
        UserDevice GetUserDevice(int userId, int deviceType);
        UserDevice GetUserDevice(string sessionKey);
        void UpdateUserDevice(UserDevice existsDevice);
        User GetUser(int userId);
    }
}
