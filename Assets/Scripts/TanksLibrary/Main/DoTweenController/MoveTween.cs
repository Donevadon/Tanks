using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

namespace TanksLibrary.Main.DoTweenController
{
    public class MoveTween : ITween
    {
        private readonly Vector2 _point;

        public MoveTween(Vector2 point)
        {
            _point = point;
        }


        public Tween GetTween(Transform target)
        {
            var position = (Vector2) target.position;
            var distance = Vector2.Distance(position, _point);

            var t = DOTween.To(() => target.position, (DOSetter<Vector3>) (x => target.position = x), _point,
                distance / 2f);
            t.SetOptions(false).SetTarget(target);
            return t;
        }
    }
}