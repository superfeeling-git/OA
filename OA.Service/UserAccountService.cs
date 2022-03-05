using OA.Dtos.Department;
using OA.Dtos.UserAccount;
using OA.Entity;
using OA.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace OA.Service
{
    public class UserAccountService : BaseService<UserAccount, UserAccountDto, int>, IUserAccountService
    {
        private readonly IUserAccountRepository userAccountRepository;

        public UserAccountService(IUserAccountRepository userAccountRepository,IMapper mapper)
        {
            this.BaseRepository = userAccountRepository;
            this.userAccountRepository = userAccountRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override Task CreateAsync(UserAccountDto dto)
        {
            /*登录
            1、验证码
            2、验证用户名和密码（MD5）
            3、写入cookies或JWT
            4、更新用户末次登录IP和时间

            添加账号
            1、工号生成，1000   BW001 - BW999
            2、密码加密MD5 SHA1*/

            return base.CreateAsync(dto);
        }
    }
}