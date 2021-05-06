using System;
using UnityEngine;

namespace TanksLibrary.Core.TankComponents
{
    public interface ITowerController
    {
        IControllerBinder<ITowerController> Equipment { get; }

        event EventHandler<Vector2> OnTurnTowardsPoint;
        void TurnTowardsPoint(Vector2 point);
    }
}