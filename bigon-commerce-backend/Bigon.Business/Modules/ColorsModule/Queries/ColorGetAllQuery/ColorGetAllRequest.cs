using Bigon.İnfrastructure.Commons.Abstracts;
using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Queries.ColorGetAllQuery
{
    public class ColorGetAllRequest:IRequest<IEnumerable<Color>>
    {
    }
  
}
