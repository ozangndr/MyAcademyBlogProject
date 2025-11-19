using Blogy.DataAccess.Context;
using Blogy.DataAccess.Repositories.GenericRepositories;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.DataAccess.Repositories.CommunucationRepositories
{
    public class CommunucationRepository : GenericRepository<Communucation>, ICommunucationRepository
    {
        public CommunucationRepository(AppDbContext context) : base(context)
        {
        }
    }
}
