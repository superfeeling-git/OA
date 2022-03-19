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
using OA.Dtos;
using System.Security.Claims;
using IdentityModel;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace OA.Service
{
    public class UserAccountService : BaseService<UserAccount, UserAccountDto, int>, IUserAccountService
    {
        private readonly IUserAccountRepository userAccountRepository;
        private readonly IConfiguration configuration;

        public UserAccountService(IUserAccountRepository userAccountRepository,IMapper mapper, IConfiguration configuration)
        {
            this.BaseRepository = userAccountRepository;
            this.userAccountRepository = userAccountRepository;
            this.configuration = configuration;
            this.mapper = mapper;
        }

        public ResultDto Login(LoginDto loginDto)
        {
            var user = userAccountRepository.GetEntity(m => m.Account == loginDto.Account);
            if(user == null)
            {
                return new ResultDto { Code = 1, Msg = "没有此用户" };
            }
            if(user.Password.ToLower() != loginDto.Password.ToLower())
            {
                return new ResultDto { Code = 2, Msg = "密码不对" };
            }

            //生成JWT令牌
            //1、令牌上的信息

            //2、根据算法生成
            IList<Claim> claims = new List<Claim> 
            {
                new Claim(JwtClaimTypes.Id,user.Account)
            };

            //JWT密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:key"]));

            //算法，签名证书
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //过期时间
            DateTime expires = DateTime.UtcNow.AddHours(10);


            //Payload负载
            var token = new JwtSecurityToken(
                issuer: configuration["JwtConfig:Issuer"],
                audience: configuration["JwtConfig:Audience"],
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: expires,
                signingCredentials: cred
                );

            var handler = new JwtSecurityTokenHandler();

            //生成令牌
            string jwt = handler.WriteToken(token);

            return new ResultDto { Code = 0, Token = jwt };
        }

        public async Task T()
        {
            await CreateAsync(new UserAccountDto { });

        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public override async Task CreateAsync(UserAccountDto dto)
        {
            /*登录
            1、验证码
            2、验证用户名和密码（MD5）
            3、写入cookies或JWT
            4、更新用户末次登录IP和时间

            添加账号
            1、工号生成，1000   BW001 - BW999
            2、密码加密MD5 SHA1*/

            await userAccountRepository.CreateAsync(new UserAccount { });
        }
    }
}