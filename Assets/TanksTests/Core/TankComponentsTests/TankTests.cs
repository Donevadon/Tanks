using System;
using System.Collections;
using NUnit.Framework;
using TanksLibrary;
using TanksLibrary.Core;
using TanksLibrary.Core.TankComponents;
using TanksLibrary.Core.TankComponents.TowerComponents;
using TanksLibrary.Core.TankComponents.TransmissionComponents;
using TanksLibrary.Core.TankComponents.TransmissionComponents.TrackComponents;
using TanksLibrary.Core.TankComponents.TransmissionComponents.TrackComponents.Tracks;
using TanksTests.Core.TankComponentsTests.TowerComponentsTests;
using TanksTests.Core.TankComponentsTests.TransmissionsComponentsTests;
using UnityEngine;
using UnityEngine.TestTools;
using Object = UnityEngine.Object;

namespace TanksTests.Core.TankComponentsTests
{
    public class TankTests
    {
        private Tank _tank;
        private ITowerEquipmentController _controller;
        
        [SetUp]
        public void Setup()
        {
            _tank = new GameObject("Tank",
                typeof(RightTrack),
                typeof(LeftTrack),typeof(CertainTransmission),
                typeof(Tower))
                .AddComponent<TestTank>();
            _controller = new TestTankController(_tank);
        }


        [TearDown]
        public void TearDown()
        {
            Object.Destroy(_tank.gameObject);
        }
        
        
        private static Vector2[] _movePointValues = {Vector2.one,-Vector2.one,Vector2.down, Vector2.up, Vector2.left, Vector2.right, new Vector2(1,-1), new Vector2(-1,1)}; 
        [UnityTest]
        public IEnumerator TankTestsMoveToPoint([ValueSource(nameof(_movePointValues))]Vector2 vector2)
        {
            _controller.MoveToInvoke(vector2);
            yield return new WaitForSeconds(5);

            Assert.AreEqual((Vector2)_tank.transform.position, vector2);
        }

        
        private static Vector2[] _rotateValues = {Vector2.one,-Vector2.one,Vector2.down, Vector2.up, Vector2.left, Vector2.right, new Vector2(1,-1), new Vector2(-1,1)  }; 
        [UnityTest]
        public IEnumerator TankTowerRotate([ValueSource(nameof(_rotateValues))]Vector2 vector2)
        {
            Transform tankTransform = _tank.transform;
            var tower = tankTransform.GetComponentInChildren<Tower>();
            var position = (Vector2) tankTransform.position;
            
            
            _controller.TowerTurnTowardsPointInvoke(vector2);
            Transform transform = tower.transform;
            var actualAngle = ((Vector2)transform.position).AngleParse(vector2);
            if (actualAngle.z < 0)//Необходимо из за смены отрицательного угла в положительный на объекте
                actualAngle.z = 360 + actualAngle.z;

            yield return new WaitForSeconds(5);
            
            Assert.AreEqual(actualAngle.z,transform.eulerAngles.z, 0.001f);
        }
    }
    

    public class TestTankController : ITowerEquipmentController
    {
        public EventHandler OnClickMouseHandler { get; set; }
        public IControllerBinder<ITowerEquipmentController> Equipment { get; }
        public event EventHandler<Vector2> OnMoveTo;
        public event EventHandler<Vector2> OnTowerTurnTowardsPoint;

        public TestTankController(IControllerBinder<ITowerEquipmentController> tank)
        {
            Equipment = tank;
            Equipment.ControllerBind(this);
        }
        
        public void MoveToInvoke(Vector2 point)
        {
            OnMoveTo?.Invoke(this,point);
        }

        public void TowerTurnTowardsPointInvoke(Vector2 point)
        {
            OnTowerTurnTowardsPoint?.Invoke(this,point);
        }
    }

    public class TestTank : Tank
    {
        protected override IControllerFactory CreateControllerFactory()
        {
            return new TestMonoBehaviorControllerFactory(this);
        }
    }

    public class TestMonoBehaviorControllerFactory : IControllerFactory
    {
        private ITowerController _towerController;
        private ITransmissionController _transmissionController;
        
        public TestMonoBehaviorControllerFactory(MonoBehaviour behaviour)
        {
            var tower = behaviour.GetComponent<Tower>();
            _towerController = new TowerControllerTest(tower);

            var transmission = behaviour.GetComponent<Transmission>();
            _transmissionController = new TransmissionControllerTest(transmission);
        }
        
        public ITowerController GetTowerController()
        {
            return _towerController;
        }

        public ITransmissionController GetTransmissionController()
        {
            return _transmissionController;
        }
    }
}
