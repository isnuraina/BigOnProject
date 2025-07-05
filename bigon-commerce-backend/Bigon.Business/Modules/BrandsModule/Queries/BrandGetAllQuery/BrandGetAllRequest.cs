using Bigon.İnfrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.BrandsModule.Queries.BrandGetAllQuery
{
    public class BrandGetAllRequest:IRequest<IEnumerable<Brand>>
    {
    }
   
}
