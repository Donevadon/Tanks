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
        
        public ISequence Create(Vector2 startPosition)
        {
            return new SequenceWrapper(startPosition, _transform);
        }
    }
}