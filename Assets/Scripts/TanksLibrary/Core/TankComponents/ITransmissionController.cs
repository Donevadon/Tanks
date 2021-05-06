using System;
using UnityEngine;

namespace TanksLibrary.Core.TankComponents
{
    public interface ITransmissionController
    {
        IControllerBinder<ITransmissionController> Equipment { get; }

        event EventHandler<Vector2> OnMoveTo;
        void MoveToInvoke(Vector2 to);
    }
}