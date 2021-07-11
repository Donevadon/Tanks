namespace Transmission
{
    public class TurretСrawlerTransmission
    {
        private readonly IMovementController _controller;

        public TurretСrawlerTransmission(IMovementController controller)
        {
            _controller = controller;
        }


        public void Play()
        {
            _controller.Play();
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
            _controller.Record();
        }


        public void SetupCurrentIndex(int index)
        {
            _controller.SetupCurrentIndex(index);
        }
    }
}