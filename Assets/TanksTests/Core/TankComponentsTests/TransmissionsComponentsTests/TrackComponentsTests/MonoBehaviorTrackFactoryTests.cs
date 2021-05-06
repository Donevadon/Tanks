using NUnit.Framework;
using TanksLibrary.Core.TankComponents.TransmissionComponents.TrackComponents;
using TanksLibrary.Core.TankComponents.TransmissionComponents.TrackComponents.Tracks;
using UnityEngine;

namespace TanksTests.Core.TankComponentsTests.TransmissionsComponentsTests.TrackComponentsTests
{
    public class MonoBehaviorTrackFactoryTests
    {
        private TestMonoBehavior _gameObject;
        
        [SetUp]
        public void Setup()
        {
            _gameObject = new GameObject().AddComponent<TestMonoBehavior>();
            new GameObject().AddComponent<LeftTrack>().transform.parent = _gameObject.transform;
            new GameObject().AddComponent<RightTrack>().transform.parent = _gameObject.transform;
        }
        
        [Test]
        public void GetLeftTrackTest()
        {
            MonoBehaviorTrackFactory factory = new MonoBehaviorTrackFactory(_gameObject);

            var track = factory.GetLeftTrack();

            Assert.AreEqual(Side.Left, track.Side);
        }
        
        [Test]
        public void GetRightTrackTest()
        {
            MonoBehaviorTrackFactory factory = new MonoBehaviorTrackFactory(_gameObject);

            var track = factory.GetRightTrack();

            Assert.AreEqual(Side.Right, track.Side);
        }


        [TearDown]
        public void TearDown()
        {
            Object.Destroy(_gameObject.gameObject);
        }
    }

    public class TestMonoBehavior : MonoBehaviour
    {
        
    }
}
