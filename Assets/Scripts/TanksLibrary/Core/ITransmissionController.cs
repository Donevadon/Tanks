using System;
using UnityEngine;

namespace TanksLibrary.Core
{
    public interface ITransmissionController
    {
        event EventHandler<Vector2> OnMoveTo;
        void MoveToInvoke(Vector2 to);
    }
}