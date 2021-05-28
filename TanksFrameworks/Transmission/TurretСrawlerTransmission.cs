using LevelCore.MovePointManagement;
using LevelCore.UnitSystem;

namespace Transmission
{
    public class TurretСrawlerTransmission
    {
        private readonly IMovementController _controller;

        public TurretСrawlerTransmission(IMovementController controller)
        {
            _controller = controller;
        }


        public void Play(int index)
        {
            _controller.Play(index);
        }

        
        public void MoveTo(Vector2 movePoint)
        {
            _controller.MoveTo(movePoint);
        }

        
        public void RotateTo(Vector2 rotatePoint)
        {
            _controller.RotateTo(rotatePoint);
        }

        public void Ready()
        {
            _controller.Ready();
        }
    }
}