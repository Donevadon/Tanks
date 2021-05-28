using System;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace TanksLibrary.Main
{
    public class MovementController : IMoveController
    {
        private readonly Transform _transform;
        private readonly List<Sequence> _sequences;
        private Sequence _currentSequence;
        private readonly List<Func<Transform,Tween>> _tweens;
        

        public MovementController(Transform transform)
        {
            _transform = transform;
            _sequences = new List<Sequence>();
            _tweens = new List<Func<Transform, Tween>>();
        }
        
        
        public void Play(int index)
        {
            if (index == _sequences.Count)
            {
                _currentSequence?.Rewind();
                _currentSequence.Kill();
                _currentSequence = DOTween.Sequence();
                foreach (var tween in _tweens)
                {
                    _currentSequence.Append(tween(_transform));
                }

                _currentSequence.Play();
            }
            else
            {
                _sequences[index].Restart();
            }
        }

        public void MoveTo(Vector2 movePoint)
        {
            Move(movePoint);
        }

        private void Rotate(Vector2 point)
        {
            var position = (Vector2)_transform.position;
            
            //_tweens.Add(_transform.DORotate(position.AngleParse(point), 1).SetEase(Ease.InOutCubic));
        }


        private void Move(Vector2 point)
        {
            var position = (Vector2)_transform.position;
            var distance = Vector2.Distance(position, point);

            _tweens.Add(DOMove);//_transform.DOMove(point, distance / 2f).SetEase(Ease.InOutCubic));
            
            Tween DOMove(Transform target)
            {
                TweenerCore<Vector3, Vector3, VectorOptions> t = DOTween.To((DOGetter<Vector3>) (() => target.position), (DOSetter<Vector3>) (x => target.position = x), point, distance / 2f);
                t.SetOptions(false).SetTarget<Tweener>((object) target);
                return t;
            }
        }
        
        

        public void RotateTo(Vector2 point)
        {
            Rotate(point);
        }

        public void Ready()
        {
            _currentSequence.Rewind();
            var sequence = DOTween.Sequence();
            foreach (var tween in _tweens)
            {
                sequence.Append(tween(_transform));
            }
            _sequences.Add(sequence);
        }
    }
}