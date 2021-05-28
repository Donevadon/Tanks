using UnityEngine;
using Transmission;
using Vector2 = UnityEngine.Vector2;


namespace TanksLibrary.Main
{
    public class MonoBehTransmission : MonoBehaviour
    {
        private TurretСrawlerTransmission _transmission;

        private void Awake()
        {
            _transmission = new TurretСrawlerTransmission(
                new TransmissionControllerAdapter(
                    new MovementController(transform.parent)));
        }

        
        public void Play(int index)
        {
            _transmission.Play(index);
        }

        
        public void MoveTo(Vector2 movePoint)
        {
            //_transmission.MoveTo(movePoint);
        }

        
        public void RotateTo(Vector2 rotatePoint)
        {
            //_transmission.RotateTo(rotatePoint);
        }

        public void Ready()
        {
            _transmission.Ready();
        }
    }
}