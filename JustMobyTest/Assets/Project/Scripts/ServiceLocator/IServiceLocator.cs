namespace JustMobyTest.ServiceLocator
{
    public interface IServiceLocator
    {
        public void Add<T>(T obj);
        public T Get<T>();
    }
}