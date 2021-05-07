using System;
using UnityEngine;

namespace TanksLibrary.Core
{
    public abstract class Tank : MonoBehaviour , IControllerBinder<ITowerEquipmentController>,ITargetElement
    {
        private event EventHandler ONMouseClick;
        private ITowerController _towerController;
        private ITransmissionController _transmissionController;

        private void Awake()
        {
            InitControllers();
        }

        private void InitControllers()
        {
            var factory = CreateControllerFactory();
            _towerController = factory.GetTowerController();
            _transmissionController = factory.GetTransmissionController();
        }

        protected abstract IControllerFactory CreateControllerFactory();


        void IControllerBinder<ITowerEquipmentController>.ControllerBind(ITowerEquipmentController controller)
        {
            controller.OnMoveTo += ControllerOnMoveTo; 
            controller.OnTowerTurnTowardsPoint += ControllerOnTurnTowardsPoint;
            ONMouseClick += (sender,e) => controller.OnClickMouseHandler?.Invoke(sender,e);
        }
        
        private void ControllerOnMoveTo(object sender, Vector2 to)
        {
            _transmissionController.MoveToInvoke(to);
        }
        
        private void ControllerOnTurnTowardsPoint(object sender, Vector2 to)
        {
            _towerController.TurnTowardsPoint(to);
        }


        private void OnMouseUp()
        {
            ONMouseClick?.Invoke(this,null);
        }

        
        void ITargetElement.EnableHighlighting()
        {
            Debug.Log("Подсветка включена");
        }

        void ITargetElement.DisableHighlighting()
        {
            Debug.Log("Подсветка выключена");
        }
    }
}