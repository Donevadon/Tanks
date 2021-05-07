using TanksLibrary.Core.TankComponents;

namespace TanksLibrary.Core
{
    public interface IControllerFactory
    {
        ITowerController GetTowerController();
        ITransmissionController GetTransmissionController();
    }
}