namespace MVCECommerceProject.CORE.Entity
{
    public interface IEntity<T>
    {
        T ID { get; set; }
    }
}