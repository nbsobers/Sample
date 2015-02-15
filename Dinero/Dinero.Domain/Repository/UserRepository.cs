using Dinero.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinero.Domain.Repository
{
    public class UserRepository : Repository<User>
    {

        public UserRepository(DineroDbContext dbContext)
            :base(dbContext)
        {

        }

        public User FindUserByEmail(string email)
        {
            return DbContext.Users.FirstOrDefault(x => x.Email == email);
        }

    }
}
