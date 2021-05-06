using System;
using TanksLibrary.Core.TankComponents.TowerComponents;
using UnityEngine;

namespace TanksLibrary.Core.TankComponents.TankControllers.TowerControllers
{
    public class TowerTankController : ITowerController
    {
        public TowerTankController(IControllerBinder<ITowerController> equipment)
        {
            Equipment = equipment;
            Equipment.ControllerBind(this);
        }

        public IControllerBinder<ITowerController> Equipment { get; }
        public event EventHandler<Vector2> OnTurnTowardsPoint;
        public void TurnTowardsPoint(Vector2 point)
        {
            OnTurnTowardsPoint?.Invoke(this,point);
        }
    }
}