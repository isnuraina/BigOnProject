using Bigon.İnfrastructure.Commons.Concrates;

namespace Bigon.İnfrastructure.Entities
{
    public class Size : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

    }
}
