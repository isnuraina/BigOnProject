using Bigon.WebUI.Models.Entities.Commons;

namespace Bigon.WebUI.Models.Entities
{
    public class Size : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }

    }
}
