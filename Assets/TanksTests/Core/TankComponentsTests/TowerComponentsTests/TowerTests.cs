using System;
using System.Collections;
using NUnit.Framework;
using TanksLibrary;
using TanksLibrary.Core;
using TanksLibrary.Core.TankComponents;
using TanksLibrary.Core.TankComponents.TowerComponents;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace TanksTests.Core.TankComponentsTests.TowerComponentsTests
{
    public class TowerTests
    {
        private TowerControllerTest _controller;
        private Tower _tower;

        [SetUp]
        public void Setup()
        {
            _tower = new GameObject().AddComponent<Tower>();
            _controller = new TowerControllerTest(_tower);
        } 
        
        private static Vector2[] _rotateValue = {Vector2.one,-Vector2.one,Vector2.down, Vector2.up, Vector2.left, Vector2.right, new Vector2(1,-1), new Vector2(-1,1)};
        [UnityTest]
        public IEnumerator RotateTowerTo([ValueSource(nameof(_rotateValue))]Vector2 to)
        {
            
            _controller.TurnTowardsPoint(to);
            Transform transform = _tower.transform;
            var actualAngle = ((Vector2) transform.position).AngleParse(to);
            if (actualAngle.z < 0)//Необходимо из за смены отрицательного угла в положительный на объекте
                actualAngle.z = 360 + actualAngle.z;
            yield return new WaitForSeconds(5);

            
            Assert.AreEqual(actualAngle.z,transform.eulerAngles.z,0.001f);
        }
        
        [TearDown]
        public void TearDown()
        {
            Object.Destroy(_tower.gameObject);
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
