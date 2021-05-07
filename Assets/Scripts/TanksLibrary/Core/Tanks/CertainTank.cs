namespace TanksLibrary.Core.Tanks
{
    public class CertainTank : Tank
    {
        protected override IControllerFactory CreateControllerFactory()
        {
            return new MonoBehaviorTankControllerFactory(this);
        }
    }
}