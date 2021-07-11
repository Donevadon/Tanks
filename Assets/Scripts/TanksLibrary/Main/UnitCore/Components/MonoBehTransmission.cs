using SequentialMovement;
using TanksLibrary.Main.DoTweenController;
using Transmission;
using UnityEngine;
using Vector2 = SequentialMovement.Vector2;


namespace TanksLibrary.Main.UnitCore.Components
{
    public class MonoBehTransmission : MonoBehaviour
    {
        private TurretСrawlerTransmission _transmission;

        private void Awake()
        {
            var transform1 = transform;
            var position = transform1.position;
            _transmission = new TurretСrawlerTransmission(
                new UnitControllerAdapter(
                    new MovementController(
                        new DoTweenSequenceFactory(transform1.parent), 
                            new Vector2()
                            {
                                X = position.x,
                                Y = position.y
                            })));
        }

        
        public void Play()
        {
            _transmission.Play();
        }

        
        public void MoveTo(UnityEngine.Vector2 movePoint)
        {
            _transmission.MoveTo(new Transmission.Vector2()
            {
                X = movePoint.x,
                Y = movePoint.y
            });
        }

        
        public void RotateTo(UnityEngine.Vector2 rotatePoint)
        {
            //_transmission.RotateTo(rotatePoint);
        }

        
        public void Ready()
        {
            _transmission.Ready();
        }


        public void SetupCurrentIndex(int index)
        {
            _transmission.SetupCurrentIndex(index);
        }
    }
}