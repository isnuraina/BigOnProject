using Bigon.İnfrastructure.Commons.Concrates;
using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Bigon.Data.Repositories
{
    internal class SubscriberRepository : GeneralRepository<Subscriber>, ISubscriberRepository
    {
        public SubscriberRepository(DbContext db) : base(db)
        {

        }
    }
}
