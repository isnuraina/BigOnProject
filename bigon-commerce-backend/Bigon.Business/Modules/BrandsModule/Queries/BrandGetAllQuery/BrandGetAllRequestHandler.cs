using Bigon.Data.Repositories;
using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BrandsModule.Queries.BrandGetAllQuery
{
    internal class BrandGetAllRequestHandler : IRequestHandler<BrandGetAllRequest, IEnumerable<Brand>>
    {
        private readonly IBrandRepository brandRepository;

        public BrandGetAllRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<IEnumerable<Brand>> Handle(BrandGetAllRequest request, CancellationToken cancellationToken)
        {

            var query = brandRepository.GetAll(m => m.DeletedBy == null); 
            return await query.ToListAsync(cancellationToken);
         
        }
    }
}


