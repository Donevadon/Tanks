using DG.Tweening;
using UnityEngine;

namespace TanksLibrary.Core.TankComponents.TowerComponents
{
    public class Tower : MonoBehaviour
    {
        [SerializeField]private float speed = 2;

        private void ControllerOnOnRotateTo(object sender, Vector2 vector2)
        {
            var seq = DOTween.Sequence();
            var position = (Vector2)transform.position;
            var rotateDistance = Vector2.Distance(vector2, transform.rotation.eulerAngles);
            
            seq.Append(transform.DORotate(position.AngleParse(vector2), rotateDistance / speed));
        }
    }
}