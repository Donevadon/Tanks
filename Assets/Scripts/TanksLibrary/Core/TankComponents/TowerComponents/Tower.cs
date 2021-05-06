using DG.Tweening;
using UnityEngine;

namespace TanksLibrary.Core.TankComponents.TowerComponents
{
    public class Tower : MonoBehaviour, IControllerBinder<ITowerController>
    {
        [SerializeField]private float speed = 2;

        void IControllerBinder<ITowerController>.ControllerBind(ITowerController controller)
        {
            controller.OnTurnTowardsPoint += ControllerOnOnRotateTo;
        }

        private void ControllerOnOnRotateTo(object sender, Vector2 vector2)
        {
            var seq = DOTween.Sequence();
            var position = (Vector2)transform.position;
            var rotateDistance = Vector2.Distance(vector2, transform.rotation.eulerAngles);
            
            seq.Append(transform.DORotate(position.AngleParse(vector2), rotateDistance / speed));
        }
    }
}