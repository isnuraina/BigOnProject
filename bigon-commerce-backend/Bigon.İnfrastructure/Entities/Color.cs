using Bigon.İnfrastructure.Commons.Concrates;

namespace Bigon.İnfrastructure.Entities
{
    public class Color : BaseEntity<int>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }

    }
}
