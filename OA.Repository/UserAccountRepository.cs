using OA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OA.Repository
{
    public class UserAccountRepository : BaseRepository<UserAccount, int>, IUserAccountRepository
    {
        public UserAccountRepository(OaDbContext db)
        {
            this.db = db;
        }
    }
}
