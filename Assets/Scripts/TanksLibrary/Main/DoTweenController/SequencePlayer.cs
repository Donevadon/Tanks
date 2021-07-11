using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace TanksLibrary.Main.DoTweenController
{
    internal class SequencePlayer : ISequenceBuilder
    {
        private readonly List<ITween> _tweenList;
        private readonly Transform _transform;
        
        public SequencePlayer(List<ITween> tweenList, Transform transform)
        {
            _tweenList = tweenList;
            _transform = transform;
        }

        public Sequence Build()
        {
            var sequence = DOTween.Sequence();
            foreach (var tween in _tweenList)
            {
                sequence.Append(tween.GetTween(_transform));
            }
            sequence.OnComplete(() => sequence.Kill());
            
            return sequence;
        }
    }
}