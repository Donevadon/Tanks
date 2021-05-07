using System;
using UnityEngine;

namespace TanksLibrary.Core.TankControllers
{
    public class TransmissionTankController : ITransmissionController
    {
        private readonly IControllerBinder<ITransmissionController> _equipment;
        public event EventHandler<Vector2> OnMoveTo;

        public TransmissionTankController(IControllerBinder<ITransmissionController> equipment)
        {
            _equipment = equipment;
            _equipment.ControllerBind(this);
        }

        
        public void MoveToInvoke(Vector2 to)
        {
            OnMoveTo?.Invoke(this,to);
        }
    }
}