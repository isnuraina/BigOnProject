using Bigon.İnfrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BrandsModule.Commands.BrandEditCommand
{
    public class BrandEditRequest:IRequest<Brand>
    {
        public byte Id { get; set; }
        public string Name { get; set; }

    }
}
