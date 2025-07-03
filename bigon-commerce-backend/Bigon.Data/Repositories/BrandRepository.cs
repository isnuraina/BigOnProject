using Bigon.İnfrastructure.Commons.Concrates;
using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Data.Repositories
{
    public class BrandRepository : GeneralRepository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext db) : base(db)
        {
        }
    }
}
