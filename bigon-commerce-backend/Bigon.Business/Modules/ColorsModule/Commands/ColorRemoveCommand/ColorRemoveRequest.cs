using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Commands.ColorRemoveCommand
{
    public class ColorRemoveRequest: IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
