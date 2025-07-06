using Bigon.İnfrastructure.Repositories;
using MediatR;

namespace Bigon.Business.Modules.ColorsModule.Commands.ColorRemoveCommand
{
    internal class ColorRemoveRequestHandler : IRequestHandler<ColorRemoveRequest, Unit>
    {
        private readonly IColorRepository colorRepository;

        public ColorRemoveRequestHandler(IColorRepository colorRepository)
        {
            this.colorRepository = colorRepository;
        }

        public async Task<Unit> Handle(ColorRemoveRequest request, CancellationToken cancellationToken)
        {
            var color = colorRepository.Get(m => m.Id == request.Id);
            if (color == null)
                throw new KeyNotFoundException($"Color with Id {request.Id} not found.");

            colorRepository.Remove(color);
            colorRepository.Save();

            return Unit.Value;
        }
    }
}
