namespace Physics.Domain.Repository
{
    public interface IBaseEntity<T> where T : class
    {
        object GetPrimaryKeyValue();
    }
}
