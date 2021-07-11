using SequentialMovement;
using Transmission;
using Vector2 = Transmission.Vector2;

namespace TanksLibrary.Main.UnitCore
{
    internal class UnitControllerAdapter : IMovementController
    {
        private readonly ISequenceController _controller;

        public UnitControllerAdapter(ISequenceController controller)
        {
            _controller = controller;
        }


        public void Play()
        {
            _controller.Play();
        }

        
        public void MoveTo(Vector2 movePoint)
        {
            _controller.MoveTo(new SequentialMovement.Vector2()
            {
                X = movePoint.X,
                Y = movePoint.Y
            });
        }

        
        public void RotateTo(Vector2 rotatePoint)
        {
            _controller.RotateTo(new SequentialMovement.Vector2()
            {
                X = rotatePoint.X,
                Y = rotatePoint.Y
            });
        }

        
        public void Record()
        {
            _controller.NextMotion();
        }

        
        public void SetupCurrentIndex(int index)
        {
            _controller.SetIndex(index);
        }
    }
}