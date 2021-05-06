using System;
using TanksLibrary.Core.TankComponents.TransmissionComponents;
using UnityEngine;

namespace TanksLibrary.Core.TankComponents.TankControllers.TransmissionControllers
{
    public class TransmissionTankController : ITransmissionController
    {
        public IControllerBinder<ITransmissionController> Equipment { get; }
        public event EventHandler<Vector2> OnMoveTo;

        public TransmissionTankController(IControllerBinder<ITransmissionController> equipment)
        {
            Equipment = equipment;
            Equipment.ControllerBind(this);
        }

        
        public void MoveToInvoke(Vector2 to)
        {
            OnMoveTo?.Invoke(this,to);
        }
    }
}