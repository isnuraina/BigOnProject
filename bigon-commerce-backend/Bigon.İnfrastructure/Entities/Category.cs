using Bigon.İnfrastructure.Commons.Concrates;

namespace Bigon.İnfrastructure.Entities
{
    public class Category : BaseEntity<int>
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }

    }
}
