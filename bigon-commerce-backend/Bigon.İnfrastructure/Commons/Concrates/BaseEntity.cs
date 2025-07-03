namespace Bigon.İnfrastructure.Commons.Concrates
{
    public abstract class BaseEntity<Tkey> : AuditableEntity where Tkey : struct
    {
        public Tkey Id { get; set; }

    }
}
