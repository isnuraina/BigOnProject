using Bigon.İnfrastructure.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Commands.ColorAddCommand
{
    public class ColorAddRequest:IRequest<Color>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}
