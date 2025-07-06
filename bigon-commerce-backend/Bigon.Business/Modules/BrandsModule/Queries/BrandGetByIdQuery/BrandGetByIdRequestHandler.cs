using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BrandsModule.Queries.BrandGetByIdQuery
{
    internal class BrandGetByIdRequestHandler : IRequestHandler<BrandGetByIdRequest, Brand>
    {
        private readonly IBrandRepository brandRepository;

        public BrandGetByIdRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        public async Task<Brand> Handle(BrandGetByIdRequest request, CancellationToken cancellationToken)
        {
            var model = brandRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);
            return model;
        }
    }
}
