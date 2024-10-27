namespace JustMobyTest.Factory
{   
    public class ControllerFactory<TController>
        where TController : IController, new()
    {
        public TController CreateController() => new TController();
    }
}