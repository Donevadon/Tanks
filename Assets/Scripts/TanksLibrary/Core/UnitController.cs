using System;
using System.Collections.Generic;
using TanksLibrary.Core.TankComponents;
using TanksLibrary.Core.TowerEquipmentControllers;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace TanksLibrary.Core
{
    public abstract class UnitController : MonoBehaviour
    {
        private List<ITowerEquipmentController> _controllers;
        private ITargetSystem _targetSystem;

        private void Awake()
        {
            Init();
            CreateTank();
        }

        private void Init()
        {
            _targetSystem = GetTargetSystem();
        }

        protected abstract ITargetSystem GetTargetSystem();

        private void CreateTank()
        {
            _controllers = new List<ITowerEquipmentController>();
            var prefab = GetPrefabTank();
            var tank = Instantiate(prefab).GetComponent<IControllerBinder<ITowerEquipmentController>>();
            var pack = ControllerBind(tank);
            _controllers.Add(pack);
        }
        
        protected abstract GameObject GetPrefabTank();

        
        private ITowerEquipmentController ControllerBind(IControllerBinder<ITowerEquipmentController> binder)
        {
            var controller = GetTowerController(binder);
            controller.OnClickMouseHandler += OnClickHandler;
            return controller;
        }
        
        protected abstract ITowerEquipmentController GetTowerController(
            IControllerBinder<ITowerEquipmentController> binder);
        
        private void OnClickHandler(object sender,EventArgs e)
        {
            ITargetElement target = sender as ITargetElement
                          ?? throw new FormatException("Неверный тип таргета");
            _targetSystem.SetTarget(target);
        }
    }
}