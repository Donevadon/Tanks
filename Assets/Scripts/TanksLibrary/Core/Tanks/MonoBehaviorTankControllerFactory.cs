using UnityEngine;

namespace TanksLibrary.Core.Tanks
{
    internal class MonoBehaviorTankControllerFactory : IControllerFactory
    {
        private readonly MonoBehaviour _monoBehaviour;

        public MonoBehaviorTankControllerFactory(MonoBehaviour monoBehaviour)
        {
            _monoBehaviour = monoBehaviour;
        }
        
        public ITowerController GetTowerController()
        {
            var tower = _monoBehaviour.GetComponent<IControllerBinder<ITowerController>>();
            return new TankControllers.TowerTankController(tower);
        }
        
        
        public ITransmissionController GetTransmissionController()
        {
            var tm = _monoBehaviour.GetComponent<IControllerBinder<ITransmissionController>>();
            return new TankControllers.TransmissionTankController(tm);
        }
    }
}