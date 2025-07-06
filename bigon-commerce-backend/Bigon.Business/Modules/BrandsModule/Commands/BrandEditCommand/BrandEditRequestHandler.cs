using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BrandsModule.Commands.BrandEditCommand
{
    internal class BrandEditRequestHandler : IRequestHandler<BrandEditRequest, Brand>
    {
        private readonly IBrandRepository brandRepository;

        public BrandEditRequestHandler(IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }
        public async Task<Brand> Handle(BrandEditRequest request, CancellationToken cancellationToken)
        {
            var brand = new Brand
            {
                Id = request.Id,
                Name = request.Name
            };
            brandRepository.Edit(brand);
            brandRepository.Save();
            return brand;
        }
    }
}
