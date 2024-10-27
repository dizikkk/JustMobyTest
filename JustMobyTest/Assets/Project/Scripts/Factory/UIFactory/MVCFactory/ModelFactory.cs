namespace JustMobyTest.Factory
{
    public class ModelFactory<TModel> 
        where TModel : IModel, new()
    {
        public TModel CreateModel() => new TModel();
    }
}