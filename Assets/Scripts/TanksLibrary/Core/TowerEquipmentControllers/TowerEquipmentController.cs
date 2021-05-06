using System;
using UnityEngine;

namespace TanksLibrary.Core.TowerEquipmentControllers
{
    public class TowerEquipmentController : ITowerEquipmentController
    {
        public EventHandler OnClickMouseHandler { get; set; }

        public IControllerBinder<ITowerEquipmentController> Equipment { get;}
        public event EventHandler<Vector2> OnMoveTo;
        public event EventHandler<Vector2> OnTowerTurnTowardsPoint;

        public TowerEquipmentController(IControllerBinder<ITowerEquipmentController> binder)
        {
            Equipment = binder;
            Equipment.ControllerBind(this);
        }
        
        
        public void MoveToInvoke(Vector2 to)
        {
            OnMoveTo?.Invoke(this,to);
        }

        public void TowerTurnTowardsPointInvoke(Vector2 point)
        {
            OnTowerTurnTowardsPoint?.Invoke(this,point);
        }
    }
}
