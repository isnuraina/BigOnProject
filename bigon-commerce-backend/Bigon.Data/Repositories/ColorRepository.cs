using Bigon.İnfrastructure.Commons.Concrates;
using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bigon.Data.Repositories
{
    public class ColorRepository : GeneralRepository<Color>, IColorRepository
    {
        public ColorRepository(DbContext db) : base(db)
        {
        }
    }
}
