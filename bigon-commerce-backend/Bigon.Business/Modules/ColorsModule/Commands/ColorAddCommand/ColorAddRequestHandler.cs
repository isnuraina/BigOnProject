﻿using Bigon.İnfrastructure.Entities;
using Bigon.İnfrastructure.Repositories;
using MediatR;

namespace Bigon.Business.Modules.ColorsModule.Commands.ColorAddCommand
{
    internal class ColorAddRequestHandler : IRequestHandler<ColorAddRequest, Color>
    {
        private readonly IColorRepository colorRepository;

        public ColorAddRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorAddRequest request, CancellationToken cancellationToken)
        {
            var color = new Color()
            {
                Name = request.Name,

                HexCode = request.HexCode
            };
            colorRepository.Add(color);
            colorRepository.Save();
            return color;
        }
    }
}
