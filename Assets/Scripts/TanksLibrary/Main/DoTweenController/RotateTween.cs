using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace TanksLibrary.Main.DoTweenController
{
    public class RotateTween : ITween
    {
        private readonly Vector2 _point;

        public RotateTween(Vector2 point)
        {
            _point = point;
        }


        public Tween GetTween(Transform target)
        {
            var endPoint = ((Vector2) target.position).AngleParse(_point);
            
            var t = DOTween.To(
                (() => target.rotation), (x => target.rotation = x),
                endPoint, 2);
            t.SetTarget(target);
            t.plugOptions.rotateMode = RotateMode.Fast;

            return t;
        }

    }
}