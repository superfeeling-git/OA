using OA.Dtos.UserAccount;
using OA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Service
{
    public interface IUserAccountService : IBaseService<UserAccount, UserAccountDto, int>
    {
    }
}
