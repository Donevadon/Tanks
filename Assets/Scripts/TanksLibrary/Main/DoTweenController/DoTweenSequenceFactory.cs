using SequentialMovement;
using UnityEngine;
using Vector2 = SequentialMovement.Vector2;

namespace TanksLibrary.Main.DoTweenController
{
    public class DoTweenSequenceFactory : ISequenceFactory
    {
        private readonly Transform _transform;

        public DoTweenSequenceFactory(Transform transform)
        {
            _transform = transform;
        }
        
        public ISequence Create(Vector2 startPosition, Vector2 startRotation)
        {
            return new SequenceWrapper(startPosition,Quaternion.Euler(new Vector3(startRotation.X,startRotation.Y)), _transform);
        }
    }
}