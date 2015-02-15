using Dinero.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dinero.Domain.Repository
{
    public class UserCompanyRepository : Repository<UserRepository>
    {

        public UserCompanyRepository(DineroDbContext dbContext ) : base(dbContext) { }

        public IEnumerable<UserCompany> GetUserCompanies(int userId)
        {
            return DbContext.UserCompanies.Include("Company").Where(x => x.UserId == userId).ToList();
        }

    }
}
