using System;
using System.Collections;
using NUnit.Framework;
using TanksLibrary;
using TanksLibrary.Core;
using TanksLibrary.Core.TankComponents;
using TanksLibrary.Core.TankComponents.TowerComponents;
using UnityEngine;
using UnityEngine.TestTools;

namespace TanksTests.Core.TankComponentsTests.TowerComponentsTests
{
    public class TowerTests
    {
        private static Vector2[] _rotateValue = {Vector2.one,-Vector2.one,Vector2.down, Vector2.up, Vector2.left, Vector2.right, new Vector2(1,-1), new Vector2(-1,1)};
        [UnityTest]
        public IEnumerator RotateTowerTo([ValueSource(nameof(_rotateValue))]Vector2 to)
        {
            var tower = new GameObject().AddComponent<Tower>();
            var controller = new TowerControllerTest(tower);
            
            controller.TurnTowardsPoint(to);
            Transform transform = tower.transform;
            var actualAngle = ((Vector2) transform.position).AngleParse(to);
            if (actualAngle.z < 0)//Необходимо из за смены отрицательного угла в положительный на объекте
                actualAngle.z = 360 + actualAngle.z;
            yield return new WaitForSeconds(5);

            
            Assert.AreEqual(actualAngle.z,transform.eulerAngles.z,0.001f);
        }
    }

    public class TowerControllerTest : ITowerController
    {
        public TowerControllerTest(IControllerBinder<ITowerController> equipment)
        {
            Equipment = equipment;
            Equipment.ControllerBind(this);
        }

        public IControllerBinder<ITowerController> Equipment { get; }
        public event EventHandler<Vector2> OnTurnTowardsPoint;
        public void TurnTowardsPoint(Vector2 point)
        {
            OnTurnTowardsPoint?.Invoke(this,point);
        }
    }
}
