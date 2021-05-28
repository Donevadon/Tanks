namespace SequentialMovement
{
    public interface ISequenceController
    {
        void Play(int index);
        void MoveTo(Vector2 movePoint);
        void RotateTo(Vector2 rotatePoint);
        void Record();
    }
}