using System;
using UnityEngine;

namespace TanksLibrary.Core
{
    public interface ITowerController
    {
        event EventHandler<Vector2> OnTurnTowardsPoint;
        void TurnTowardsPoint(Vector2 point);
    }
}