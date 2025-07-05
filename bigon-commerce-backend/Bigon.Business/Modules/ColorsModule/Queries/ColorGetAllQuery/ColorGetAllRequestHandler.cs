﻿using Bigon.İnfrastructure.Entities;
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
    internal class ColorGetAllRequestHandler : IRequestHandler<ColorGetAllRequest, IEnumerable<Color>>
    {
        private readonly IColorRepository colorRepository;

        public ColorGetAllRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }
        public async Task<IEnumerable<Color>> Handle(ColorGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = colorRepository.GetAll(m=>m.DeletedBy == null);
            return await data.ToListAsync(cancellationToken);
        }
    }
}
