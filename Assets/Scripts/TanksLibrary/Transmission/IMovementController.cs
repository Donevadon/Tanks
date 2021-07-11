namespace Transmission
{
    public interface IMovementController
    {
        void Play();
        void MoveTo(Vector2 movePoint);
        void RotateTo(Vector2 rotatePoint);
        void Record();
        void SetupCurrentIndex(int index);
    }
}