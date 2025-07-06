using Bigon.İnfrastructure.Entities;
using MediatR;

namespace Bigon.Business.Modules.ColorsModule.Queries.ColorGetByIdQuery
{
    public class ColorGetByIdRequest:IRequest<Color>
    {
        public int Id { get; set; }
    }
   

}
