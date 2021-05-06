using System;
using UnityEngine;

namespace TanksLibrary.Core
{
    public interface ITowerEquipmentController
    {
        EventHandler OnClickMouseHandler { get; set; }

        IControllerBinder<ITowerEquipmentController> Equipment { get; }

        event EventHandler<Vector2> OnMoveTo;
        event EventHandler<Vector2> OnTowerTurnTowardsPoint;

        void MoveToInvoke(Vector2 to);
        void TowerTurnTowardsPointInvoke(Vector2 point);
    }
}