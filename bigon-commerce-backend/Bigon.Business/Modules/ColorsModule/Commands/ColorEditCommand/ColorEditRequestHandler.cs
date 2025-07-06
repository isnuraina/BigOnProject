using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bigon.Business.Modules.ColorsModule.Commands.ColorEditCommand
{
    internal class ColorEditRequestHandler : IRequestHandler<ColorEditRequest, Color>
    {
        private readonly IColorRepository colorRepository;

        public ColorEditRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async  Task<Color> Handle(ColorEditRequest request, CancellationToken cancellationToken)
        {
            
            var color = new Color
            {
                Id = request.Id,
                Name = request.Name,
                HexCode = request.HexCode
            };
            colorRepository.Edit(color);
            colorRepository.Save();
            return color;
        }
    }
}
