using Bigon.İnfrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Queries.ColorGetByIdQuery
{
    public class ColorGetByIdRequest:IRequest<Color>
    {
        public int Id { get; set; }
    }
   

}
