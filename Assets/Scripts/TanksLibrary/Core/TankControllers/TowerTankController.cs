using System;
using UnityEngine;

namespace TanksLibrary.Core.TankControllers
{
    public class TowerTankController : ITowerController
    {
        private readonly IControllerBinder<ITowerController> _equipment;
        public event EventHandler<Vector2> OnTurnTowardsPoint;

        public TowerTankController(IControllerBinder<ITowerController> equipment)
        {
            _equipment = equipment;
            _equipment.ControllerBind(this);
        }

        public void TurnTowardsPoint(Vector2 point)
        {
            OnTurnTowardsPoint?.Invoke(this,point);
        }
    }
}