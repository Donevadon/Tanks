using TanksLibrary.Core.TowerEquipmentControllers;
using TanksLibrary.Core.UnitControllerBehaviours;
using UnityEngine;

namespace TanksLibrary.Core.UnitControllers
{
    public class PlayerUnitController : UnitController
    {
        protected override ITargetSystem GetTargetSystem()
        {
            return new TargetBehaviour();
        }

        protected override GameObject GetPrefabTank()
        {
            return Resources.Load<GameObject>("Tanks/DefaultTank");
        }

        protected override ITowerEquipmentController GetTowerController(IControllerBinder<ITowerEquipmentController> binder)
        {
            return new TowerEquipmentController(binder);
        }
    }
}