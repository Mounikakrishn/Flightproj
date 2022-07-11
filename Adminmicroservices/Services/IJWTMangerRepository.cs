using Adminmicroservices.Models;
using Adminmicroservices.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adminmicroservices.Services
{
    public interface IJWTMangerRepository
    {
        Tokens Authenticate(AdminLoginViewModel users, bool IsRegister);
        List<TbAdmin> FindAll();
    }
}
