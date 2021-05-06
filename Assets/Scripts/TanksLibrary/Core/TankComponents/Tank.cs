using System;
using TanksLibrary.Core.TankComponents.TankControllers.TowerControllers;
using TanksLibrary.Core.TankComponents.TankControllers.TransmissionControllers;
using TanksLibrary.Core.TankComponents.TowerComponents;
using TanksLibrary.Core.TankComponents.TransmissionComponents;
using UnityEngine;

namespace TanksLibrary.Core.TankComponents
{
    public class Tank : MonoBehaviour , IControllerBinder<ITowerEquipmentController>,ITargetElement
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

        protected virtual IControllerFactory CreateControllerFactory()
        {
            return new MonoBehaviorTankControllerFactory();
        }

        
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

    internal class MonoBehaviorTankControllerFactory : IControllerFactory
    {
        public ITowerController GetTowerController()
        {
            throw new NotImplementedException();
        }

        public ITransmissionController GetTransmissionController()
        {
            throw new NotImplementedException();
        }
    }
}