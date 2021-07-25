using System.Collections.Generic;
using DG.Tweening;
using SequentialMovement;
using UnityEngine;
using Vector2 = SequentialMovement.Vector2;

namespace TanksLibrary.Main.DoTweenController
{
    internal class SequenceWrapper : ISequence
    {
        private readonly Quaternion _startRotation;
        private readonly Vector2 _startPosition;
        private readonly Transform _transform;
        private readonly List<ITween> _tweenList;
        private readonly ISequenceBuilder _builder;
        private Sequence _currentSequence;

        public SequenceWrapper(Vector2 startPosition,Quaternion startRotation, Transform transform)
        {
            _transform = transform;
            _startRotation = startRotation;
            _startPosition = startPosition;
            _tweenList = new List<ITween>();
            _builder = new SequencePlayer(_tweenList, _transform);
        }


        public void Play()
        {
            _transform.position = new Vector3(_startPosition.X, _startPosition.Y);
            _transform.rotation = _startRotation;
            _currentSequence = _builder.Build();
            _currentSequence.Play();
        }

        public void Rewind()
        {
            _currentSequence?.Kill();
            _currentSequence = null;
            _transform.position = new Vector3(_startPosition.X, _startPosition.Y);
        }

        public void AddMove(Vector2 movePoint)
        {
            _tweenList.Add(new MoveTween
            (new UnityEngine.Vector2()
            {
                x = movePoint.X,
                y = movePoint.Y
            }));
        }

        public void AddRotate(Vector2 rotatePoint)
        {
            _tweenList.Add(new RotateTween(new UnityEngine.Vector2()
            {
                x = rotatePoint.X,
                y = rotatePoint.Y
            }));
        }

        public Vector2 RecordAndGetLastPosition(out Vector2 lastRotation)
        {
            var sequence = _builder.Build();
            sequence.Complete();
            var position = _transform.position;
            var rotation = _transform.rotation;
            lastRotation = new Vector2() {X = rotation.eulerAngles.x, Y = rotation.eulerAngles.y};
            
            return new Vector2()
            {
                X = position.x,
                Y = position.y
            };
        }
    }
}