using System;
using System.Collections;
using NUnit.Framework;
using TanksLibrary.Core;
using TanksLibrary.Core.TankComponents;
using TanksLibrary.Core.TankComponents.TransmissionComponents;
using TanksLibrary.Core.TankComponents.TransmissionComponents.TrackComponents;
using TanksLibrary.Core.TankComponents.TransmissionComponents.TrackComponents.Tracks;
using UnityEngine;
using UnityEngine.TestTools;

namespace TanksTests.Core.TankComponentsTests.TransmissionsComponentsTests
{
    public class TransmissionTests
    {
        private static Vector2[] _moveValues = {Vector2.one,-Vector2.one,Vector2.down, Vector2.up, Vector2.left, Vector2.right, new Vector2(1,-1), new Vector2(-1,1) }; 
        [UnityTest]
        public IEnumerator MoveTransmissionToPoint([ValueSource(nameof(_moveValues))]Vector2 vector2)
        {
            var transmission = new GameObject("transmission",
                    typeof(LeftTrack),
                    typeof(RightTrack))
                .AddComponent<TestTransmission>();
            
            var controller = new TransmissionControllerTest(transmission);


            controller.MoveToInvoke(vector2);
            yield return new WaitForSeconds(5);
            
            Assert.AreEqual((Vector2)transmission.transform.position,vector2);
            
            yield return null;
        }
    }

    public class TransmissionControllerTest : ITransmissionController
    {
        public TransmissionControllerTest(IControllerBinder<ITransmissionController> equipment)
        {
            Equipment = equipment;
            Equipment.ControllerBind(this);
        }

        public IControllerBinder<ITransmissionController> Equipment { get; }
        public event EventHandler<Vector2> OnMoveTo;

        public void MoveToInvoke(Vector2 e)
        {
            OnMoveTo?.Invoke(this,e);
        }
    }

    public class TestTransmission : Transmission
    {
        protected override ITrackFactory CreateTrackFactory()
        {
            return new TestTrackFactory(this);
        }
    }

    public class TestTrackFactory : ITrackFactory
    {
        private LeftTrack _leftTrack;
        private RightTrack _rightTrack;
        public TestTrackFactory(MonoBehaviour behaviour)
        {
            _leftTrack = behaviour.GetComponent<LeftTrack>();
            _rightTrack = behaviour.GetComponent<RightTrack>();
        }
        
        public Track GetLeftTrack()
        {
            return _leftTrack;
        }

        public Track GetRightTrack()
        {
            return _rightTrack;
        }
    }
}
