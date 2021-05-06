namespace TanksLibrary.Core.TankComponents
{
    public interface IControllerFactory
    {
        ITowerController GetTowerController();
        ITransmissionController GetTransmissionController();
    }
}