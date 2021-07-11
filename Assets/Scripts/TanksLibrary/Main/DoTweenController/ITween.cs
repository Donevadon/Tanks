using DG.Tweening;
using UnityEngine;

namespace TanksLibrary.Main.DoTweenController
{
    internal interface ITween
    {
        Tween GetTween(Transform transform);
    }
}