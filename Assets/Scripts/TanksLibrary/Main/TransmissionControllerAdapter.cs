using LevelCore.MovePointManagement;
using Transmission;
using Vector2 = Transmission.Vector2;

namespace TanksLibrary.Main
{
    internal class TransmissionControllerAdapter : IMovementController
    {
        private readonly IMoveController _controller;

        public TransmissionControllerAdapter(IMoveController controller)
        {
            _controller = controller;
        }


        public void Play(int index)
        {
            _controller.Play(index);
        }

        public void MoveTo(Vector2 movePoint)
        {
            _controller.MoveTo(new UnityEngine.Vector2(movePoint.X,movePoint.Y));
        }

        public void RotateTo(Vector2 rotatePoint)
        {
            _controller.RotateTo(new UnityEngine.Vector2(rotatePoint.X,rotatePoint.Y));
        }

        public void Record()
        {
            throw new System.NotImplementedException();
        }

        public void Ready()
        {
            _controller.Ready();
        }
    }
}