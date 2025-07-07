using Bigon.İnfrastructure.Commons.Concrates;
using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Data.Repositories
{
    internal class BlogPostRepository : GeneralRepository<BlogPost>, IBlogPostRepository
    {
        public BlogPostRepository(DbContext db) : base(db)
        {
        }
    }
}
